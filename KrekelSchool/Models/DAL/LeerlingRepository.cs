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
        private DbSet<Leerling> Leerlingen;

        public LeerlingRepository(KrekelSchoolContext context)
        {
            Context = context;
            Leerlingen = Context.Leerlingen;
        }
 
        public Leerling FindBy(int leerlingId)
        {
            return Leerlingen.Find(leerlingId);
        }

        public IQueryable<Leerling> FindAll()
        {
            return Leerlingen;
        }

        public void Add(Leerling leerling)
        {
            Leerlingen.Add(leerling);
        }

        public void Delete(Leerling leerling)
        {
            Leerlingen.Remove(leerling);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}