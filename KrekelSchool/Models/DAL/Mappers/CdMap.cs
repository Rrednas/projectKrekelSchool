using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class CdMap:EntityTypeConfiguration<Cd>
    {
        public CdMap()
        {
           // HasKey(c => c.Id);
            Property(c => c.Size).IsOptional();
        }
    }
}