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
                Leerling boy = new Leerling("kleinen","dude",1);
                context.Leerlingen.Add(boy);
                context.SaveChanges();
                
                    context.Items.Add(new Boek(1, "boek" , 2, "Beschrijving" , "12FZEF124TFAAZ" ));
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