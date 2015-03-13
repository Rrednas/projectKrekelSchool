using System;

namespace KrekelSchool.Models.Domain1
{
    public class Uitlening
    {
        #region fields
        public DateTime eindDatum;
        public Item item;
        #endregion

        public Uitlening()
        {
            
        }

        public Uitlening(int id , bool isterug ,DateTime van , DateTime tot , Item item)
        {
            Id = id;
            IsTerug = isterug;
            BeginDatum = van;
            EindDatum = tot;
            Item = item;
        }
        public Uitlening(Item item , DateTime eind  )
        {
            Item = item;
            BeginDatum = DateTime.Today;
            EindDatum = eind;
            IsTerug = false;
        }

        public DateTime BeginDatum { get; set; }

        public DateTime EindDatum
        {
            get { return eindDatum; }
            set
            {
                if(value <= DateTime.Today)
                    throw new ArgumentException("Eind datum vroeger dan begin datum");
                eindDatum = value;
            }
        }

        public int Id { get; set; }

        public bool IsTerug
        {
            get; set; }

        public KrekelSchool.Item Item
        {
            get { return item; }
            set
            {
                if(value==null)
                    throw new ArgumentException("Ongeldig Item");
                if(!Item.Beschikbaar)
                    throw new ArgumentException("Item niet beschikbaar");
                item = value;
            }
        }
        #region methods 

        public void WordTerugGebracht()
        {
            if (IsTerug)
            {
                throw new ApplicationException("Deze uitlening was al teruggebracht");
            }
            IsTerug = true;
        }
        #endregion
    }
}