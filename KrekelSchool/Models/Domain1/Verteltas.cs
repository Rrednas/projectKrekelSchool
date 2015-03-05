using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KrekelSchool.Models.Domain1
{
    public class Verteltas : KrekelSchool.Item
    {
        public Verteltas(string id, string naam, int beschikbaar, string beschrijving) : base(id, naam, beschikbaar, beschrijving)
        {
        }
        public ICollection<Item> Items { get; set; }
    }
}
