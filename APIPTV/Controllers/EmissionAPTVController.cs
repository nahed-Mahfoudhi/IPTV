using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using APIPTV.Filters;
using APIPTV.Models;
using Newtonsoft.Json;
using NLog;
using static APIPTV.Models.FluxAOptimiser;

namespace APIPTV.Controllers
{
    [BasicAuthentication]
    [System.Web.Mvc.RequireHttps]
    public class EmissionAPTVController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HttpResponseMessage Get(int codeAgence)
        {
            //157816 VIR96 - 169867    T01 Pickup  960008703 - 181231    2019 - 01 - 03T16: 12:54 + 01:00   2019 - 01 - 03T16: 12:54 + 01:00   0
            List<string> references;
            List<Retour> r = UTILS.EmissionFluxPTV.GetData(codeAgence, out references);
            if (r.Count > 0)
            {
               UTILS.EmissionFluxPTV.UpdateRetreivedData(references);
            }
            JsonSerializer ser = new JsonSerializer();
            string jsonresp = JsonConvert.SerializeObject(r);
            logger.Info(string.Format("{0} => {1}", "JSON RETOUR TO AKANEA", jsonresp));

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonresp, Encoding.UTF8, "application/json");
            return response;
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]dynamic JsonPTV)
        {
            new Task((Action)(async () =>
            {
                try
                {
                    logger.Info("==================================================First==================================");
                    var FluxAOPT = JsonConvert.DeserializeObject<List<FluxPtv>>(JsonPTV.Root.ToString());

                    logger.Info(string.Format("{0} => {1}", "json mrod", JsonPTV.Root.ToString()));
                    var FluxRdvEmission = await UTILS.EmissionFluxPTV.TraitFluxSmartour(FluxAOPT);
                      
                    try
                    {
                        // mon code qui plante
                        UTILS.EmissionFluxPTV.InsertOrUpdate(FluxRdvEmission);
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                          
                            foreach (var ve in eve.ValidationErrors)
                            {
                                System.Diagnostics.Debug.WriteLine(string.Format("Property : {0} Error : {1}", ve.PropertyName, ve.ErrorMessage));
                            }
                        }
                    }
                }
           catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            })).Start();
            return (IHttpActionResult)Ok();


        }

    }
}
