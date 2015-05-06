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
            Item = new ItemViewModel(uitlening.Item);
            Lener = new LeerlingViewModel(uitlening.Lener);
            BeginDatum = uitlening.BeginDatum;
            EindDatum = uitlening.EindDatum;
            IsTerug = uitlening.IsTerug;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public Item Item { get; set; }
        public ItemViewModel Item { get; set; }
        //public Lener Lener { get; set; }
        public LeerlingViewModel Lener { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public bool IsTerug { get; set; }
    }

    public class UitleningScreenViewModel
    {
        public IEnumerable<UitleningViewModel> Uitleningen { get; set; }
        public IEnumerable<ItemViewModel> Items { get; set; }
        public IEnumerable<LeerlingViewModel> Leners { get; set; }

        public UitleningScreenViewModel(IEnumerable<UitleningViewModel> obj, IEnumerable<ItemViewModel> item, IEnumerable<LeerlingViewModel> lener  )
        {
            Uitleningen = obj;
            Items = item;
            Leners = lener;
        }
    }
}