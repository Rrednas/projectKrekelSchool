using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class MediatheekMap: EntityTypeConfiguration<Mediatheek>
    {
        public MediatheekMap()
        {
            HasKey(m => m.Id);
            HasMany(b => b.Boeks);
            HasMany(c => c.Cds);
        }
    }
}