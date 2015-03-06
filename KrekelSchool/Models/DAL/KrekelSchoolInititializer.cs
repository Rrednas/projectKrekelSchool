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
                Leerling boy = new Leerling("kleinen","dude",1);
                context.Leerlingen.Add(boy);
                context.SaveChanges();

                context.Boeken.Add(new Boek("1", "boek", 2, "Beschrijving van de koning en zijn paard, daar reed hij op tot hij de princes tegen kwam en haar hoofd eraf nam",12, "9789027439642", "de lul", "vogelmans"));
                context.Boeken.Add(new Boek("2", "De Koning", 2, "Boek over koning", 5, "9789027439642", "Marc De Bel", "Standaard Uitgeverij"));
                context.SaveChanges();
                context.Items.Add(new Boek("9999", "bla", 2, "lololol", 5,  "9789027439642", "Paul Kalf", "Den Beenhouwer"));
                context.SaveChanges();
                context.Items.Add(new CD("4", "ceidei", 2, "lolol", 6,  55));
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