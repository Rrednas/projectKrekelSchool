using System;
using System.Collections;

namespace KrekelSchool.Models.Domain1
{
    public class Gebruiker
    {
        private Mediatheek Mediatheek;
        public Gebruiker()
        {
            Mediatheek=new Mediatheek();
        }
        
        public ICollection SearchItem(String zoekstring)
        {
            return null;
        }

        public void LogIn() { }




    }
}
