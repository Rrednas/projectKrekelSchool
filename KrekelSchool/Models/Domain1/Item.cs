using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool
{
    public abstract class Item
    {
        private int id;

        private string naam;

        private int beschikbaar;

        private string beschrijving;

        protected Item(int id,string naam,int beschikbaar,string beschrijving)
        {
            Id = id;
            Naam = naam;
            Beschikbaar = beschikbaar;
            Beschrijving = beschrijving;
        }

        protected Item(string naam, int beschikbaar, string beschrijving)
        {
            Naam = naam;
            Beschikbaar = beschikbaar;
            Beschrijving = beschrijving;
        }
        public int Id { get; set; }

        public string Naam { get; set; }

        public int Beschikbaar { get; set; }

        public string Beschrijving { get; set; }
        public virtual ICollection<Boek> Boeken { get; private set; }
        public virtual ICollection<Cd> Cds { get; private set; }
        public virtual ICollection<Dvd> Dvds { get; private set; }
        public virtual ICollection<Spel> Spellen { get; private set; }
        public virtual ICollection<Verteltas> Verteltassen { get; private set; }
        //BOEK
        public Boek AddBoek(string isbn, string naam, string beschrijving, int beschikbaar)
        {
            if (isbn != null && Boeken.FirstOrDefault(b => b.Isbn == isbn) != null)
                throw new ArgumentException(string.Format("Het boek met {0} bestaat al!", isbn));
            if (naam != null && Boeken.FirstOrDefault(b => b.Naam == naam) != null)
                throw new ArgumentException(string.Format("Het boek met {0} bestaat al!", naam));

            Boek nieuwBoek = new Boek(naam, beschikbaar, beschrijving, isbn);
            Boeken.Add(nieuwBoek);
            return nieuwBoek;
        }

        public void DeleteBoek(Boek boek)
        {
            if (!Boeken.Contains(boek))
                throw new ArgumentException(string.Format("Het Boek {0} bestaat niet!", boek.Naam));
            Boeken.Remove(boek);
        }

        public Boek FindBoekByIsbn(string isbn)
        {
            return Boeken.FirstOrDefault(b => b.Isbn == isbn);
        }

        public Boek FindBoekByName(string naam)
        {
            return Boeken.FirstOrDefault(b => b.Naam == naam);
        }

        //CD
        public Cd AddCD(string naam,  int beschikbaar, string beschrijving, int size)
        {
            if (naam != null && Boeken.FirstOrDefault(c => c.Naam == naam) != null)
                throw new ArgumentException(string.Format("De CD met {0} bestaat al!", naam));

            Cd nieuwCD = new Cd(naam,  beschikbaar, beschrijving, size);
            Cds.Add(nieuwCD);
            return nieuwCD;
        }

        public void DeleteCD(Cd cd)
        {
            if (!Cds.Contains(cd))
                throw new ArgumentException(string.Format("De CD {0} bestaat niet!", cd.Naam));
            Cds.Remove(cd);
        }

        public Cd FindCDByName(string naam)
        {
            return Cds.FirstOrDefault(c => c.Naam == naam);
        }

        //DVD
        public Dvd AddDVD(string naam, int beschikbaar, string beschrijving, int size)
        {
            if (naam != null && Boeken.FirstOrDefault(d => d.Naam == naam) != null)
                throw new ArgumentException(string.Format("De DVD met {0} bestaat al!", naam));

            Dvd nieuwDVD = new Dvd(naam, beschikbaar, beschrijving, size);
            Dvds.Add(nieuwDVD);
            return nieuwDVD;
        }

        public void DeleteDVD(Dvd dvd)
        {
            if (!Dvds.Contains(dvd))
                throw new ArgumentException(string.Format("De DVD {0} bestaat niet!", dvd.Naam));
            Dvds.Remove(dvd);
        }

        public Dvd FindDVDByName(string naam)
        {
            return Dvds.FirstOrDefault(d => d.Naam == naam);
        }

        //Spel
        public Spel AddSpel(string naam, int beschikbaar, string beschrijving)
        {
            if (naam != null && Boeken.FirstOrDefault(s => s.Naam == naam) != null)
                throw new ArgumentException(string.Format("Het spel met {0} bestaat al!", naam));

            Spel nieuwSpel = new Spel(naam, beschikbaar, beschrijving);
            Spellen.Add(nieuwSpel);
            return nieuwSpel;
        }

        public void DeleteSpel(Spel spel)
        {
            if (!Spellen.Contains(spel))
                throw new ArgumentException(string.Format("Het spel {0} bestaat niet!", spel.Naam));
            Spellen.Remove(spel);
        }

        public Spel FindSpelByName(string naam)
        {
            return Spellen.FirstOrDefault(s => s.Naam == naam);
        }

        //Verteltassen
        public Verteltas AddVerteltas(string naam, int beschikbaar, string beschrijving)
        {
            if (naam != null && Boeken.FirstOrDefault(v => v.Naam == naam) != null)
                throw new ArgumentException(string.Format("De verteltas met {0} bestaat al!", naam));

            Verteltas nieuwVertaltas = new Verteltas(naam, beschikbaar, beschrijving);
            Verteltassen.Add(nieuwVertaltas);
            return nieuwVertaltas;
        }

        public void DeleteVerteltas(Verteltas verteltas)
        {
            if (!Verteltassen.Contains(verteltas))
                throw new ArgumentException(string.Format("De Verteltas {0} bestaat niet!", verteltas.Naam));
            Verteltassen.Remove(verteltas);
        }

        public Verteltas FindVerteltasByName(string naam)
        {
            return Verteltassen.FirstOrDefault(v => v.Naam == naam);
        }
    }
}
