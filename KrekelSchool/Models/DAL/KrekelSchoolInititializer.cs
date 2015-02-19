using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
            }
            catch (Exception)
            {
                
                throw;
            }
            context.SaveChanges();
            base.Seed(context); 
        }
    }
}