using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVC_TODO;
using MVC_TODO.Controllers;
using MVC_TODO.Models;

namespace MVC_TODO_TESTS
{
    [TestClass]
    public class UnitTest1
    {

        private Mock<IHCModel> hcModel;


        [TestMethod]
        public void TestIndexViewModelRendersCorrectly()
        {
            hcModel = new Mock<IHCModel>();

            hcModel.Setup(m => m.GetTodos()).Returns(new List<Todo>());

            var controller = new HomeController(hcModel.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(result);
            
        }
    }
}
