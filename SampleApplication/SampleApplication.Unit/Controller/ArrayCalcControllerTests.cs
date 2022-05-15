using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SampleApplication.Controllers;
using SampleApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApplication.UnitTests.Controller
{
    [TestClass]
    public class ArrayCalcControllerTests
    {
        private IProductService _productService;
        [TestInitialize]
        public void TestInitialize()
        {
            _productService = Substitute.For<IProductService>();
        }

        [TestMethod]
        public void GetReverse_Should_Return_Records()
        {
            _productService.GetProductReverse(Arg.Any<int[]>()).Returns(new int[]
            {
                5,4,3,2,1
            });
            var arrayController = new ArrayCalcController(_productService);

            var response = arrayController.GetReverse(new int[] { 1, 2, 3, 4, 5 });

            Assert.IsNotNull(response);

            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));

            Assert.IsNotNull(((OkObjectResult)response.Result).Value);
        }

        [TestMethod]
        public void GetReverse_Should_Return_No_Records()
        {
            _productService.GetProductReverse(Arg.Any<int[]>()).ReturnsNull();

            var arrayController = new ArrayCalcController(_productService);

            var response = arrayController.GetReverse(new int[0]);

            Assert.IsNotNull(response);

            Assert.IsInstanceOfType(response.Result, typeof(BadRequestResult));            
        }

        [TestMethod]
        public void DeletePart_Should_Return_Records()
        {
            _productService.DeletePartOfProduct(Arg.Any<int[]>(), Arg.Any<int>()).Returns(new int[]
            {
                5,4,2,1
            });
            var arrayController = new ArrayCalcController(_productService);

            var response = arrayController.DeletePart(3, new int[] { 1, 2, 3, 4, 5 });

            Assert.IsNotNull(response);

            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));

            Assert.IsNotNull(((OkObjectResult)response.Result).Value);
        }

        [TestMethod]
        public void DeletePart_Should_Return_No_Records_For_Position_0()
        {
            _productService.DeletePartOfProduct(Arg.Any<int[]>(), Arg.Any<int>()).ReturnsNull();

            var arrayController = new ArrayCalcController(_productService);

            var response = arrayController.DeletePart(0, new int[] { 1, 2, 3, 4, 5 });

            Assert.IsNotNull(response);

            Assert.IsInstanceOfType(response.Result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeletePart_Should_Return_No_Records_For_Position_Greater_Than_ProductIs()
        {
            _productService.DeletePartOfProduct(Arg.Any<int[]>(), Arg.Any<int>()).ReturnsNull();

            var arrayController = new ArrayCalcController(_productService);

            var response = arrayController.DeletePart(8, new int[] { 1, 2, 3, 4, 5 });

            Assert.IsNotNull(response);

            Assert.IsInstanceOfType(response.Result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeletePart_Should_Return_No_Records_For_ProductIds_Are_Empty()
        {
            _productService.DeletePartOfProduct(Arg.Any<int[]>(), Arg.Any<int>()).ReturnsNull();

            var arrayController = new ArrayCalcController(_productService);

            var response = arrayController.DeletePart(2, new int[0]);

            Assert.IsNotNull(response);

            Assert.IsInstanceOfType(response.Result, typeof(BadRequestResult));
        }
    }
}
