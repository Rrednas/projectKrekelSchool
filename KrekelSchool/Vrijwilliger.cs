using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class Vrijwilliger : Gebruiker
    {

        #region Properties

        public string Username { get; set; }
        public string Pswd { get; set; }
        public string Naam { get; set; }
        public int Id { get; set; }


        #endregion

        public Vrijwilliger(string uname , string pswd ,string naam , int id):base()
        {
            
        }

        #region Uitlening

        public void CheckIn()
        {
        }

        public void CheckOut()
        {
        }

        public void UitleningAanpassen()
        {
        }

        #endregion

        public void LogOut() { }

    }
}
