using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KrekelSchool.Models.Domain1
{
    public interface IGebruikerRepository
    {
        Gebruiker GetGebruiker();
        void GebruikerToevoegen(Gebruiker gebruiker);
        void SaveChanges();
    }
}