using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private KrekelSchoolContext Context;
        private DbSet<Gebruiker> gebruikers;
        public GebruikerRepository(KrekelSchoolContext context)
        {
            Context = context;
            gebruikers = Context.Gebruikers;
        }
        public Gebruiker GetGebruiker()
        {
            return gebruikers.First();
        }

        public void GebruikerToevoegen(Gebruiker gebruiker)
        {
            gebruikers.Add(gebruiker);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }

    
}