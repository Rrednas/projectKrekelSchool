using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class MediatheekRepository:IMediatheekRepository
    {
        private KrekelSchoolContext Context;
        
        private DbSet<Mediatheek> Mediatheeks;
        public MediatheekRepository(KrekelSchoolContext context)
        {
            Context = context;
            Mediatheeks = context.Mediatheeks;
            

        }
        public Mediatheek GetMediatheek()
        {
            return Mediatheeks.Include(m => m.Boeks).First();
        }
        
        public void SaveChanges()
        {
            Context.SaveChanges();
            
        }
        
    }
}