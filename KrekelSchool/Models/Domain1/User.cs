using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrekelSchool.Models.Domain1
{
    public class User
    {
        public Gebruiker Gebruiker { get; set; }

        public User(Gebruiker gebruiker)
        {
            Gebruiker = gebruiker;
        }

        public void LogInUser(Gebruiker vrijwilliger)
        {
            Gebruiker = vrijwilliger;
        }

    }
}