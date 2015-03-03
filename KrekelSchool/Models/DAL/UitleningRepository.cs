using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class UitleningRepository : IUitleningenRepository
    {
        private KrekelSchoolContext Context;
        private DbSet<Uitlening> Uitleningen;

        public UitleningRepository(KrekelSchoolContext context)
        {
            Context = context;
            Uitleningen = Context.Uitleningen;
        }
        public Uitlening FindBy(int itemId)
        {
            return Uitleningen.Find(itemId);
        }

       

        public IQueryable<Uitlening> FindAll()
        {
            return Uitleningen;
        }
        

        public void Add(Uitlening uitlening)
        {
            Uitleningen.Add(uitlening);
        }

        public void Delete(Uitlening uitlening)
        {
            Uitleningen.Remove(uitlening);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}