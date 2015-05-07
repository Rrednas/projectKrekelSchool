using System;
using System.Collections;

namespace KrekelSchool.Models.Domain1
{
    public class Gebruiker
    {


        public Gebruiker(string uname, string pswd, string naam)
        {
            Uname = uname;
            Pswd = pswd;
            Naam = naam;
            
        }



        public virtual Mediatheek Mediatheek { get; set; }
        public Gebruiker()
        {
            
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
