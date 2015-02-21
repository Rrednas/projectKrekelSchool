using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    
    public class Leerling
    {
        public Leerling() { }
        public Leerling(string naam, string voornaam, int id)
        {
            Naam = naam;
            Voornaam = voornaam;
            ID = id;
        }
        public virtual Collection<Uitlening> Uitleningen { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int ID { get; set; }
        }
}
