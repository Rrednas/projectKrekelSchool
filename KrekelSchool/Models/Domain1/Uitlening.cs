using System;

namespace KrekelSchool.Models.Domain1
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