using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public class Uitlening
    {
        public Iitem Iitem{ get; set; }

        public DateTime beginDatum { get; set; }

        public DateTime eindDatum
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int ID { get; set; }

        public bool isTerug
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