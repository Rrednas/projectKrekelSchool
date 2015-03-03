using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KrekelSchool.Tests.Controllers
{
    [TestClass]
    public class LeerlingControllerTest
    {
        private ItemController controller = new ItemController();
        [TestMethod]
        public void Item()
        {
            
            ViewResult result = controller.Item() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ItemScreenWithoutId()
        {
            
            ActionResult result = controller.ItemScreen("") as ActionResult;
            
        }

        [TestMethod]
        public void ItemScreenWithIdForBoek()
        {
            ActionResult result = controller.ItemScreen("Boeken") as ActionResult;
            Assert.IsNotNull(result);
        }
    }
}
