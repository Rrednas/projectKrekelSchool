using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class CategorieMap:EntityTypeConfiguration<Categorie>
    {
        public CategorieMap()
        {
          //  HasOptional(i => i.Items).WithMany();
            ToTable("Thema");
        }
    }
}