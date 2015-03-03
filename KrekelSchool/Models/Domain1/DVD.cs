namespace KrekelSchool.Models.Domain1
{
    public class Dvd : KrekelSchool.Item
    {
        public int Size { get; set; }

        public Dvd(string id, string naam, int beschikbaar, string beschrijving, int leeftijd, int size)
            : base(id, naam, beschikbaar, beschrijving,leeftijd)
        {
            Size = size;
        }

        public Dvd()
        {
            
        }
    }
}
