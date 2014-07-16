using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting; 

using FileUpload;
using FileUpload.Controllers;

namespace FileUpload.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestUploadExcelFile()
        {
            //We'll need mocks of context, request and fake file
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            var postedfile = new Mock<HttpPostedFileBase>();

            //Someone is going to ask for Request.File and we'll need a mock (fake) of that
            var postedFilesKeyCollection = new Mock<HttpFileCollectionBase>();
            var fakeFileKeys = new List<string>() { "file" };

            
            //Code being tested for implementation
            HomeController controller = new HomeController();

            ViewResult result = controller.UploadFiles() as ViewResult;
            var uploadResult = result.ViewData.Model as List<ViewDataUploadFilesResult>;
            Assert.AreEqual(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "foo.doc"), uploadedResult[0].Name);
            Assert.AreEqual(8192, uploadedResult[0].Length);

        }
    }
}
