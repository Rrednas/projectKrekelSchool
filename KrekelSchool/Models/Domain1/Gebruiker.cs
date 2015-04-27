using System;
using System.Collections;

namespace KrekelSchool.Models.Domain1
{
    public class Gebruiker
    {


        public Gebruiker(string uname, string pswd, string naam, int id)
        {
            Uname = uname;
            Pswd = pswd;
            Naam = naam;
            Id = id;
        }

       

        private Mediatheek Mediatheek;
        public Gebruiker()
        {
            Mediatheek = new Mediatheek();
        }
        
        public ICollection SearchItem(String zoekstring)
        {
            return null;
        }

        public void LogIn() { }

        public string Uname { get; set; }
        public string Pswd { get; set; }
        public string Naam { get; set; }
        public int Id { get; set; }


    }
}
