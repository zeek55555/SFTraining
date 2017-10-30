using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SitefinityWebApp.Mvc.Controllers;
using SitefinityWebApp.Mvc.Models;

namespace SitefinityWebApp.Tests.Compliments
{
    [TestClass]
    public class TheComplimentsModel
    {
        [TestMethod]
        public void Exists()
        {
            var complimentsModel= new ComplimentsModel();
        }

        [TestMethod]
        public void HasComplimentras()
        {
            var complimentsModel = new ComplimentsModel();
            Assert.AreEqual("You ARE as cool as you think", complimentsModel.Compliments);
        }

        [TestMethod]
        public void CanCompliemnt()
        {
            var complimentsModel = new ComplimentsModel();
            Assert.AreEqual("You ARE as cool as you think", complimentsModel.ComplimentMe());
        }

        [TestClass]
        public class GivenSomeCompliments
        {
            [TestMethod]
            public void ItWillComplimentYouWithVariety()
            {

            }
        }
    }
}
