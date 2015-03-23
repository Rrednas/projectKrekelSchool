using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    
    public class Lener
    {
        public virtual Collection<Uitlening> Uitleningen { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Lener() { }

        public Lener(string naam, string voornaam)
        {
            Naam = naam;
            Voornaam = voornaam;
        }
        
        #region methods

        public void KrijgLening(Uitlening uitl)
        {
            if (Uitleningen.Count >= 3)
            {
                throw new ApplicationException("Lener mag niet meer dan 3 uitleningen hebben.");
            }
                Uitleningen.Add(uitl);
        }
        #endregion
    }
}
