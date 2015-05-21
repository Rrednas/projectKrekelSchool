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
        public IQueryable<Categorie> FindAll()
        {
            return Context.Categories;
        }
        public Mediatheek GetMediatheek()
        {
            return Mediatheeks.First();
        }
        
        public void SaveChanges()
        {
            Context.SaveChanges();
            
        }
        
    }
}