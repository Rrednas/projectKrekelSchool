using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.InfraStruct
{
    public class GebruikerModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            Gebruiker gebruiker = controllerContext.HttpContext.Session["Gebruiker"] as Gebruiker;


            if (gebruiker == null)
                controllerContext.HttpContext.Session["Gebruiker"] = new Gebruiker();
            return controllerContext.HttpContext.Session["Gebruiker"] as Gebruiker;


        }
    }
}