using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPTV.Models
{
    public class Retour
    {
        public string IdCommande { get; set; }
        public string CodeAgence { get; set; }
        public string CodeDirection { get; set; }
        public string Action { get; set; }
        public string Ordre { get; set; }
        public string DateHeureDebutCommande { get; set; }
        public string DateHeureArriveeClient { get; set; }
        public string DateHeureDepartClient { get; set; }
    }
}