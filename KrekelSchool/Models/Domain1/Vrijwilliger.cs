using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class Vrijwilliger : Gebruiker
    {
        public Vrijwilliger (string uname, string pswd, string naam, int id) : base (uname, pswd, naam, id)
        {
        }
        public void CheckIn(Item i , Lener l , DateTime tot)
        {
          //  Mediatheek.VoegUitleningToe(l,tot,i);
        }

        public void CheckOut()
        {
            throw new System.NotImplementedException();
        }

        public void UitleningAanpassen()
        {
            throw new System.NotImplementedException();
        }

        public void LogOut()
        {
            throw new System.NotImplementedException();
        }
    }
}
