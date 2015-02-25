using System.Collections.ObjectModel;

namespace KrekelSchool.Models.Domain1
{
    public class Verteltas : KrekelSchool.Item
    {
        public Verteltas(int id, string naam, int beschikbaar, string beschrijving) : base(id, naam, beschikbaar, beschrijving)
        {
        }

        public Verteltas(string naam, int beschikbaar, string beschrijving) : base(naam,beschikbaar,beschrijving){}
            
        
    }
}
