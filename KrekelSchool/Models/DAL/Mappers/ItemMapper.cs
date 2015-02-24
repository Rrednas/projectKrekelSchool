using System;
using System.Collections.Generic;
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
            Map<Boek>(m => m.MapInheritedProperties().ToTable("Boeken"));
            Map<CD>(m => m.MapInheritedProperties().ToTable("CD's"));
            Map<DVD>(m => m.MapInheritedProperties().ToTable("DvD's"));
            Map<Verteltas>(m => m.MapInheritedProperties().ToTable("verteltassen"));
            Map<Spel>(m => m.MapInheritedProperties().ToTable("Spellen"));
            
        }
    }
}