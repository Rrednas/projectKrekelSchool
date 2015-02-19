using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class KrekelSchoolContext:DbContext
    {
        public KrekelSchoolContext():base("KrekelSchool")
        {
            
        }

        public DbSet<Iitem> Iitems { get; set; }
        public DbSet<Leerling> Leerlingen { get; set; }
        public DbSet<Uitlening> Uitlenings { get; set; }
        public DbSet<Categorie> Categories { get; set; } 
    }
}