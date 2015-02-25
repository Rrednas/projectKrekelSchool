

namespace KrekelSchool.Models.Domain1
{
    public class Dvd : KrekelSchool.Item
    {
        public int Size { get; set; }
        public Dvd(int id, string naam, int beschikbaar, string beschrijving) : base(id, naam, beschikbaar, beschrijving)
        {
        }

        public Dvd(string naam, int beschikbaar, string beschrijving, int size)
            : base(naam, beschikbaar, beschrijving)
        {
            Size = size;
        }
    }
}
