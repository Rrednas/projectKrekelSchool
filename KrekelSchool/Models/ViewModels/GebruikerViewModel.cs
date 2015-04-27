using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class GebruikerViewModel
    {
        public string Uname { get; set; }
        public string Pswd { get; set; }
        public string Naam { get; set; }

        public int Id { get; set; }

        public GebruikerViewModel()
        {
            
        }

        public GebruikerViewModel(Gebruiker gebruiker)
        {
            Uname = gebruiker.Uname;
            Pswd = gebruiker.Pswd;
            Naam = gebruiker.Naam;
            Id = gebruiker.Id;
        }
    }
}