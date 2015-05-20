using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Policy;
using System.Web;
using KrekelSchool.Models.Domain1;
using WebGrease.Css.Extensions;

namespace KrekelSchool.Models.DAL
{
    public class KrekelSchoolInitializer : DropCreateDatabaseAlways<KrekelSchoolContext>
    {

        protected override void Seed(KrekelSchoolContext context)
        {
            try
            {
                
                context.Mediatheeks.Add(new Mediatheek());
                context.SaveChanges();
                context.Mediatheeks.First().Gebruikers.Add(new Gebruiker("", "", "Bezoeker"));
                context.Mediatheeks.First().Gebruikers.Add(new Medewerker("Medewerker","medewerker","medewerker"));
                context.Mediatheeks.First().Gebruikers.Add(new Vrijwilliger("Vrijwilliger","vrijwilliger","vrijwilliger"));
                
                context.SaveChanges();
                Lener[] leerlingen =
                {

                    new Lener("Bateev",	"Muhammed","A. Vanderstegenlaan", "129", null ,null,null, "2KB"),
                    new Lener("Dalgic",	"Iclal", "Klinkkouterstraat","33", null, null, "aranhida-izzy@hotmail.com","1KB"),
                    new Lener("Er","Yigit", "Nieuwhof", "50", null, null,null, "2KA"),
                    new Lener("Kadirova", "Zilyan",	"Jean Bethunestraat", "52", null, null,"asi.kemal@live.nl","2KC"),
                    new Lener("Mertens","Maifano","Pretstraat", "8", null,null,"sven_laura@telenet.be","2KB"),
                    new Lener("Vandaele","Douwe","H. Hartstraat", "54", null, null,"joycegrieve@hotmail.com","2KA"), 
                };

                context.Mediatheeks.First().VoegLenerToe(new Lener("Bateev", "Muhammed", "A. Vanderstegenlaan", "129", null, null, null, "2KB"));
                context.Mediatheeks.First()
                    .VoegLenerToe(new Lener("Dalgic", "Iclal", "Klinkkouterstraat", "33", null, null,
                        "aranhida-izzy@hotmail.com", "1KB"));
                //context.Mediatheeks.First().VoegLenerToe(leerlingen.First());
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
                    new Categorie("ziekenhuis: onderzoeken en operatie"),   
                    new Categorie("Durven en niet durven"),  
                    new Categorie("Verliefdheid"), 
                };

                IEnumerable<Categorie> cat = new List<Categorie>(themas);

                context.Mediatheeks.First().VoegCategoriesToe(themas);
                context.Mediatheeks.First().VoegCategorieToe(new Categorie("Verliefdheid"));
                context.SaveChanges();

                //Boek[] boeken =
                //{
                //    new Boek("Tuur is ziek" , true, null, 5, "http://www.boekhandelpardoes.be/images/lightbox/9789059241084.jpg" ,themas[0]," 9789059241084", "Pascale De Snijder", "Bakermat" ),
                //    new Boek("Clown durft", false, "Boek over een clown die durft", 5, "http://s.s-bol.com/imgbase0/imagebase/large/FC/2/4/1/5/666855142.jpg" , themas[1],"9789052471389", "Luk Depondt en Guido van Genechten", "Bakermat"),
                //    new Boek("Tok de kip", true, null, 0, "", null,"9789058386946", "Inge Bergh", "De Eenhoorn"),
                //    new Boek("Beer is op vlinder", true,"Een verliefde beer", 0, "http://s.s-bol.com/imgbase0/imagebase/large/FC/4/0/9/0/1001004002060904.jpg", themas[2],"9789025842550 ", "Annemarie van Haeringen", "Van In")
                //};

                context.Mediatheeks.First().VoegBoekToe(new Boek("Tuur is ziek", true, null, 5, "http://www.boekhandelpardoes.be/images/lightbox/9789059241084.jpg", themas[0], " 9789059241084", "Pascale De Snijder", "Bakermat"));
                context.Mediatheeks.First().VoegBoekToe(new Boek("Clown durft", false, "Boek over een clown die durft", 5, "http://s.s-bol.com/imgbase0/imagebase/large/FC/2/4/1/5/666855142.jpg", themas[1], "9789052471389", "Luk Depondt en Guido van Genechten", "Bakermat"));
                context.Mediatheeks.First().VoegBoekToe(new Boek("Tok de kip", true, null, 0, "", "9789058386946", "Inge Bergh", "De Eenhoorn"));
                context.Mediatheeks.First().VoegBoekToe(new Boek("Beer is op vlinder", true, "Een verliefde beer", 0, "http://s.s-bol.com/imgbase0/imagebase/large/FC/4/0/9/0/1001004002060904.jpg", themas[2], "9789025842550 ", "Annemarie van Haeringen", "Van In"));
             
                //context.Boeken.AddRange(boeken);
                
                context.SaveChanges();

                //CD[] cds =
                //{
                //    new CD("Hail Jebus!", false, "How religion destroyed us!", 12, "",5, themas[0]),
                //    new CD("ceidei", false, "lolol", 55, "",667,themas[0])

                //};
                //context.Mediatheeks.First().VoegCdRangeToe(cds);
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
                        s += String.Format("- Categories: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(s);
            }
           
            base.Seed(context);
        }
    }
}