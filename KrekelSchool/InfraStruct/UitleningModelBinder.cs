using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.InfraStruct
{
    public class UitleningModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            
            VoorlopigeUitlening voorlopige = controllerContext.HttpContext.Session["VoorlopigeUitlening"] as VoorlopigeUitlening;


            if (voorlopige == null)
                controllerContext.HttpContext.Session["VoorlopigeUitlening"] = new VoorlopigeUitlening();
            return controllerContext.HttpContext.Session["VoorlopigeUitlening"] as VoorlopigeUitlening;


        }
    }
}