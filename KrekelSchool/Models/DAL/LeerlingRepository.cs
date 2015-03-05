using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class LeerlingRepository : ILeerlingrepository
    {
        private KrekelSchoolContext Context;
        private DbSet<Lener> Leerlingen;

        public LeerlingRepository(KrekelSchoolContext context)
        {
            Context = context;
            Leerlingen = Context.Leerlingen;
        }
 
        public Lener FindBy(int leerlingId)
        {
            return Leerlingen.Find(leerlingId);
        }

        public IQueryable<Lener> FindAll()
        {
            return Leerlingen;
        }

        public void Add(Lener leerling)
        {
            Leerlingen.Add(leerling);
        }

        public void Delete(Lener leerling)
        {
            Leerlingen.Remove(leerling);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}