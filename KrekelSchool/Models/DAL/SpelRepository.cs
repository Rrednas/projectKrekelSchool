using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class SpelRepository : IspelRepository
    {
        private KrekelSchoolContext Context;
        public DbSet<Spel> Spellen;

        public SpelRepository(KrekelSchoolContext context)
        {
            Context = context;
            Spellen = context.Spellen;
        }

        public Spel FindBy(int itemId)
        {
            return Spellen.Find(itemId);
        }

        public IQueryable<Spel> FindAll()
        {
            return Spellen;
        }

        public void Add(Spel spel)
        {
            Context.Spellen.Add(spel);
        }

        public void Delete(Spel spel)
        {
            Context.Spellen.Remove(spel);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}