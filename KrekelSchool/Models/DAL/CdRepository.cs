using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class CdRepository : IcdRepository
    {
        private KrekelSchoolContext Context;
        public DbSet<CD> Cds;

        public CdRepository(KrekelSchoolContext context)
        {
            Context = context;
            Cds = context.Cds;
        }

        public CD FindBy(int itemId)
        {
            return Cds.Find(itemId);
        }

        public IQueryable<CD> FindAll()
        {
            return Cds;
        }

        public void Add(CD cd)
        {
            Context.Cds.Add(cd);
        }
       
        public void Delete(CD cd)
        {
            Context.Cds.Remove(cd);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}