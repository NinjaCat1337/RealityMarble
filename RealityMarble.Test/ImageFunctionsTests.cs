using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using RealityMarble.BLL.Services;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.Web.Controllers;
using RealityMarble.Web.Models;

namespace RealityMarble.Test
{
    /// <summary>
    /// Summary description for ImageFunctionsTests
    /// </summary>
    [TestFixture]
    public class ImageFunctionsTests
    {
        [Test]
        public void CreateImage_NotValidFile_ReturnsViewDataErrorMessage()
        {
            //arrange
            var mock = new Mock<ShowImageModel>();
            mock.Setup(m => m).Returns(new ShowImageModel { About = "about", Author="author", Id=1, Path="path", Rating = 10, UserId = 1 });
            ImageController imageController = new ImageController();
            //imageController.Create(mock.Object);
        }
    }
}
