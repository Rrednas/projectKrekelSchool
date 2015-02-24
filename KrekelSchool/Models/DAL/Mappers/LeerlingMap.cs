using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class LeerlingMap : EntityTypeConfiguration<Leerling>
    {
        public LeerlingMap()
        {
            this.ToTable("Leerlingen");

            
            this.HasKey(l => l.ID);
            HasMany(u => u.Uitleningen);
            
        }
    }
}