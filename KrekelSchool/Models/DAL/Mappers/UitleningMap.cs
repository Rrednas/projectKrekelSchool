using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class UitleningMap:EntityTypeConfiguration<Uitlening>
    {
        public UitleningMap()
        {
            ToTable("Uitleningen");
            HasKey(u => u.Id);
            
        }
    }
}