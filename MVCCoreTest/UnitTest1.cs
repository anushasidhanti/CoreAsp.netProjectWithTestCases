using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCCore;
using MVCCore.Controllers;
using System.Net.Http;

namespace MVCCoreTest
{
    [TestClass]
    public class UnitTest1
    {

       
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = mock.Object;            
            logger = Mock.Of<ILogger<HomeController>>();
            HomeController controller = new HomeController(logger);
            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual("Application Index page", result.ViewData["Message"]);
           
        }
    }
}
