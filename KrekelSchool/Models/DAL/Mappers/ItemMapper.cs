﻿using System;
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
            //HasKey(i => i.Id);
            Map<Boek>(m => m.MapInheritedProperties().ToTable("Boeken"));
            Map<CD>(m => m.MapInheritedProperties().ToTable("Cds"));
            Map<DVD>(m => m.MapInheritedProperties().ToTable("Dvds"));
            Map<Verteltas>(m => m.MapInheritedProperties().ToTable("Verteltassen"));
            Map<Spel>(m => m.MapInheritedProperties().ToTable("Spellen"));
            
        }
    }
}