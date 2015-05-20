using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class GebruikerScreenViewModel
    {
        public IEnumerable<GebruikerViewModel> Gebruikers { get; set; }
        public User User { get; set;}

        public GebruikerScreenViewModel(IEnumerable<GebruikerViewModel> gebruiker, User user)
        {
            Gebruikers = gebruiker;
            User = user;
        }
    }
}