using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace KrekelSchool.Models.Domain1
{
    
    public sealed class Lener
    {
        public Collection<Uitlening> Uitleningen { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Straat { get; set; }
        public string HuisNr { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Email { get; set; }
        public string Klas { get; set; }

        public Lener() { }

        public Lener(string naam, string voornaam, string straat, string huisNr, string postcode, string gemeente, string email, string klas)
        {
            Naam = naam;
            Voornaam = voornaam;
            Straat = straat;
            HuisNr = huisNr;
            Postcode = postcode;
            Gemeente = gemeente;
            Email = email;
            Klas = klas;
        }
        
        #region methods

        public void KrijgLening(Uitlening uitl)
        {
            if (Uitleningen == null)
                Uitleningen = new Collection<Uitlening>();
            if (Uitleningen.Count >= 3)
                throw new ApplicationException("Lener mag niet meer dan 3 uitleningen hebben.");
                
            Uitleningen.Add(uitl);
        }
        #endregion
    }
}
