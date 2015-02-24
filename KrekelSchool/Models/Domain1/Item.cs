using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public abstract class Item
    {

        public int Id
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Naam
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Beschikbaar
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Beschrijving
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
