using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class SpelMap : EntityTypeConfiguration<Spel>
    {
        public SpelMap()
        {
            HasKey(s => s.Id);
        }
    }
}