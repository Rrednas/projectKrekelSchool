namespace KrekelSchool.Models.Domain1
{
    public class DVD : Iitem
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public bool Beschikbaar { get; set; }

        int Iitem.Beschikbaar { get; set; }

        public Categorie Categorie { get; set; }
    }
}
