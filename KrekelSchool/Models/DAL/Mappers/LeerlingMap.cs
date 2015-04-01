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
            ToTable("Leerlingen");
            
            HasKey(l => l.Id);
            HasMany(u => u.Uitleningen);
            Property(l => l.Postcode).HasMaxLength(4).IsFixedLength();

        }
    }
}