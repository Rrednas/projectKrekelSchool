using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class BoekMap:EntityTypeConfiguration<Boek>
    {
        public BoekMap()
        {
            Property(b => b.Isbn).IsOptional();
        }
    }
}