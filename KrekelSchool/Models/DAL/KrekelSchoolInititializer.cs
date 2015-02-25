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
                Leerling boy = new Leerling("kleinen", "dude", 1);
                context.Leerlingen.Add(boy);
                context.SaveChanges();
                Item boek = new Boek( Soort.boek, "iets",5,"zeer zotte boek", "89465123dsfs");
                Item cd = new Cd(Soort.cd,"trol",1,"cd",200);
                Item spel = new Spel( Soort.spel, "spel1", 2, "deeee");
                Item vertelt = new Verteltas(Soort.verteltas, "tas1", 3, "beschr");
                Item dvd = new Dvd( Soort.dvd, "dvd1", 3, "beesch",500);

                context.Items.Add(boek);
                context.Items.Add(cd);
                context.Items.Add(spel);
                context.Items.Add(vertelt);
                context.Items.Add(dvd);
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