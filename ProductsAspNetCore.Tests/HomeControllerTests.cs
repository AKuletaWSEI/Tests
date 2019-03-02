using NUnit.Framework;
using ProductsAspNetCore.Controllers;
using ProductsAspNetCore.Data;
using ProductsAspNetCore.Models;
using Moq;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProductsAspNetCore.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {

        private readonly DbContextOptions<ProductContext> options;

        public HomeControllerTests()
        {
            options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
        }

        [Test]
        public void CanBeCreate_AddProduct_ReturnTrue()
        {
            // Arrange
            //int productId = 1;
            var context = new ProductContext(options);
            var controller = new HomeController(context);

            //Act
            var result = controller.Create(new Product
            { ID = 1, Name = "mas³o", Category = "Spo¿ywcze", Price = 3.2, Quantity = 2, AssigntTo = "AK" }
            ) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(context.Products.Count());
            Assert.IsTrue(context.Products.Count() == 1);
            //Assert.IsTrue(result.RouteValues.ContainsKey("action"));
            //Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [Test] 
        public void CanBeEdited_ExistingProduct_ReturnProduct()
        {

            // Arrange
            var context = new ProductContext(options);
            context.Products.Add(new Product
            { ID = 1, Name = "mas³o", Category = "Spo¿ywcze", Price = 3.2, Quantity = 2, AssigntTo = "AK" }
            );
            var controller = new HomeController(context);


            //Act
            var result = controller.Edit(1) as ViewResult;
            var model = result.Model as Product;

            //Assert
            Assert.NotNull(model);
        }

        [Test]
        public void CanFindById_ExistingProduct_ReturnProductName()
        {
            // Arrange
            string productName;

            var context = new ProductContext(options);
            context.Products.Add(new Product
            { ID = 1, Name = "mas³o", Category = "Spo¿ywcze", Price = 3.2, Quantity = 2, AssigntTo = "AK" }
            );
            context.SaveChanges();

            var controller = new HomeController(context);

            //Act
            var result = controller.Edit(1) as ViewResult;
            var model = result.ViewData.Model as Product;
            productName = model.Name;

            //Assert
            Assert.IsTrue(context.Products.Count() > 0);
            //Assert.AreEqual(productName, context.Products.Single(p => p.ID == 1).Name);

        }
    }
}