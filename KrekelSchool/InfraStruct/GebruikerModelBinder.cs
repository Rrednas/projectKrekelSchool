using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.InfraStruct
{
    public class GebruikerModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            
            User gebruiker = controllerContext.HttpContext.Session["User"]  as User;


            if (gebruiker == null)
                controllerContext.HttpContext.Session["User"] = new User(new GebruikerRepository(new KrekelSchoolContext()).GetGebruiker());
            return controllerContext.HttpContext.Session["User"] as User;


        }
    }
}