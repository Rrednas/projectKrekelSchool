using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class KrekelSchoolContext: DbContext
    {
        public KrekelSchoolContext():base("projecten2")
        {
            
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Boek> Boeken { get; set; }
        public virtual DbSet<CD> Cds { get; set; }
        public virtual DbSet<DVD> Dvds { get; set; }
        public virtual DbSet<Spel> Spellen { get; set; }
        public virtual DbSet<Verteltas> Verteltassen { get; set; }

        public virtual DbSet<Leerling> Leerlingen { get; set; }
        public virtual DbSet< Uitlening> Uitleningen{ get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Ignore<Iitem>();
            base.OnModelCreating(modelBuilder);


        }
    }
}