using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPTV.modeles
{
    public class ModeleBasePTV
    {
            //reference
            public decimal reference { get; set; }
            //context
            public string Context { get; set; }
            //object-type
            public string object_type { get; set; }

            public string extid { get; set; }

            public string extid1 { get; set; }
            public string extid2 { get; set; }
            public string action_code { get; set; }

            public decimal process_code { get; set; }

            public string creation_time { get; set; }

            public string order_type { get; set; }

            public string taskfields { get; set; }

            //total poids
            public double? weight { get; set; }
            //total volume
            public double? volume { get; set; }
           //Total colis
            public int? quantity_1 { get; set; }
         
            public string vehicleRequirements { get; set; }

            public string text_1 { get; set; }
            public string text_10 { get; set; }
            public double? num_1 { get; set; }
            public double? num_2 { get; set; }
            public int text_5 { get; set; }
            public string action { get; set; }
            public byte onetime1 { get; set; }
            public byte onetime { get; set; }
            public string name { get; set; }
            public string street { get; set; }

            //pays
            public string country { get; set; }

            public string postcode { get; set; }

            //ville
            public string city { get; set; }
            public string earliest_datetime { get; set; }
            public string latest_datetime { get; set; }
            public int handlingtime_class { get; set; }
            public int? serviceperiode { get; set; }
            public int Seq_Number { get; set; }

            public string from_weekday { get; set; }
            public string until_weekday { get; set; }

            public string from { get; set; }
            public string until { get; set; }
            public string libel2 { get; set; }

            public string idCommandeEntete { get; set; }

            public string numeroRecepisse { get; set; }


    }

        public class ModelesBasePTV
        {
            public List<ModeleBasePTV> ListModeleBasePTV { get; set; }


        }
    
}