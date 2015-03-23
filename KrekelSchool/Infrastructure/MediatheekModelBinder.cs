using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KrekelSchool.Infrastructure
{
    public class MediatheekModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Mediatheek mediatheek = controllerContext.HttpContext.Session["Mediatheek"] as Mediatheek;
            if (mediatheek == null)
            {
                controllerContext.HttpContext.Session["Mediatheek"] = new Mediatheek();
            }
            return controllerContext.HttpContext.Session["Mediatheek"] as Mediatheek;
        }
    }
}