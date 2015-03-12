using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class LenerRepository : ILenerRepository
    {
        private KrekelSchoolContext Context;
        private DbSet<Lener> Leners;

        public LenerRepository(KrekelSchoolContext context)
        {
            Context = context;
            Leners = Context.Leerlingen;
        }
 
        public Lener FindBy(int leerlingId)
        {
            return Leners.Find(leerlingId);
        }

        public IQueryable<Lener> FindAll()
        {
            return Leners;
        }

        public void Add(Lener leerling)
        {
            Leners.Add(leerling);
        }

        public void Delete(Lener leerling)
        {
            Leners.Remove(leerling);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}