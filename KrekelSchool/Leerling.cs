using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public class Leerling
    {
        public string Naam
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public Uitlening GetUitlening()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Gebruiker
    {
        public int GebruikerId
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Voornaam
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Achternaam
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime Geboortedatum
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public void AddUitlening()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUitlening()
        {
            throw new System.NotImplementedException();
        }

        public void EditUitlening()
        {
            throw new System.NotImplementedException();
        }

        public List<Item> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public void AddGebruiker()
        {
            throw new System.NotImplementedException();
        }

        public void AddItem()
        {
            throw new System.NotImplementedException();
        }

        public void EditGebruiker()
        {
            throw new System.NotImplementedException();
        }

        public void EditItem()
        {
            throw new System.NotImplementedException();
        }

        public List<Gebruiker> GetGebruikers()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveGebruiker()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveItem()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Uitlening
    {
        public void UitleningId
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int UitgeleendAan
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Startdatum
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Einddatum
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int UitgeleendItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Item GetItem()
        {
            throw new System.NotImplementedException();
        }

        public Leerling GetLeerling()
        {
            throw new System.NotImplementedException();
        }

        public int BerekenBoete()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Boek : Item
    {
        public String ISBN
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Titel
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public String Auteur
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Jaar
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Taal
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Uitgeverij
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Leeftijd
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Thema
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Locatie
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }

    public class Spel : Item
    {
        public int SpelId
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Naam
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string AantalSpelers
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Leeftijd
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public String Locatie
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }

    public class Verteltas : Item
    {
        public int TasId
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Item> Inhoud
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Locatie
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }

    public class CD : Item
    {
        public int CDId
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Naam
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public String Artiest
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int AantalNummers
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Locatie
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Genre
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }

    public class Vrijwilliger
    {
    }

    public class Medewerker
    {
    }
}
