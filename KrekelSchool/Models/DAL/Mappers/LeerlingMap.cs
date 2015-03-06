using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class LeerlingMap : EntityTypeConfiguration<Lener>
    {
        public LeerlingMap()
        {
            this.ToTable("Leerlingen");
            
            this.HasKey(l => l.Id);
            HasMany(u => u.Uitleningen);
            
        }
    }
}