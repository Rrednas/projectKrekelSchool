using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
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
        public virtual DbSet<Cd> Cds { get; set; }
        public virtual DbSet<Dvd> Dvds { get; set; }
        public virtual DbSet<Spel> Spellen { get; set; }
        public virtual DbSet<Verteltas> Verteltassen { get; set; }

        public virtual DbSet<Leerling> Leerlingen { get; set; }
        public virtual DbSet< Uitlening> Uitleningen{ get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Ignore<Iitem>();
        }

        public static KrekelSchoolContext Create()
        {
            return DependencyResolver.Current.GetService<KrekelSchoolContext>();
        }
    }
}