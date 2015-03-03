namespace KrekelSchool.Models.Domain1
{
    public class Spel : KrekelSchool.Item
    {
        public Spel(string id, string naam, int beschikbaar, string beschrijving,  int leeftijd) : base(id, naam, beschikbaar, beschrijving, leeftijd)
        {
        }

        public Spel():base()
        {
            
        }
    }
}
