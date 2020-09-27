using APIPTV.DAL;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using APIPTV.modeles;
using System.Web;
using APIPTV.Models;

namespace APIPTV.UTILS
{
    public class FluxRetourPTV
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static ListRetourFluxOptimiser GetByID(int IdAgence)
        {
            /*
            //TODO save as data..
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {

                RetourFluxOptimiser RetourFluxOptimiser = new RetourFluxOptimiser();
                ListRetourFluxOptimiser ListRetourFluxOptimis = new ListRetourFluxOptimiser();

                foreach (var i in ListRetourFluxOptimis.ListRetourFluxOptimise)

                {

                    // data du table EXPH_EXPORT_HEADER
                    EXPH_EXPORT_HEADER EXPH_EXPORT_HEADER = new EXPH_EXPORT_HEADER
                    {



                    };

                    //data du table ETPA_TOUR_ACTIONPOINT
                    ETPA_TOUR_ACTIONPOINT ETPA_TOUR_ACTIONPOINT = new ETPA_TOUR_ACTIONPOINT
                    {
                        //i.IdCommande = ETPA_TOUR_ACTIONPOINT.ETPA_ORDER_EXTID1;
                        //i.Action = ETPA_TOUR_ACTIONPOINT.ETPA_ACTION;
                        //i.Ordre = ETPA_TOUR_ACTIONPOINT.ETPA_ETPS_TOURPOINT_SEQUENCE;

                    };

                    //data du table ETPT_TOUR_HEADER
                    ETPT_TOUR_HEADER ETPT_TOUR_HEADER = new ETPT_TOUR_HEADER
                    {
                        //i.CodeAgence = ETPT_TOUR_HEADER.ETPT_EXTID1;

                    };

                    //data du table ETRE_TOUR_RESOURCE
                    ETRE_TOUR_RESOURCE ETRE_TOUR_RESOURCE = new ETRE_TOUR_RESOURCE
                    {

                        //i.CodeDirection = ETRE_TOUR_RESOURCE.ETRE_NAME,

                    };

                    unitOfWork.IMPH_IMPORT_HEADERRepository.GetByID(EXPH_EXPORT_HEADER);


                    unitOfWork.Save();

                    /*
                    dbContext.IMPH_IMPORT_HEADER.Add(iMPH_IMPORT_HEADER);
                    dbContext.IORA_ORDER_ACTIONPOINT.Add(iORA_ORDER_ACTIONPOINT);
                    dbContext.IORA_ORDER_ACTIONPOINT.Add(iORA_ORDER_ACTIONPOINT2);
                    dbContext.IAPO_ACTIONPOINT_OPENINGHOUR.Add(iAPO_ACTIONPOINT_OPENINGHOUR);

                    dbContext.SaveChanges();
                   
                }
                 */
            return null;
            }



        }



    /*
        public static void Update()
        {
        
            //data du table ETRE_TOUR_RESOURCE
            EXPH_EXPORT_HEADER EXPH_EXPORT_HEADER = new EXPH_EXPORT_HEADER
            {

                EXPH_PROCESS_CODE = 50,

            };
            
        }*/
}


