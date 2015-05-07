using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Uitlening
    {
        #region fields
        public DateTime eindDatum;        
        #endregion

        public Uitlening()
        {
            
        }

        public Uitlening(bool isterug ,DateTime van , DateTime tot , Item item, Lener lener)
        {
            Retour = isterug;
            Begindatum = van;            
            Einddatum = tot;
            Item = item;
            Lener = lener;
        }
        public Uitlening(Item item, Lener lener)
        {
            Item = item;
            Lener = lener;
            Begindatum = DateTime.Today.Date;
            Einddatum = Begindatum.AddDays(7);
            //if (Item.Leeftijd >= 12) EindDatum = EindDatum.AddDays(7);
            Retour = false;
        }

        
        public DateTime Begindatum { get; set; }

        
        public DateTime Einddatum
        {
            get { return eindDatum; }
            set
            {
                if(value <= DateTime.Today.Date)
                    throw new ArgumentException("Eind datum vroeger dan begin datum");
                eindDatum = value;
                
            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public bool Retour{ get; set; }

        public virtual Item Item { get; set; }
        //{
        //    get { return item; }
        //    set
        //    {
        //        if(value==null)
        //            throw new ArgumentException("Ongeldig Item");
        //        item = value;
        //    }
        //}

        public virtual Lener Lener { get; set; }
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
            if (Retour)
            {
                throw new ApplicationException("Deze uitlening was al teruggebracht");
            }
            Retour = true;
        }
        #endregion
    }
}