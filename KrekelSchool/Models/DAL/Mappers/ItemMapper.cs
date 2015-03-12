using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class ItemMapper:EntityTypeConfiguration<Item>
    {
        public ItemMapper()
        {
            //Property(i => i.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(c => c.Id);
            Map<Boek>(m => m.MapInheritedProperties().ToTable("Boeken"));
            Map<Cd>(m => m.MapInheritedProperties().ToTable("Cds"));
            Map<Dvd>(m => m.MapInheritedProperties().ToTable("Dvds"));
            Map<Verteltas>(m => m.MapInheritedProperties().ToTable("Verteltassen"));
            Map<Spel>(m => m.MapInheritedProperties().ToTable("Spellen"));
            
        }
    }
}