namespace KrekelSchool.Models.Domain1
{
    public class Spel : KrekelSchool.Item
    {
        public Spel(string id, string naam, int beschikbaar, string beschrijving) : base(id, naam, beschikbaar, beschrijving)
        {
        }

        public Spel():base()
        {
            
        }
    }
}
