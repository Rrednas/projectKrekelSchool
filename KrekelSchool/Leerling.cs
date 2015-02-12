using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class Leerling
    {
        public Uitlening GetUitlening()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Gebruiker
    {
        public Uitlening AddUitlening()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUitlening()
        {
            throw new System.NotImplementedException();
        }

        public void EditUitlening()
        {
            throw new System.NotImplementedException();
        }

        public void GetItems()
        {
            throw new System.NotImplementedException();
        }

        public void AddGebruiker()
        {
            throw new System.NotImplementedException();
        }

        public void AddItem()
        {
            throw new System.NotImplementedException();
        }

        public void EditGebruiker()
        {
            throw new System.NotImplementedException();
        }

        public void EditItem()
        {
            throw new System.NotImplementedException();
        }

        public void GetGebruikers()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveGebruiker()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveItem()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Uitlening
    {
        public void GetItem()
        {
            throw new System.NotImplementedException();
        }

        public void GetLeerling()
        {
            throw new System.NotImplementedException();
        }

        public void BerekenBoete()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Boek : Item
    {
    }

    public class Spel : Item
    {
    }

    public class Verteltas : Item
    {
    }

    public class CD : Item
    {
    }

    public class Vrijwilliger
    {
    }

    public class Medewerker
    {
    }
}
