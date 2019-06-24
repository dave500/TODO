using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_TODO;
using MVC_TODO.Controllers;

namespace MVC_TODO_TESTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIndexViewModelRendersCorrectly()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(result);
            
        }
    }
}
