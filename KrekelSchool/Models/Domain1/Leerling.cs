using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    
    public class Lener
    {
        public Lener() { }
        public Lener(string naam, string voornaam, int id)
        {
            Naam = naam;
            Voornaam = voornaam;
            Id = id;
        }
        public virtual Collection<Uitlening> Uitleningen { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int Id { get; set; }
        #region methods

        public void KrijgLening(Uitlening uitl)
        {
            if (Uitleningen.Count >= 3)
            {
                throw new ApplicationException("Lener mag niet meer dan 3 uitleningen hebben.");
            }
            
            Uitleningen.Add(uitl);
       
        }

        public void CheckLeningUit(Uitlening uitl)
        {
            Uitleningen.Remove(uitl);
        }
        #endregion
    }
}
