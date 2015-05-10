using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class Medewerker : Vrijwilliger
    {
        public Medewerker(string uname, string pswd, string naam) : base(uname, pswd, naam)
        {
        }

        public Medewerker()
        {
            
        }
        #region Item
        public void ItemToevoegen() { }
        public void ItemAanpassen() { }
        public void ItemVerwijderen() { }
        public void CategorieToekennenAan() { }
        #endregion
        #region Categories
        public void CategoriesAanpassen() { }
        public void CategoriesToevoegen() { }
        public void CategoriesVerwijderen() { }

        #endregion
        #region Leners
        public void LenerToevoegen() { }
        public void LenerAanpassen() { }
        public void LenerVerwijderen() { }

        #endregion
        #region Gebruikers

        public void GebruikerToevoegen() { }
        public void GebruikerAanpassen() { }
        public void GebruikerVerwijderen() { }
        #endregion
    }
}
