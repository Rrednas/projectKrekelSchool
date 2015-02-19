namespace KrekelSchool.Models.Domain1
{
    public interface Iitem
    {
        int ID
        {
            get;
            set;
        }

        string Naam
        {
            get;
            set;
        }

        string Beschrijving
        {
            get;
            set;
        }

        int Beschikbaar
        {
            get;
            set;
        }

        Categorie Categorie
        {
            get;
            set;
        }
    }
}