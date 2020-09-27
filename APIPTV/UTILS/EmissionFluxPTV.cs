using APIPTV.DAL;
using APIPTV.modeles;
using APIPTV.Models;
using NLog;
using System;
using System.Collections.Generic;
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
            foreach (var m in listModeleBasePTV)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    SqlCommand checkifExist = new SqlCommand("SELECT COUNT(*) FROM dbo.IMPH_IMPORT_HEADER WHERE (IMPH_REFERENCE = @IMPH_REFERENCE)", connection);
                    checkifExist.Parameters.AddWithValue("@IMPH_REFERENCE", m.reference);
                    connection.Open();
                    int UserExist = (int)checkifExist.ExecuteScalar();
                    connection.Close();
                    String query = string.Empty;
                    if (UserExist > 0)
                    {
                        query = "UPDATE  dbo.IMPH_IMPORT_HEADER " +
                      "SET " +
                      "IMPH_CONTEXT = @IMPH_CONTEXT ," +
                      "IMPH_OBJECT_TYPE = @IMPH_OBJECT_TYPE ," +
                      "IMPH_EXTID = @IMPH_EXTID ," +
                      "IMPH_ACTION_CODE = @IMPH_ACTION_CODE ," +
                      "IMPH_PROCESS_CODE = @IMPH_PROCESS_CODE ," +
                      "IMPH_CREATION_TIME = @IMPH_CREATION_TIME " +
                      "WHERE IMPH_REFERENCE = @IMPH_REFERENCE";
                    }
                    else
                    {
                        query = "INSERT INTO dbo.IMPH_IMPORT_HEADER (IMPH_REFERENCE,IMPH_CONTEXT,IMPH_OBJECT_TYPE,IMPH_EXTID,IMPH_ACTION_CODE,IMPH_PROCESS_CODE,IMPH_CREATION_TIME) " +
                                        "VALUES (@IMPH_REFERENCE,@IMPH_CONTEXT,@IMPH_OBJECT_TYPE,@IMPH_EXTID,@IMPH_ACTION_CODE,@IMPH_PROCESS_CODE,@IMPH_CREATION_TIME)";
                    }
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IMPH_REFERENCE", m.reference );
                            command.Parameters.AddWithValue("@IMPH_CONTEXT", m.Context);
                            command.Parameters.AddWithValue("@IMPH_OBJECT_TYPE", m.object_type);
                            command.Parameters.AddWithValue("@IMPH_EXTID", m.extid);
                            command.Parameters.AddWithValue("@IMPH_ACTION_CODE", m.action_code);
                            command.Parameters.AddWithValue("@IMPH_PROCESS_CODE", m.process_code);
                            command.Parameters.AddWithValue("@IMPH_CREATION_TIME", m.creation_time);
                       
                            connection.Open();
                            int result = command.ExecuteNonQuery();

                        }                                    
                }


       


      
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand checkifExist = new SqlCommand("SELECT COUNT(*) FROM dbo.IORH_ORDER_HEADER WHERE (IORH_IMPH_REFERENCE = @IORH_IMPH_REFERENCE)", connection);
                    checkifExist.Parameters.AddWithValue("@IORH_IMPH_REFERENCE", m.reference);
                    connection.Open();
                    int UserExist = (int)checkifExist.ExecuteScalar();
                    connection.Close();
                    String query = string.Empty;
                    if (UserExist > 0)
                    {
                        query = "UPDATE  dbo.IORH_ORDER_HEADER " +
                       "SET " +
                       "IORH_ORDER_TYPE = @IORH_ORDER_TYPE," +
                       "IORH_TASKFIELDS = @IORH_TASKFIELDS," +
                       "IORH_WEIGHT = @IORH_WEIGHT," +
                       "IORH_VOLUME = @IORH_VOLUME ," +
                       "IORH_QUANTITY_1 = @IORH_QUANTITY_1 ," +
                       "IORH_VEHICLEREQUIREMENTS = @IORH_VEHICLEREQUIREMENTS ," +
                       "IORH_TEXT_1 = @IORH_TEXT_1," +
                       "IORH_TEXT_10 = @IORH_TEXT_10 ," +
                       "IORH_NUM_1 = @IORH_NUM_1 ," +
                       "IORH_NUM_2 = @IORH_NUM_2 ," +
                       "IORH_TEXT_5 = @IORH_TEXT_5 " +
                       "WHERE IORH_IMPH_REFERENCE = @IORH_IMPH_REFERENCE";
                    }
                    else
                    {
                        query = "INSERT INTO dbo.IORH_ORDER_HEADER (IORH_IMPH_REFERENCE,IORH_ORDER_TYPE,IORH_TASKFIELDS,IORH_WEIGHT,IORH_VOLUME,IORH_QUANTITY_1,IORH_VEHICLEREQUIREMENTS ,IORH_TEXT_1 , IORH_TEXT_10 , IORH_NUM_1,IORH_NUM_2, IORH_TEXT_5) " +
                                                            "VALUES (@IORH_IMPH_REFERENCE,@IORH_ORDER_TYPE,@IORH_TASKFIELDS,@IORH_WEIGHT,@IORH_VOLUME,@IORH_QUANTITY_1,@IORH_VEHICLEREQUIREMENTS,@IORH_TEXT_1,@IORH_TEXT_10,@IORH_NUM_1,@IORH_NUM_2,@IORH_TEXT_5)";
                    }
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

                        }                    
                }
            
 
               
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand checkifExist = new SqlCommand("SELECT COUNT(*) FROM dbo.IORA_ORDER_ACTIONPOINT WHERE (IORA_IMPH_REFERENCE = @IORA_IMPH_REFERENCE AND IORA_ACTION = @IORA_ACTION)", connection);
                    checkifExist.Parameters.AddWithValue("@IORA_IMPH_REFERENCE", m.reference);
                    checkifExist.Parameters.AddWithValue("@IORA_ACTION", m.action);
                    connection.Open();
                    int UserExist = (int)checkifExist.ExecuteScalar();
                    connection.Close();
                    String query = string.Empty;
                    String query2 = string.Empty;
                    if (UserExist > 0)
                    {
                        //Username exist log
                        //query = "UPDATE  dbo.IORA_ORDER_ACTIONPOINT " +
                        //  "SET " +
                        //  "IORA_ACTION = @IORA_ACTION ," +
                        //  "IORA_EXTID1 = @IORA_EXTID1 ," +
                        //  "IORA_IS_ONETIME = @IORA_IS_ONETIME ," +
                        //  "IORA_NAME = @IORA_NAME ," +
                        //  "IORA_STREET = @IORA_STREET ," +
                        //  "IORA_POSTCODE = @IORA_POSTCODE ," +
                        //  "IORA_CITY = @IORA_CITY ," +
                        //  "IORA_EARLIEST_DATETIME = @IORA_EARLIEST_DATETIME ," +
                        //  "IORA_HANDLINGTIME_CLASS = @IORA_HANDLINGTIME_CLASS " +
                        //  "WHERE IORA_IMPH_REFERENCE = @IORA_IMPH_REFERENCE";
                    }
                    else
                    {
                        connection.Open();

                        query = "INSERT INTO dbo.IORA_ORDER_ACTIONPOINT(IORA_IMPH_REFERENCE, IORA_ACTION, IORA_EXTID1,  IORA_IS_ONETIME,  IORA_EARLIEST_DATETIME,  IORA_LATEST_DATETIME)"+
                     "VALUES (@IORA_IMPH_REFERENCE,@IORA_ACTION,@IORA_EXTID1,@IORA_IS_ONETIME,  @IORA_EARLIEST_DATETIME,@IORA_LATEST_DATETIME )";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@IORA_IMPH_REFERENCE", m.reference);
                                command.Parameters.AddWithValue("@IORA_ACTION", m.action  == "R" ? "DELIVERY" : "PICKUP");
                                command.Parameters.AddWithValue("@IORA_EXTID1", m.extid1);
                                command.Parameters.AddWithValue("@IORA_IS_ONETIME", m.onetime1);                          
                                command.Parameters.AddWithValue("@IORA_EARLIEST_DATETIME", m.earliest_datetime);
                                command.Parameters.AddWithValue("@IORA_LATEST_DATETIME", m.latest_datetime);
                         
                                SqlParameter serviceperiodeParam = command.Parameters.AddWithValue("@IORA_SERVICEPERIODEXTERNAL", m.serviceperiode);
                                if (m.serviceperiode == null) { serviceperiodeParam.Value = DBNull.Value; }

                                //The parameterized query '(@IORA_IMPH_REFERENCE decimal(1,0),@IORA_ACTION nvarchar(8),@IOR' expects the parameter '@IORA_SERVICEPERIODEXTERNAL', which was not supplied.
                               
                                int result = command.ExecuteNonQuery();
                            }
                         

                        query2 = "INSERT INTO dbo.IORA_ORDER_ACTIONPOINT (IORA_IMPH_REFERENCE, IORA_ACTION, IORA_EXTID1,  IORA_IS_ONETIME, IORA_NAME, IORA_STREET, IORA_COUNTRY, IORA_POSTCODE, IORA_CITY,  IORA_EARLIEST_DATETIME,  IORA_LATEST_DATETIME, IORA_HANDLINGTIME_CLASS, IORA_SERVICEPERIODEXTERNAL)  " +
              "VALUES (@IORA_IMPH_REFERENCE,@IORA_ACTION,@IORA_EXTID1,@IORA_IS_ONETIME,@IORA_NAME,@IORA_STREET,@IORA_COUNTRY,@IORA_POSTCODE,@IORA_CITY,@IORA_EARLIEST_DATETIME,@IORA_LATEST_DATETIME,@IORA_HANDLINGTIME_CLASS,@IORA_SERVICEPERIODEXTERNAL)";



                        using (SqlCommand command = new SqlCommand(query2, connection))
                        {
                            command.Parameters.AddWithValue("@IORA_IMPH_REFERENCE", m.reference);
                            command.Parameters.AddWithValue("@IORA_ACTION", m.action == "R" ? "PICKUP" : "DELIVERY");
                            command.Parameters.AddWithValue("@IORA_EXTID1", m.extid1);
                            command.Parameters.AddWithValue("@IORA_IS_ONETIME", m.onetime1);
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
                            

                               
                            int result = command.ExecuteNonQuery();
                        }


                    }
                 
                    
                }
         

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    SqlCommand checkifExist = new SqlCommand("SELECT COUNT(*) FROM dbo.IAPO_ACTIONPOINT_OPENINGHOUR WHERE (IAPO_IORA_IMPH_REFERENCE = @IAPO_IORA_IMPH_REFERENCE)", connection);
                    checkifExist.Parameters.AddWithValue("@IAPO_IORA_IMPH_REFERENCE", m.reference);
                    connection.Open();
                    int UserExist = (int)checkifExist.ExecuteScalar();
                    connection.Close();
                    String query = string.Empty;
                    if (UserExist > 0)
                    {
                        query = "UPDATE  dbo.IAPO_ACTIONPOINT_OPENINGHOUR " +
                          "SET " +
                          "IAPO_IORA_ACTION = @IAPO_IORA_ACTION ," +
                          "IAPO_SEQU_NUMBER = @IAPO_SEQU_NUMBER ," +
                          "IAPO_FROM_WEEKDAY = @IAPO_FROM_WEEKDAY ," +
                          "IAPO_UNTIL_WEEKDAY = @IAPO_UNTIL_WEEKDAY ," +
                          "IAPO_FROM = @IAPO_FROM ," +
                          "IAPO_UNTIL = @IAPO_UNTIL " +
                          //"IORA_EARLIEST_DATETIME = @IORA_EARLIEST_DATETIME ," +
                          //"IORA_LATEST_DATETIME = @IORA_LATEST_DATETIME ," +
                          //"IORA_HANDLINGTIME_CLASS = @IORA_HANDLINGTIME_CLASS" +
                          "WHERE IAPO_IORA_IMPH_REFERENCE = @IAPO_IORA_IMPH_REFERENCE";
                    }
                    else
                    {
                        query = "INSERT INTO dbo.IAPO_ACTIONPOINT_OPENINGHOUR (IAPO_IORA_IMPH_REFERENCE,IAPO_IORA_ACTION,IAPO_SEQU_NUMBER    ,IAPO_FROM_WEEKDAY   ," +
                    "IAPO_UNTIL_WEEKDAY  ,IAPO_FROM, IAPO_UNTIL) " +
                    "VALUES (@IAPO_IORA_IMPH_REFERENCE,@IAPO_IORA_ACTION,@IAPO_SEQU_NUMBER,@IAPO_FROM_WEEKDAY,@IAPO_UNTIL_WEEKDAY,@IAPO_FROM,@IAPO_UNTIL)";
                    }
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlParameter referenceParam = command.Parameters.AddWithValue("@IAPO_IORA_IMPH_REFERENCE", m.reference );//clé primaire
                            if (m.reference == null)
                            {
                                referenceParam.Value = DBNull.Value;
                            }
                            SqlParameter actionParam = command.Parameters.AddWithValue("@IAPO_IORA_ACTION", m.action == "R" ? "PICKUP" : "DELIVERY");
                            if (m.action == null)
                            {
                                actionParam.Value = DBNull.Value;
                            }
                            SqlParameter Seq_NumberParam = command.Parameters.AddWithValue("@IAPO_SEQU_NUMBER", m.Seq_Number);
                            if (m.Seq_Number == null)
                            {
                                Seq_NumberParam.Value = DBNull.Value;
                            }
                            command.Parameters.AddWithValue("@IAPO_FROM_WEEKDAY", "SAT"); //m.from_weekday ( soit nul soit un jour de la semaine en EN (SAT,FRI etc ...")
                            command.Parameters.AddWithValue("@IAPO_UNTIL_WEEKDAY", "FRI");//m.until_weekday ( soit nul soit un jour de la semaine en EN (SAT,FRI etc ...")
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

                    }
                }
                
            }
        }

        public static Retour GetData(int codAgence)
        {
            Retour r = new Retour();
            // throw new NotImplementedException();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                string query_ = "SELECT EXPH_REFERENCE ,ETPT_EXTID1 ,ETRE_NAME,ETPA_ACTION,ETPA_ORDER_EXTID1 ,ETPA_START_SERVICE_TIME ,ETPA_END_SERVICE_TIME , ETPA_ETPS_TOURPOINT_SEQUENCE from EXPH_EXPORT_HEADER,ETPT_TOUR_HEADER,ETRE_TOUR_RESOURCE, ETPA_TOUR_ACTIONPOINT where ETPT_EXPH_REFERENCE = EXPH_REFERENCE and ETRE_TOUR_RESOURCE.ETRE_TYPE = 'DRIVER'and ETRE_TOUR_RESOURCE.ETRE_EXPH_REFERENCE = EXPH_REFERENCE and ETPA_ETPS_EXPH_REFERENCE = EXPH_REFERENCE and SUBSTRING(ETPT_EXTID1,4,2) = '@codAgence'   and ETRE_EXTID1 <> 'DILO'and EXPH_PROCESS_CODE = 20 order by ETPT_EXPH_REFERENCE, ETPA_ETPS_TOURPOINT_SEQUENCE ;";


                SqlCommand checkifExist = new SqlCommand(query_, connection);
                checkifExist.Parameters.AddWithValue("@codAgence", codAgence);
                connection.Open(); 


                using (SqlDataReader reader = checkifExist.ExecuteReader())
                {
                    if (reader.Read())
                    {

                    // var DareStartService = reader["ETPA_START_SERVICE_TIME"].ToString();
                    var DateStartService = "2019-01-03T16:12:54+01:00";
                    // var DateEndService = reader["ETPA_START_SERVICE_TIME"].ToString();
                    var DateEndService = "2019-01-03T16:12:54+01:00";


                    //Date Arrivé client
                    var heure_Arrive_clt = int.Parse(string.Concat(DateStartService.Substring(11, 2), DateStartService.Substring(14, 2)));
                    if (heure_Arrive_clt < 1000 || heure_Arrive_clt < 2300)
                    {
                        heure_Arrive_clt = 0900;
                    }

                    //Date Debut Commande

                    var heure_Deb_cmd = int.Parse(string.Concat(DateEndService.Substring(11, 2), "00"));
                    if (heure_Deb_cmd < 1000 || heure_Deb_cmd < 2300)
                    {
                        heure_Deb_cmd = 0900;
                    }


                    //Calcul du Heure_depart_Clt

                    // var DateDebut = reader["ETPA_END_SERVICE_TIME"].ToString();
                  

                    var heure_dep_clt = int.Parse(string.Concat(DateStartService.Substring(11, 2), DateStartService.Substring(14, 2)));
                    if (heure_dep_clt > 1000 || heure_dep_clt < 2300)
                    {
                        heure_dep_clt = 0900;
                    }

                    //Console.WriteLine(String.Format("{0}", reader["id"]));
                    r.IdCommande = reader["ETPA_ORDER_EXTID1"].ToString();  
                        r.CodeAgence = reader["ETPT_EXTID1"].ToString();
                        r.CodeDirection = reader["ETRE_NAME"].ToString();
                        r.Action = reader["ETPA_ACTION"].ToString();
                        r.Ordre = reader["Ordre"].ToString();
                        if(DateStartService != null)
                        r.DateHeureDebutCommande = string.Concat(DateStartService.Substring(0,11), CastFormatDateHours(heure_Deb_cmd));  //2019-01-03T16:12:54+01:00
                        r.DateHeureArriveeClient = string.Concat(DateStartService.Substring(0, 11), CastFormatDateHours(heure_Arrive_clt)); // reader["ETPA_START_SERVICE_TIME"].ToString();
                    r.DateHeureDepartClient = string.Concat(DateEndService.Substring(0, 11), CastFormatDateHours(heure_dep_clt));  // reader["ETPA_END_SERVICE_TIME"].ToString(); 

                    }
                }
            }

            return r;
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
                double? PM =0;
                string TypMarch = "A";
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

                //calcul Vehiclerequirements/code_territoire_mappe

                var cod_territoire_mappe = "";
                if (FluxptvList[i].SpecifiqueChaine2 == 10)
                    cod_territoire_mappe = "122";
                else
                {
                    if (FluxptvList[i].SpecifiqueChaine2 ==20)
                        cod_territoire_mappe = "002";
                    else
                        cod_territoire_mappe = "000";
                }

                //calcul de libel1
                var libel = "";
                if (FluxptvList[i].Trafic.Code == "R")
                    libel = "PICKUP";
                else
                    libel = "DELIVERY";

                //calcul du taskfields/agence
                var agence = "";
                if (FluxptvList[i].Agence.CodeNumerique.Length==2)
                 agence = string.Concat("VIR", (FluxptvList[i].Agence.CodeNumerique).Substring(0,2));


                //calcul Depot/Extid1
                var Depot = string.Concat("DEPOT", FluxptvList[i].Agence.CodeNumerique);
                if ((FluxptvList[i].SpecifiqueChaine3!="00" )&&(FluxptvList[i].SpecifiqueChaine3 != "11") &&(FluxptvList[i].SpecifiqueChaine3 != "91"))
                    Depot = string.Concat(Depot, FluxptvList[i].SpecifiqueChaine3);

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

                    
                ListModeleBasePTV[i].reference =  FluxptvList[i].IdCommandeEntete + FluxptvList[i].NumeroRecepisse;
                //Context:champs en dur     Random rnd2 = new Random();    Math.Round(new decimal(rnd2.Next(1, 999999999))) +
                ListModeleBasePTV[i].Context = "STANDARD";

                ListModeleBasePTV[i].object_type = "ORDER";
                ListModeleBasePTV[i].extid = Convert.ToString(FluxptvList[i].IdCommandeEntete);
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
                ListModeleBasePTV[i].volume = FluxptvList[i].CommandeTotaux.TotalVolume;
                //Total quantité
                ListModeleBasePTV[i].quantity_1 = FluxptvList[i].CommandeTotaux.TotalColis;
                ListModeleBasePTV[i].vehicleRequirements = cod_territoire_mappe;
                //text_1=typMarch
                ListModeleBasePTV[i].text_1 = TypMarch;
                //Text_10=agence
                ListModeleBasePTV[i].text_10 = agence;
                //Num_1=code territoire=specifiqueChaine2
                ListModeleBasePTV[i].num_1 = FluxptvList[i].SpecifiqueChaine2;
                //num_2=CA
                ListModeleBasePTV[i].num_2 = FluxptvList[i].CommandeTotauxMontant.ChiffreAffaire;

                //text_5=numero recipissé
                ListModeleBasePTV[i].text_5 = FluxptvList[i].NumeroRecepisse;
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
                //Pays en dur
                ListModeleBasePTV[i].country = "FRA";
                ListModeleBasePTV[i].extid1 = Depot;
                //Code postal de destinataire
                ListModeleBasePTV[i].postcode = FluxptvList[i].LocaliteDestinataire.CodePostal;
                //ville de destinataire
                ListModeleBasePTV[i].city = FluxptvList[i].LocaliteDestinataire.Nom;
                //class poids
                ListModeleBasePTV[i].handlingtime_class = ClassPoids;
                ListModeleBasePTV[i].serviceperiode = null;
                //date debut rdv
                ListModeleBasePTV[i].from =FluxptvList[i].THeureDebutRDV?.ToString("mmss");
                //date fin rdv
                ListModeleBasePTV[i].until =FluxptvList[i].THeureFinRDV?.ToString("mmss");  
                //DateLivraison format : AAAAMMJJ0000
                ListModeleBasePTV[i].until_weekday = FluxptvList[i].DateDebutLivraison.ToString("ddd").Replace(".", "");  
                //DateLivraison format : AAAAMMJJ0000
                ListModeleBasePTV[i].from_weekday = FluxptvList[i].DateDebutLivraison.ToString("ddd").Replace(".","");
                //1 En dur
                ListModeleBasePTV[i].Seq_Number = 1;

            }
            await Task.Delay(500);

            return (ModeleBasePTV.ListModeleBasePTV);
        }
    }
}