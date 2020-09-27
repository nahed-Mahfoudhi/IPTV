using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPTV.Controllers
{
    public class RetoutFluxOptimisationTourneeController : ApiController
    {
        // GET: api/RetoutFluxOptimisationTournee
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RetoutFluxOptimisationTournee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RetoutFluxOptimisationTournee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RetoutFluxOptimisationTournee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RetoutFluxOptimisationTournee/5
        public void Delete(int id)
        {
        }
    }
}
