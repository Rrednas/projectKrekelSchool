namespace KrekelSchool.Models.Domain1
{
    public class CD : KrekelSchool.Item
    {
        public int Size { get; set; }

        public CD(string id, string naam, int beschikbaar, string beschrijving, int leeftijd,  int size)
            : base(id, naam, beschikbaar, beschrijving, leeftijd)
        {
            Size = size;
        }

        public CD()
        {
            
        }
    }
}
