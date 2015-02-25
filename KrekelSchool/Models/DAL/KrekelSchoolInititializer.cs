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
                Item boek = new Boek( "boek1", 1, "boek een","nummer");
                Item cd = new Cd(2,"trol",1,"dikkentrolcd",200);
                Item spel = new Spel( 3,"spel1", 2, "deeee");
                Item vertelt = new Verteltas( 4,"tas1", 3, "beschr");
                Item dvd = new Dvd( "dvd1", 3, "beesch",500);

                context.items.Add(boek);
                context.items.Add(cd);
                context.items.Add(spel);
                context.items.Add(vertelt);
                context.items.Add(dvd);
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