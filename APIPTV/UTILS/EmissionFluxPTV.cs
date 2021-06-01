using APIPTV.DAL;
using APIPTV.modeles;
using APIPTV.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static APIPTV.Models.FluxAOptimiser;

namespace APIPTV.UTILS
{
    public class EmissionFluxPTV
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static string _connectionString = @"Server=SRVSMARTOUR\PTVLO;Database=TRANSFERDB_TEST;User Id=sa;Password=SmarTour4u$;";
        

        public static void InsertOrUpdate(List<ModeleBasePTV> listModeleBasePTV)
        {
            decimal lastNumRow = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand checkifExist = new SqlCommand("SELECT ISNULL(MAX(IMPH_REFERENCE),0) as MAXVALUE FROM dbo.IMPH_IMPORT_HEADER ", connection);
                connection.Open();
                lastNumRow =(decimal) checkifExist.ExecuteScalar();
                connection.Close();
            }

            foreach (var m in listModeleBasePTV)
            {
                lastNumRow = lastNumRow + 1; 
                m.reference = lastNumRow;
                logger.Info($"lastNumRow {lastNumRow} - ref  {m.reference}");
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        String query = string.Empty;

                        query = "INSERT INTO dbo.IMPH_IMPORT_HEADER (IMPH_REFERENCE,IMPH_CONTEXT,IMPH_OBJECT_TYPE,IMPH_EXTID,IMPH_ACTION_CODE,IMPH_PROCESS_CODE,IMPH_CREATION_TIME) " +
                                        "VALUES (@IMPH_REFERENCE,@IMPH_CONTEXT,@IMPH_OBJECT_TYPE,@IMPH_EXTID,@IMPH_ACTION_CODE,@IMPH_PROCESS_CODE,@IMPH_CREATION_TIME)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IMPH_REFERENCE", m.reference);
                            command.Parameters.AddWithValue("@IMPH_CONTEXT", m.Context);
                            command.Parameters.AddWithValue("@IMPH_OBJECT_TYPE", m.object_type);
                            command.Parameters.AddWithValue("@IMPH_EXTID", m.extid);
                            command.Parameters.AddWithValue("@IMPH_ACTION_CODE", m.action_code);
                            command.Parameters.AddWithValue("@IMPH_PROCESS_CODE", m.process_code);
                            command.Parameters.AddWithValue("@IMPH_CREATION_TIME", m.creation_time);

                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            connection.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"Query : INSERT INTO dbo.IMPH_IMPORT_HEADER ");
                        logger.Error($"Message : {ex.Message} - InnerException : {ex.StackTrace}");
                    }

                 
                }

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {


                    try
                    {
                        String query = string.Empty;

                        query = "INSERT INTO dbo.IORH_ORDER_HEADER (IORH_IMPH_REFERENCE,IORH_ORDER_TYPE,IORH_TASKFIELDS,IORH_WEIGHT,IORH_VOLUME,IORH_QUANTITY_1,IORH_VEHICLEREQUIREMENTS ,IORH_TEXT_1 , IORH_TEXT_10 , IORH_NUM_1,IORH_NUM_2, IORH_TEXT_5) " +
                                                            "VALUES (@IORH_IMPH_REFERENCE,@IORH_ORDER_TYPE,@IORH_TASKFIELDS,@IORH_WEIGHT,@IORH_VOLUME,@IORH_QUANTITY_1,@IORH_VEHICLEREQUIREMENTS,@IORH_TEXT_1,@IORH_TEXT_10,@IORH_NUM_1,@IORH_NUM_2,@IORH_TEXT_5)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {

                            SqlParameter referenceParam = command.Parameters.AddWithValue("@IORH_IMPH_REFERENCE", m.reference);
                            if (m.reference == null) { referenceParam.Value = DBNull.Value; }
                            SqlParameter order_typeParam = command.Parameters.AddWithValue("@IORH_ORDER_TYPE", m.order_type);
                            if (m.order_type == null) { order_typeParam.Value = DBNull.Value; }
                            SqlParameter taskfieldsParam = command.Parameters.AddWithValue("@IORH_TASKFIELDS", m.taskfields);
                            if (m.taskfields == null) { taskfieldsParam.Value = DBNull.Value; }
                            SqlParameter weightParam = command.Parameters.AddWithValue("@IORH_WEIGHT", m.weight);
                            if (m.weight == null) { weightParam.Value = DBNull.Value; }
                            SqlParameter volumeParam = command.Parameters.AddWithValue("@IORH_VOLUME", m.volume);
                            if (m.volume == null) { volumeParam.Value = DBNull.Value; }
                            SqlParameter quantity_1Param = command.Parameters.AddWithValue("@IORH_QUANTITY_1", m.quantity_1);
                            if (m.quantity_1 == null) { quantity_1Param.Value = DBNull.Value; }
                            SqlParameter vehicleRequirementsParam = command.Parameters.AddWithValue("@IORH_VEHICLEREQUIREMENTS", m.vehicleRequirements);
                            if (m.vehicleRequirements == null) { vehicleRequirementsParam.Value = DBNull.Value; }
                            SqlParameter text_1Param = command.Parameters.AddWithValue("@IORH_TEXT_1", m.text_1);
                            if (m.text_1 == null) { text_1Param.Value = DBNull.Value; }
                            SqlParameter text_10Param = command.Parameters.AddWithValue("@IORH_TEXT_10", m.text_10);
                            if (m.text_10 == null) { text_10Param.Value = DBNull.Value; }
                            SqlParameter num_1Param = command.Parameters.AddWithValue("@IORH_NUM_1", m.num_1);
                            if (m.num_1 == null) { num_1Param.Value = DBNull.Value; }
                            SqlParameter num_2Param = command.Parameters.AddWithValue("@IORH_NUM_2", m.num_2);
                            if (m.num_2 == null) { num_2Param.Value = DBNull.Value; }
                            SqlParameter text_5Param = command.Parameters.AddWithValue("@IORH_TEXT_5", m.text_5);
                            if (m.text_5 == null) { text_5Param.Value = DBNull.Value; }

                            //The parameterized query '(@IORH_IMPH_REFERENCE decimal(1,0),@IORH_ORDER_TYPE nvarchar(8),' expects the parameter '@IORH_VOLUME', which was not supplied.
                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                        logger.Error($"Query : INSERT INTO dbo.IORH_ORDER_HEADER ");
                        logger.Error($"Message : {ex.Message} - InnerException : {ex.StackTrace}");
                    }
                    

                    }
                

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    try
                    {
                        String query = string.Empty;



                        query = "INSERT INTO dbo.IORA_ORDER_ACTIONPOINT(IORA_IMPH_REFERENCE, IORA_ACTION, IORA_EXTID1,  IORA_IS_ONETIME,  IORA_EARLIEST_DATETIME,  IORA_LATEST_DATETIME)" +
                     "VALUES (@IORA_IMPH_REFERENCE,@IORA_ACTION,@IORA_EXTID1,@IORA_IS_ONETIME,  @IORA_EARLIEST_DATETIME,@IORA_LATEST_DATETIME )";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IORA_IMPH_REFERENCE", m.reference);
                            command.Parameters.AddWithValue("@IORA_ACTION", m.action == "REP" ? "DELIVERY" : "PICKUP");
                            command.Parameters.AddWithValue("@IORA_EXTID1", m.extid1);
                            command.Parameters.AddWithValue("@IORA_IS_ONETIME", 0);
                            command.Parameters.AddWithValue("@IORA_EARLIEST_DATETIME", m.earliest_datetime);
                            command.Parameters.AddWithValue("@IORA_LATEST_DATETIME", m.latest_datetime);

                            SqlParameter serviceperiodeParam = command.Parameters.AddWithValue("@IORA_SERVICEPERIODEXTERNAL", m.serviceperiode);
                            if (m.serviceperiode == null) { serviceperiodeParam.Value = DBNull.Value; }

                            //The parameterized query '(@IORA_IMPH_REFERENCE decimal(1,0),@IORA_ACTION nvarchar(8),@IOR' expects the parameter '@IORA_SERVICEPERIODEXTERNAL', which was not supplied.

                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                        logger.Error($"Query : INSERT INTO dbo.IORA_ORDER_ACTIONPOINT ");
                        logger.Error($"Message : {ex.Message} - InnerException : {ex.StackTrace}");
                    }


                    try
                    {
                        String query2 = string.Empty;
                        query2 = "INSERT INTO dbo.IORA_ORDER_ACTIONPOINT (IORA_IMPH_REFERENCE, IORA_ACTION, IORA_EXTID1,  IORA_IS_ONETIME, IORA_NAME, IORA_STREET, IORA_COUNTRY, IORA_POSTCODE, IORA_CITY,  IORA_EARLIEST_DATETIME,  IORA_LATEST_DATETIME, IORA_HANDLINGTIME_CLASS, IORA_SERVICEPERIODEXTERNAL)  " +
                  "VALUES (@IORA_IMPH_REFERENCE,@IORA_ACTION,@IORA_EXTID1,@IORA_IS_ONETIME,@IORA_NAME,@IORA_STREET,@IORA_COUNTRY,@IORA_POSTCODE,@IORA_CITY,@IORA_EARLIEST_DATETIME,@IORA_LATEST_DATETIME,@IORA_HANDLINGTIME_CLASS,@IORA_SERVICEPERIODEXTERNAL)";



                        using (SqlCommand command = new SqlCommand(query2, connection))
                        {

                            command.Parameters.AddWithValue("@IORA_IMPH_REFERENCE", m.reference);
                            command.Parameters.AddWithValue("@IORA_ACTION", m.action == "REP" ? "PICKUP" : "DELIVERY");
                            command.Parameters.AddWithValue("@IORA_EXTID1", m.extid2);
                            command.Parameters.AddWithValue("@IORA_IS_ONETIME", 1);
                            command.Parameters.AddWithValue("@IORA_NAME", m.name);
                            command.Parameters.AddWithValue("@IORA_STREET", m.street);
                            command.Parameters.AddWithValue("@IORA_COUNTRY", m.country);
                            command.Parameters.AddWithValue("@IORA_POSTCODE", m.postcode);
                            command.Parameters.AddWithValue("@IORA_CITY", m.city);
                            command.Parameters.AddWithValue("@IORA_EARLIEST_DATETIME", m.earliest_datetime);
                            command.Parameters.AddWithValue("@IORA_LATEST_DATETIME", m.latest_datetime);
                            command.Parameters.AddWithValue("@IORA_HANDLINGTIME_CLASS", m.handlingtime_class);
                            SqlParameter serviceperiodeParam = command.Parameters.AddWithValue("@IORA_SERVICEPERIODEXTERNAL", m.serviceperiode);
                            if (m.serviceperiode == null) { serviceperiodeParam.Value = DBNull.Value; }

                            //The parameterized query '(@IORA_IMPH_REFERENCE decimal(1,0),@IORA_ACTION nvarchar(8),@IOR' expects the parameter '@IORA_SERVICEPERIODEXTERNAL', which was not supplied.



                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"Query 2 : INSERT INTO dbo.IORA_ORDER_ACTIONPOINT  ");
                        logger.Error($"Message : {ex.Message} - InnerException : {ex.StackTrace}");
                    }

                  


                    }

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {


                    try
                    {
                        String query = string.Empty;

                        query = "INSERT INTO dbo.IAPO_ACTIONPOINT_OPENINGHOUR (IAPO_IORA_IMPH_REFERENCE,IAPO_IORA_ACTION,IAPO_SEQU_NUMBER    ,IAPO_FROM_WEEKDAY   ," +
                    "IAPO_UNTIL_WEEKDAY  ,IAPO_FROM, IAPO_UNTIL) " +
                    "VALUES (@IAPO_IORA_IMPH_REFERENCE,@IAPO_IORA_ACTION,@IAPO_SEQU_NUMBER,@IAPO_FROM_WEEKDAY,@IAPO_UNTIL_WEEKDAY,@IAPO_FROM,@IAPO_UNTIL)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlParameter referenceParam = command.Parameters.AddWithValue("@IAPO_IORA_IMPH_REFERENCE", m.reference);//clé primaire
                            if (m.reference == null)
                            {
                                referenceParam.Value = DBNull.Value;
                            }
                            SqlParameter actionParam = command.Parameters.AddWithValue("@IAPO_IORA_ACTION", m.action == "REP" ? "PICKUP" : "DELIVERY");
                            if (m.action == null)
                            {
                                actionParam.Value = DBNull.Value;
                            }
                            SqlParameter Seq_NumberParam = command.Parameters.AddWithValue("@IAPO_SEQU_NUMBER", m.Seq_Number);
                            if (m.Seq_Number == null)
                            {
                                Seq_NumberParam.Value = DBNull.Value;
                            }
                            command.Parameters.AddWithValue("@IAPO_FROM_WEEKDAY", m.from_weekday); //m.from_weekday ( soit nul soit un jour de la semaine en EN (SAT,FRI etc ...")
                            command.Parameters.AddWithValue("@IAPO_UNTIL_WEEKDAY", m.until_weekday);//m.until_weekday ( soit nul soit un jour de la semaine en EN (SAT,FRI etc ...")
                            SqlParameter fromParam = command.Parameters.AddWithValue("@IAPO_FROM", Convert.ToString(m.from));
                            if (m.from == null)
                            {
                                fromParam.Value = DBNull.Value;
                            }
                            SqlParameter untilParam = command.Parameters.AddWithValue("@IAPO_UNTIL", Convert.ToString(m.until));
                            if (m.until == null)
                            {
                                untilParam.Value = DBNull.Value;
                            }

                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            connection.Close();

                        }
                    }
                    catch (Exception ex )
                    {

                        logger.Error($"Query : INSERT INTO dbo.IAPO_ACTIONPOINT_OPENINGHOUR");
                        logger.Error($"Message : {ex.Message} - InnerException : {ex.StackTrace}");
                    }
                
                   
                }
            }


         

            }
        

        internal static void UpdateRetreivedData(List<string> references)
        {
           

           var query = string.Format("UPDATE  dbo.EXPH_EXPORT_HEADER " +
                           "SET " +
                           "EXPH_PROCESS_CODE = 50 " +

                           "WHERE EXPH_REFERENCE IN ({0})", string.Join(",",references));

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    int result = command.ExecuteNonQuery();

                }
                connection.Close();
            }
            
        }

        public static List<Retour> GetData(int codAgence, out List<string> references)
        {
            List<Retour> listretour = new List<Retour>();
            // throw new NotImplementedException();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                //string query_ = "SELECT EXPH_REFERENCE ,ETPT_EXTID1 ,ETRE_NAME,ETPA_ACTION,ETPA_ORDER_EXTID1 ,ETPA_START_SERVICE_TIME ,ETPA_END_SERVICE_TIME , ETPA_ETPS_TOURPOINT_SEQUENCE from EXPH_EXPORT_HEADER,ETPT_TOUR_HEADER,ETRE_TOUR_RESOURCE, ETPA_TOUR_ACTIONPOINT where ETPT_EXPH_REFERENCE = EXPH_REFERENCE and ETRE_TOUR_RESOURCE.ETRE_TYPE = 'DRIVER'and ETRE_TOUR_RESOURCE.ETRE_EXPH_REFERENCE = EXPH_REFERENCE and ETPA_ETPS_EXPH_REFERENCE = EXPH_REFERENCE and SUBSTRING(ETPT_EXTID1,4,2) = 33   and ETRE_EXTID1 <> 'DILO'and EXPH_PROCESS_CODE = 50   and  EXPH_REFERENCE ='359886' and ETPA_ORDER_EXTID1='28336-201107' and ETPA_ACTION = 'Delivery'   order by ETPT_EXPH_REFERENCE, ETPA_ETPS_TOURPOINT_SEQUENCE  ;";
                string query_ = "SELECT EXPH_REFERENCE ,ETPT_EXTID1 ,ETRE_NAME,ETPA_ACTION,ETPA_ORDER_EXTID1 ,ETPA_START_SERVICE_TIME ,ETPA_END_SERVICE_TIME , ETPA_ETPS_TOURPOINT_SEQUENCE from EXPH_EXPORT_HEADER,ETPT_TOUR_HEADER,ETRE_TOUR_RESOURCE, ETPA_TOUR_ACTIONPOINT where ETPT_EXPH_REFERENCE = EXPH_REFERENCE and ETRE_TOUR_RESOURCE.ETRE_TYPE = 'DRIVER'and ETRE_TOUR_RESOURCE.ETRE_EXPH_REFERENCE = EXPH_REFERENCE and ETPA_ETPS_EXPH_REFERENCE = EXPH_REFERENCE and SUBSTRING(ETPT_EXTID1,4,2) = @codAgence   and ETRE_EXTID1 <> 'DILO'and EXPH_PROCESS_CODE = 20   order by ETPT_EXPH_REFERENCE, ETPA_ETPS_TOURPOINT_SEQUENCE  ;";
                //string query_ = "SELECT EXPH_REFERENCE ,ETPT_EXTID1 ,ETRE_NAME,ETPA_ACTION,ETPA_ORDER_EXTID1 ,ETPA_START_SERVICE_TIME ,ETPA_END_SERVICE_TIME , ETPA_ETPS_TOURPOINT_SEQUENCE from EXPH_EXPORT_HEADER,ETPT_TOUR_HEADER,ETRE_TOUR_RESOURCE, ETPA_TOUR_ACTIONPOINT where ETPT_EXPH_REFERENCE = EXPH_REFERENCE and ETRE_TOUR_RESOURCE.ETRE_TYPE = 'DRIVER'and ETRE_TOUR_RESOURCE.ETRE_EXPH_REFERENCE = EXPH_REFERENCE and ETPA_ETPS_EXPH_REFERENCE = EXPH_REFERENCE and SUBSTRING(ETPT_EXTID1,4,2) = '35'   and ETRE_EXTID1 <> 'DILO'and EXPH_PROCESS_CODE = 20   order by ETPT_EXPH_REFERENCE, ETPA_ETPS_TOURPOINT_SEQUENCE  ;";


                SqlCommand checkifExist = new SqlCommand(query_, connection);
                checkifExist.Parameters.AddWithValue("@codAgence", codAgence);
                connection.Open(); 


                using (SqlDataReader reader = checkifExist.ExecuteReader())
                {

                     references = new List<string>();
                    foreach (DbDataRecord s in reader)
                        {

                            Retour r = new Retour();

                        references.Add(s["EXPH_REFERENCE"].ToString());
                        var DateStartService = s["ETPA_START_SERVICE_TIME"].ToString();
                        // var DateStartService = "2019-01-03T16:12:54+01:00";
                        var DateEndService = s["ETPA_END_SERVICE_TIME"].ToString();
                        // var DateEndService = "2019-01-03T16:12:54+01:00";


                        //Date Arrivé client
                        var DateStartServiceDateTime = Convert.ToDateTime(DateStartService);
                        var DateStartServiceHours = DateStartServiceDateTime.Hour;
                        var DateStartServiceMinutes = DateStartServiceDateTime.Minute;
                        DateTime dateServiceHoursMinutes = new DateTime(2020,8,1, DateStartServiceHours, DateStartServiceMinutes,0);


                        
                        var DateEndServiceDateTime = Convert.ToDateTime(DateEndService);
                        var DateEndServiceHours = DateEndServiceDateTime.Hour;
                        var DateEndServiceMinutes = DateEndServiceDateTime.Minute;
                        DateTime dateEndServiceHoursMinutes = new DateTime(2020, 8, 1, DateEndServiceHours, DateEndServiceMinutes, 0);

                        var DateStartServiceDateTime_ = Convert.ToDateTime(DateStartService);
                        DateTime dateStartServiceHoursWithZeroMinutes = new DateTime(2020, 8, 1, DateStartServiceHours, 0, 0);


                        DateTime midNightHoursMinutes = new DateTime(2020, 8, 1, 0, 0, 0);
                        DateTime twentyThreeHoursMinutes = new DateTime(2020, 8, 1, 23, 0, 0);

                        int resultCompareToMidNightHoursMinutes = DateTime.Compare(dateServiceHoursMinutes, midNightHoursMinutes);
                        int resultCompareToTwentyThreeHoursMinute = DateTime.Compare(dateServiceHoursMinutes, twentyThreeHoursMinutes);

                        int resultCompareDateEndServiceHoursAndMinutesToMidNightHoursMinutes = DateTime.Compare(dateEndServiceHoursMinutes, midNightHoursMinutes);
                        int resultCompareDateEndServiceHoursAndMinutesToTwentyThreeHoursMinute = DateTime.Compare(dateEndServiceHoursMinutes, twentyThreeHoursMinutes);

                        int resultCompareDateStartServiceHoursWithZeroMinutesToMidNightHoursMinutes = DateTime.Compare(dateStartServiceHoursWithZeroMinutes, midNightHoursMinutes);
                        int resultCompareDateStartServiceHoursWithZeroMinutesToTwentyThreeHoursMinute = DateTime.Compare(dateStartServiceHoursWithZeroMinutes, twentyThreeHoursMinutes);


                        if (resultCompareToMidNightHoursMinutes <0 || resultCompareToTwentyThreeHoursMinute > 0)
                        {
                            DateStartServiceDateTime = new DateTime( DateStartServiceDateTime.Year,DateStartServiceDateTime.Month,DateStartServiceDateTime.Day,  09, 00,00,00, DateStartServiceDateTime.Kind);

                        }

                        /*   ANCIEN CODE
                         *   var heure_Arrive_clt = int.Parse(string.Concat(DateStartService.Substring(11, 2), DateStartService.Substring(14, 2)));
                        if (heure_Arrive_clt < 0000 || heure_Arrive_clt > 2300)
                        {
                            heure_Arrive_clt = 0900;
                        }

                        */
                        //Date Debut Commande

                        if (resultCompareDateStartServiceHoursWithZeroMinutesToMidNightHoursMinutes < 0 || resultCompareDateStartServiceHoursWithZeroMinutesToTwentyThreeHoursMinute > 0)
                        {
                            DateStartServiceDateTime_ = new DateTime(DateStartServiceDateTime_.Year, DateStartServiceDateTime_.Month, DateStartServiceDateTime_.Day, 09, 00, 00, 00, DateStartServiceDateTime.Kind);

                        }
                        /*
                        var heure_Deb_cmd = int.Parse(string.Concat(DateStartService.Substring(11, 2), "00"));
                    if (heure_Deb_cmd < 0000 || heure_Deb_cmd > 2300)
                    {
                        heure_Deb_cmd = 0900;
                    }
                    */


                        if (resultCompareDateEndServiceHoursAndMinutesToMidNightHoursMinutes < 0 || resultCompareDateEndServiceHoursAndMinutesToTwentyThreeHoursMinute > 0)
                        {
                            DateEndServiceDateTime = new DateTime(DateEndServiceDateTime.Year, DateEndServiceDateTime.Month, DateEndServiceDateTime.Day, 09, 00, 00, 00, DateEndServiceDateTime.Kind);

                        }
                        /*
                        var heure_dep_clt = int.Parse(string.Concat(DateEndService.Substring(11, 2), DateEndService.Substring(14, 2)));
                        if (heure_dep_clt < 0000 || heure_dep_clt > 2300)
                        {
                            heure_dep_clt = 0900;
                        }
                        */

                        //Console.WriteLine(String.Format("{0}", reader["id"]));
                         r.IdCommande = s["ETPA_ORDER_EXTID1"].ToString();
                       // r.IdCommande = "9055588 - 405529";
                        r.IdCommande = r.IdCommande.Substring(0,r.IdCommande.IndexOf("-"));
                        r.CodeAgence =( s["ETPT_EXTID1"].ToString()).Substring(3,2);
                        r.CodeDirection = s["ETRE_NAME"].ToString();
                        r.Action = s["ETPA_ACTION"].ToString();
                        r.Ordre = int.Parse(s["ETPA_ETPS_TOURPOINT_SEQUENCE"].ToString());


                        r.DateHeureDebutCommande = (new DateTime(
                                                                    DateStartServiceDateTime_.Year,
                                                                    DateStartServiceDateTime_.Month,
                                                                    DateStartServiceDateTime_.Day,
                                                                    DateStartServiceDateTime_.Hour,
                                                                    00,
                                                                    00,
                                                                    00,
                                                                   DateStartServiceDateTime.Kind)).ToString("yyyy-MM-ddTHH:mm:ss").Substring(0, 19);
                        r.DateHeureArriveeClient = (new DateTime(
                                                                    DateStartServiceDateTime.Year,
                                                                    DateStartServiceDateTime.Month,
                                                                    DateStartServiceDateTime.Day,
                                                                    DateStartServiceDateTime.Hour,
                                                                    DateStartServiceDateTime.Minute,
                                                                    00,
                                                                    00,
                                                                    DateStartServiceDateTime.Kind)).ToString("yyyy-MM-ddTHH:mm:ss").Substring(0,19);
                        r.DateHeureDepartClient = (new DateTime(
                                                                   DateEndServiceDateTime.Year,
                                                                   DateEndServiceDateTime.Month,
                                                               DateEndServiceDateTime.Day,
                                                                   DateEndServiceDateTime.Hour,
                                                                   DateEndServiceDateTime.Minute,
                                                                   00,
                                                                   00,
                                                                   DateEndServiceDateTime.Kind)).ToString("yyyy-MM-ddTHH:mm:ss").Substring(0, 19);
                        // r.DateHeureDebutCommande = string.Concat(DateStartService.Substring(0,11), CastFormatDateHours(heure_Deb_cmd));  //2019-01-03T16:12:54+01:00
                        // r.DateHeureArriveeClient = string.Concat(DateStartService.Substring(0, 11), CastFormatDateHours(heure_Arrive_clt)); // reader["ETPA_START_SERVICE_TIME"].ToString();
                        // r.DateHeureDepartClient = string.Concat(DateEndService.Substring(0, 11), CastFormatDateHours(heure_dep_clt));  // reader["ETPA_END_SERVICE_TIME"].ToString(); 
                        listretour.Add(r);  
                        }
                    

                
                }
            }
           

            return listretour;
        }

      

        public static string CastFormatDateHours(int a)
        {
            string n = Convert.ToString(a);
            return n.Substring(0, 2) + ":" + n.Substring(2, 2)+ ":00";
        }

        public static async Task<List<ModeleBasePTV>> TraitFluxSmartour(List<FluxPtv> FluxptvList)
        {
            //TODO faire le traitement ici le mapping ....
            #region creation de l'objet Liste PTV pour l'insérer dans la base PTV
            ModelesBasePTV ModeleBasePTV = new ModelesBasePTV();
            List<ModeleBasePTV> ListModeleBasePTV = new List<ModeleBasePTV>();
            foreach (var item in FluxptvList)
            {
                ListModeleBasePTV.Add(new ModeleBasePTV());
            }
            ModeleBasePTV.ListModeleBasePTV = ListModeleBasePTV;
            #endregion


            for (int i = 0; i < ListModeleBasePTV.Count; i++)
            {
                //Calcul type marchandise
                int? TotCol = FluxptvList[i].CommandeTotaux.TotalColis;
                double? totalpoids = FluxptvList[i].CommandeTotaux.TotalPoids;


                #region typeMerch et PM
                double? PM =0;
                string TypMarch = "A";
                if (FluxptvList[i].Prestation!=null)
                { 
                if (FluxptvList[i].Prestation.Code == "LM")
                    TypMarch = "M";
                else
                {
                    if (totalpoids!=null && totalpoids < 40)
                        TypMarch = "P";
                    else TypMarch = "L";
                    if (TotCol != null && TotCol < 1)
                    {
                        TotCol = 1;
                        if (totalpoids != null)
                        {
                            PM = (totalpoids) / 1;
                        }
                        else
                            PM = 0;
                        
                    }
                    if (PM > 60)
                    {
                        if (TotCol == 1)
                            TypMarch = "A";
                        if (TotCol == 2)
                            TypMarch = "B";
                        if (TotCol == 3)
                            TypMarch = "C";
                        if (TotCol == 4)
                            TypMarch = "D";
                        if (TotCol > 4)
                            TypMarch = "E";
                    }

                }
                }
                #endregion

                //calcul Vehiclerequirements/code_territoire_mappe/libel1/class poids
                #region calcul Vehiclerequirements/code_territoire_mappe
                var cod_territoire_mappe = "";
                if (FluxptvList[i].SpecifiqueChaine3 == "10")
                    cod_territoire_mappe = "122";
                else
                {
                    if (FluxptvList[i].SpecifiqueChaine3 == "20")
                        cod_territoire_mappe = "002";
                    else
                        cod_territoire_mappe = "000";
                }

                //calcul de libel1
                var libel = "";
                if (FluxptvList[i].Trafic.Code == "REP")
                    libel = "PICKUP";
                else
                    libel = "DELIVERY";

                //calcul du taskfields/agence
                var agence = "";
                if (FluxptvList[i].Agence.CodeNumerique.Length==2)
                {
                        agence = string.Concat("VIR", (FluxptvList[i].Agence.CodeNumerique).Substring(0, 2));
                }

                var Depot = "";
                 Depot = string.Concat("DEPOT", FluxptvList[i].Agence.CodeNumerique);
               
                //if ((FluxptvList[i].SpecifiqueChaine2!="00" )&&(FluxptvList[i].SpecifiqueChaine2 != "11") &&(FluxptvList[i].SpecifiqueChaine2 != "91"))
                //    Depot = string.Concat(Depot, FluxptvList[i].SpecifiqueChaine2);

                //Calcul class poids
                var ClassPoids = 5;
                if (FluxptvList[i].CommandeTotaux.TotalPoids < 400)
                    ClassPoids = 4;
                if (FluxptvList[i].CommandeTotaux.TotalPoids < 200)
                    ClassPoids = 3;
                if (FluxptvList[i].CommandeTotaux.TotalPoids < 100)
                    ClassPoids = 2;
                if (FluxptvList[i].CommandeTotaux.TotalPoids < 50)
                    ClassPoids = 1;
                #endregion 

                ListModeleBasePTV[i].reference = FluxptvList[i].IdCommandeEntete;
                ListModeleBasePTV[i].Context = "STANDARD";

                ListModeleBasePTV[i].object_type = "ORDER";
                ListModeleBasePTV[i].extid = string.Concat(FluxptvList[i].IdCommandeEntete,"-", FluxptvList[i].DateDebutLivraison.ToString("yyMMdd"));
                ListModeleBasePTV[i].action_code = "UPDATE";
                ListModeleBasePTV[i].process_code = Convert.ToDecimal("20");
                ListModeleBasePTV[i].creation_time = (DateTime.Now).ToString("yyyyMMddHHmmss");
                //order_type=libel
                ListModeleBasePTV[i].order_type = libel;
                //taskfields=Agence
                ListModeleBasePTV[i].taskfields = agence;
                //Total poids
                ListModeleBasePTV[i].weight = FluxptvList[i].CommandeTotaux.TotalPoids;
                //Volume
                if (FluxptvList[i].CommandeTotaux.TotalVolume==null)
                {
                    ListModeleBasePTV[i].volume = 0;
                }
                else
                { 
                    ListModeleBasePTV[i].volume = FluxptvList[i].CommandeTotaux.TotalVolume;
                }
               
                //Total quantité
                ListModeleBasePTV[i].quantity_1 = FluxptvList[i].CommandeTotaux.TotalColis;
                ListModeleBasePTV[i].vehicleRequirements = cod_territoire_mappe;
                //text_1=typMarch
                ListModeleBasePTV[i].text_1 = TypMarch;
                //Text_10=agence
                ListModeleBasePTV[i].text_10 = agence;
                //Num_1=code territoire=specifiqueChaine2
                if (FluxptvList[i].SpecifiqueChaine3!=null )
                { ListModeleBasePTV[i].num_1 = double.Parse(FluxptvList[i].SpecifiqueChaine3); }
                //num_2=CA
                ListModeleBasePTV[i].num_2 = FluxptvList[i].CommandeTotauxMontant.ChiffreAffaire;
                //text_5=numero recipissé
                ListModeleBasePTV[i].text_5 =FluxptvList[i].NumeroRecepisse;
                ListModeleBasePTV[i].action = FluxptvList[i].Trafic.Code;
                //onetime=valeur en dur
                ListModeleBasePTV[i].onetime = 0;
                //DateLivraison format : AAAAMMJJ0000
                ListModeleBasePTV[i].earliest_datetime = string.Concat(FluxptvList[i].DateDebutLivraison.ToString("yyyyMMdd"),"0000");
                //DateLivraison format : AAAAMMJJ0000
                ListModeleBasePTV[i].latest_datetime = string.Concat(FluxptvList[i].DateDebutLivraison.ToString("yyyyMMdd"), "2359");
                //Nom de destinataire
                ListModeleBasePTV[i].name = FluxptvList[i].NomDestinataire;
                //adresse1,adresse2,adresse3

                ListModeleBasePTV[i].street = string.Concat(FluxptvList[i].Adresse1Destinataire,",", FluxptvList[i].Adresse2Destinataire, ",", FluxptvList[i].Adresse3Destinataire);
                if (ListModeleBasePTV[i].street.Length > 100)
                {
                    ListModeleBasePTV[i].street = ListModeleBasePTV[i].street.Substring(0, 100);
                }
                //Pays en dur
                ListModeleBasePTV[i].country = "FRA";
                ListModeleBasePTV[i].extid1 = Depot;
                ListModeleBasePTV[i].extid2 = string.Concat(FluxptvList[i].IdCommandeEntete,"-", FluxptvList[i].DateDebutLivraison.ToString("yyMMdd")) ;
                //Code postal de destinataire
                ListModeleBasePTV[i].postcode = FluxptvList[i].LocaliteDestinataire.CodePostal;
                //ville de destinataire
                ListModeleBasePTV[i].city = FluxptvList[i].LocaliteDestinataire.Nom;
                //class poids
                ListModeleBasePTV[i].handlingtime_class = ClassPoids;
              
                    ListModeleBasePTV[i].serviceperiode = FluxptvList[i].CommandeTotaux.TotalTempsMontage;
               
                //date debut rdv
                ListModeleBasePTV[i].from =FluxptvList[i].THeureDebutRDV?.TimeOfDay.ToString().Substring(0,5).Replace(":","");
                //date fin rdv
                ListModeleBasePTV[i].until =FluxptvList[i].THeureFinRDV?.TimeOfDay.ToString().Substring(0, 5).Replace(":", "");  
                //DateLivraison format : AAAAMMJJ0000
                ListModeleBasePTV[i].until_weekday = FluxptvList[i].DateDebutLivraison.DayOfWeek.ToString().Substring(0,3);  
                //DateLivraison format : AAAAMMJJ0000
                ListModeleBasePTV[i].from_weekday = FluxptvList[i].DateDebutLivraison.DayOfWeek.ToString().Substring(0, 3);
                //1 En dur     
                ListModeleBasePTV[i].Seq_Number = 1;

            }
            await Task.Delay(500);

            return (ModeleBasePTV.ListModeleBasePTV);
        }
    }
}