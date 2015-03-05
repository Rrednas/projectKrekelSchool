using System;

namespace KrekelSchool.Models.Domain1
{
    public class Uitlening
    {

        public Uitlening()
        {
            
        }

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

        public KrekelSchool.Item Item
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