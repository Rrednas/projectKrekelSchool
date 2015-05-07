using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class UitleningViewModel
    {
        public UitleningViewModel(Uitlening uitlening)
        {
            Item = uitlening.Item;
            Lener = uitlening.Lener;
            BeginDatum = uitlening.Begindatum;
            EindDatum = uitlening.Einddatum;
            IsTerug = uitlening.Retour;
        }

        [Display(Name = "Begin datum")]
        [DataType(DataType.Date)]
        public DateTime BeginDatum { get; set; }

        [Display(Name = "Eind datum")]
        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Terruggebracht?")]
        public bool IsTerug { get; set; }
        public Item Item { get; set; }
        //public ItemViewModel Item { get; set; }
        public Lener Lener { get; set; }
        //public LeerlingViewModel Lener { get; set; }

    }

    public class UitleningScreenViewModel
    {
        public IEnumerable<UitleningViewModel> Uitleningen { get; set; }

        public UitleningScreenViewModel(IEnumerable<UitleningViewModel> obj)
        {
            Uitleningen = obj;
        }
    }
}