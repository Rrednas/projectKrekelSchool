using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class KrekelSchoolInitializer: DropCreateDatabaseAlways<KrekelSchoolContext>
    {
        protected override void Seed(KrekelSchoolContext context)
        {
            try
            {
                Lener boy = new Lener("kleinen","dude",1);
                context.Leerlingen.Add(boy);
                context.SaveChanges();
                
                context.Boeken.Add(new Boek("1", "boek" , true, "Beschrijving", 5, "12FZEF124TFAAZ", "Corneel", "kanaar" ));
                context.Boeken.Add(new Boek("2", "De Koning", false, "Boek over koning", 7,"ISbnNummer", "Corneel", "kanaar"));
                context.SaveChanges();
                context.Items.Add(new Boek("3", "bla", true, "lololol", 666,"grat e nummer", "Corneel", "kanaar"));
                context.SaveChanges();
                context.Items.Add(new Cd("4", "ceidei", false, "lolol", 55, 667));
                context.SaveChanges();
            }
            catch (Exception e)
            {
                
                throw(e);
            }
            context.SaveChanges();
            base.Seed(context); 
        }
    }
}