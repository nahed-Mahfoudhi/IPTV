using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPTV.Models
{
    public class FluxAOptimiser
    {
        public class Trafic
        {
            [JsonProperty("Code")]
            public string Code { get; set; }
        }

        public class Agence
        {
            [JsonProperty("CodeNumerique")]
            public string CodeNumerique { get; set; }
        }

        //Prestation
        public class Prestation
        {
            [JsonProperty("Code")]
            public string Code { get; set; }
        }


        //Pays
        public class Pays
        {
            [JsonProperty("Code")]
            public string Code { get; set; }
        }

        //Locatlité de destinataire
        public class LocaliteDestinataire
        {
            [JsonProperty("Pays")]
            public Pays Pays { get; set; }

            [JsonProperty("Nom")]
            public string Nom { get; set; }

            [JsonProperty("CodePostal")]
            public string CodePostal { get; set; }
        }

        //Commande totaux
        public class CommandeTotaux
        {
            [JsonProperty("TotalColis")]
            public int? TotalColis { get; set; }

            [JsonProperty("TotalPoids")]
            public double? TotalPoids { get; set; }

            [JsonProperty("TotalVolume")]
            public double? TotalVolume { get; set; }

            [JsonProperty("TotalTempsMontage")]
            public int TotalTempsMontage { get; set; }
        }

        //Montant commande totaux
        public class CommandeTotauxMontant
        {
            [JsonProperty("ChiffreAffaire")]
            public double? ChiffreAffaire { get; set; }

         
        }

        public class FluxPtv
        {
            //Id commande Entête/clé unique 
            [JsonProperty("IdCommandeEntete")]
            public int IdCommandeEntete { get; set; }

            //Numero recepissé

            [JsonProperty("NumeroRecepisse")]
            public int NumeroRecepisse { get; set; }

            //Trafic

            [JsonProperty("Trafic")]
            public Trafic Trafic { get; set; }

            //Agence

            [JsonProperty("Agence")]
            public Agence Agence { get; set; }

            //Prestation

            [JsonProperty("Prestation")]
            public Prestation Prestation { get; set; }


            //date debut livraison

            [JsonProperty("DateDebutLivraison")]
            public DateTime DateDebutLivraison { get; set; }

            //Nom de destinataire

            [JsonProperty("NomDestinataire")]
            public string NomDestinataire { get; set; }

            //Adresse  de destinataire

            [JsonProperty("Adresse1Destinataire")]
            public string Adresse1Destinataire { get; set; }

            //Adresse 2 de destinataire
            [JsonProperty("Adresse2Destinataire")]
            public string Adresse2Destinataire { get; set; }

            //Adresse 3 de destinataire

            [JsonProperty("Adresse3Destinataire")]
            public string Adresse3Destinataire { get; set; }

            //Localité de destinataire

            [JsonProperty("LocaliteDestinataire")]
            public LocaliteDestinataire LocaliteDestinataire { get; set; }

            //Commande totaux

            [JsonProperty("CommandeTotaux")]
            public CommandeTotaux CommandeTotaux { get; set; }

            //Montant commande totaux

            [JsonProperty("CommandeTotauxMontant")]
            public CommandeTotauxMontant CommandeTotauxMontant { get; set; }

            [JsonProperty("SpecifiqueChaine2")]
            public string SpecifiqueChaine2 { get; set; }

            [JsonProperty("SpecifiqueChaine3")]
            public string SpecifiqueChaine3 { get; set; }

            [JsonProperty("THeureDebutRDV")]
            public DateTime? THeureDebutRDV { get; set; }

            [JsonProperty("THeureFinRDV")]
            public DateTime? THeureFinRDV { get; set; }

            [JsonProperty("HeureDebutRDV")]
            public int? HeureDebutRDV { get; set; }

            [JsonProperty("HeureFinRDV")]
            public int? HeureFinRDV { get; set; }

            public FluxPtv()
            {
                CommandeTotaux = new CommandeTotaux();
                CommandeTotauxMontant = new CommandeTotauxMontant();

                LocaliteDestinataire = new LocaliteDestinataire();

            }
        }

    }
}