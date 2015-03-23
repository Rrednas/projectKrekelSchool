using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;
using Microsoft.Owin.Security.DataHandler;

namespace KrekelSchool.Models.DAL.Mappers
{
    public class BoekMap:EntityTypeConfiguration<Boek>
    {
        public BoekMap()
        {
            HasKey(b => b.Id);
            Property(b => b.Naam).IsRequired();
            Property(b => b.Leeftijd).IsRequired();
            Property(b => b.Isbn).IsOptional();
        }
    }
}