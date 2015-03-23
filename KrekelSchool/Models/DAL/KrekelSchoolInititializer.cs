﻿using System;
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
                Lener[] leerlingen =
                {
                    new Lener("kleinen", "dude"),
                    new Lener("Maken", "Mieken"),
                    new Lener("Den Trekaak", "Jaak"),
                    new Lener("GaatBerg", "Woopie"),
                    new Lener("Palladino", "Pino")
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

                Boek[] boeken =
                {
                    new Boek("boek" , true,3, "Beschrijving", 5, "12FZEF124TFAAZ", "Corneel", "kanaar" ),
                    new Boek("De Koning", false,88, "Boek over koning", 7,"ISbnNummer", "Corneel", "kanaar"),
                    new Boek("bla", true,1, "lololol", 666,"grat e nummer", "Corneel", "kanaar")
                };

                context.Boeken.AddRange(boeken);
                context.SaveChanges();

                CD[] cds =
                {
                    new CD("Hail Jebus!", false, 9, "How religion destroyed us!", 12, 55),
                    new CD("ceidei", false, 2, "lolol", 55, 667),
                };
                context.Cds.AddRange(cds);
                context.SaveChanges();

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
            catch (Exception e)
            {
                
                throw(e);
            }
            context.SaveChanges();
            base.Seed(context); 
        }
    }
}