using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Uitlening(bool isterug ,DateTime van , DateTime tot , Item item, Lener lener)
        {
            IsTerug = isterug;
            BeginDatum = van;
            EindDatum = tot;
            Item = item;
            Lener = lener;
        }
        public Uitlening(Item item, Lener lener)
        {
            Item = item;
            Lener = lener;
            BeginDatum = DateTime.Today;
            EindDatum = BeginDatum.AddDays(7);
            //if (Item.Leeftijd >= 12) EindDatum = EindDatum.AddDays(7);
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsTerug
        {
            get; set; }

        public Item Item
        {
            get { return item; }
            set
            {
                if(value==null)
                    throw new ArgumentException("Ongeldig Item");
                item = value;
            }
        }

        public Lener Lener { get; set; }
        //{
        //    get { return lener; }
        //    set
        //    {
        //        if (value == null)
        //            throw new ArgumentException("Ongeldige Lener");
        //        lener = value;
        //    }
        //}
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