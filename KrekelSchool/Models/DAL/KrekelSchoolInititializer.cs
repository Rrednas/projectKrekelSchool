using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Policy;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class KrekelSchoolInitializer : DropCreateDatabaseAlways<KrekelSchoolContext>
    {

        protected override void Seed(KrekelSchoolContext context)
        {
            try
            {
                Lener[] leerlingen =
                {

                    new Lener("Bateev",	"Muhammed","A. Vanderstegenlaan", 129, null ,null,null, "2KB"),
                    new Lener("Dalgic",	"Iclal", "Klinkkouterstraat", 33, null, null, "aranhida-izzy@hotmail.com","1KB"),
                    new Lener("Er","Yigit", "Nieuwhof", 50, null, null,null, "2KA"),
                    new Lener("Kadirova", "Zilyan",	"Jean Bethunestraat", 52, null, null,"asi.kemal@live.nl","2KC"),
                    new Lener("Mertens","Maifano","Pretstraat", 8, null,null,"sven_laura@telenet.be","2KB"),
                    new Lener("Vandaele","Douwe","H. Hartstraat", 54, null, null,"joycegrieve@hotmail.com","2KA"), 
                };

                context.Leerlingen.AddRange(leerlingen);
                context.SaveChanges();

                //Uitlening[] leningen =
                //{
                //    new Uitlening(1, false, new DateTime(2015, 03, 02), new DateTime(2015, 05, 08),
                //        context.Items.Add(new Boek("1", "boek", true, "Beschrijving", 5, "12FZEF124TFAAZ", "Corneel",
                //            "kanaar"))),
                //};

                //context.Uitleningen.AddRange(leningen);
                //context.SaveChanges();

                Categorie[] themas =
                {
                    new Categorie("Aapjes"),
                };

                context.Categories.AddRange(themas);
                context.SaveChanges();

                Boek[] boeken =
                {
                    new Boek("boek" , true, "Beschrijving", 5, null ,themas[0],"12FZEF124TFAAZ", "Corneel", "kanaar" ),
                    new Boek("De Koning", false, "Boek over koning", 7 , "http://iedereenleest.be/images/boeken/De%20bh-boomhut.jpg" , themas[0],"ISbnNummer", "Corneel", "kanaar"),
                    new Boek("bla", true,"lololol", 666, "http://www.boek.be/sites/www.boek.be/files/styles/large/public/assets/5245171f5fea05.65705194.jpg?itok=4LfTSZal", themas[0],"grat e nummer", "Corneel", "kanaar")
                };

                context.Boeken.AddRange(boeken);
                context.SaveChanges();

                //Cd[] cds =
                //{
                //    new Cd("Hail Jebus!", false, 9, "How religion destroyed us!", 12, 55),
                //    new Cd("ceidei", false, 2, "lolol", 55, 667),
                //};
                //context.Cds.AddRange(cds);
                //context.SaveChanges();

                //Dvd[] dvds =
                //{

                //    new Dvd("ceidei", false, 2, "lolol", 55, 667)
                //};

                //context.Dvds.AddRange(dvds);
                //context.SaveChanges();
                //Spel[] spel =
                //{
                //    new Spel("een spel", true, 5, "een beschrijving", 6),
                //};

                //context.Spellen.AddRange(spel);
                //context.SaveChanges();
                //context.Boeken.Add(new Boek("boek" , true,3, "Beschrijving", 5, "12FZEF124TFAAZ", "Corneel", "kanaar" ));
                //context.Boeken.Add(new Boek("De Koning", false,88, "Boek over koning", 7,"ISbnNummer", "Corneel", "kanaar"));
                //context.SaveChanges();
                //context.Items.Add(new Boek("bla", true,1, "lololol", 666,"grat e nummer", "Corneel", "kanaar"));
                //context.SaveChanges();
                //context.Items.Add(new Cd( "ceidei", false,2, "lolol", 55, 667));
                //context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string s = "Fout creatie database ";
                foreach (var eve in e.EntityValidationErrors)
                {
                    s += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                         eve.Entry.Entity.GetType().Name, eve.Entry.GetValidationResult());
                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(s);
            }
            //context.SaveChanges();
            //base.Seed(context);
        }
    }
}