using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class VerteltasRepository : IverteltasRepository
    {
        private KrekelSchoolContext Context;
        public DbSet<Verteltas> Verteltasen;

        public VerteltasRepository(KrekelSchoolContext context)
        {
            Context = context;
        }

        public Verteltas FindBy(int itemId)
        {
            return Verteltasen.Find(itemId);
        }

        public IQueryable<Verteltas> FindAll()
        {
            return Verteltasen;
        }

        public void Add(Verteltas vt)
        {
            Context.Verteltassen.Add(vt);
        }

        public void Delete(Verteltas vt)
        {
            Context.Verteltassen.Remove(vt);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}