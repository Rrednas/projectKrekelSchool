using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class DvdRepository : IdvdRepository
    {
        private KrekelSchoolContext Context;
        public DbSet<DVD> Dvds;

        public DvdRepository(KrekelSchoolContext context)
        {
            Context = context;
            Dvds = context.Dvds;
        }

        public DVD FindBy(int itemId)
        {
            return Dvds.Find(itemId);
        }

        public IQueryable<DVD> FindAll()
        {
            return Dvds;
        }

        public void Add(DVD dvd)
        {
            Context.Dvds.Add(dvd);
        }

        public void Delete(DVD dvd)
        {
            Context.Dvds.Remove(dvd);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}