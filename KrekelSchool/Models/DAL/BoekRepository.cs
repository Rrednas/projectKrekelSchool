using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class BoekRepository : IboekRepository
    {
        private KrekelSchoolContext Context;
        public DbSet<Boek> Boeken;

        public BoekRepository(KrekelSchoolContext context)
        {
            Context = context;
            Boeken = context.Boeken;
        }

        public Boek FindBy(int itemId)
        {
            return Boeken.Find(itemId);
        }

        public IQueryable<Boek> FindAll()
        {
            return Boeken;
        }

        public void Add(Boek boek)
        {
            Context.Boeken.Add(boek);
        }

        public void Delete(Boek boek)
        {
            Context.Boeken.Remove(boek);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}