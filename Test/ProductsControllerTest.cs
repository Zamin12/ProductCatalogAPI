using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Controllers;
using ProductCatalogAPI.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class ProductsControllerTest
    {
        [Fact]
        public async Task GetProducts_ReturnsData()
        {
            // Arrange
            var dbContext = TestHelper.CreateTestingContext();

            TestHelper.InitializeDatabase(dbContext);

            var controller = new ProductsController(dbContext);

            // Act
            var result = await controller.GetProducts();

            // Assert
            Assert.Equal(result.Value.ToList().Count, dbContext.Products.ToList().Count);
        }

        [Fact]
        public async Task GetProductsByFilter_WithCode_ReturnsData()
        {
            // Arrange
            var dbContext = TestHelper.CreateTestingContext();

            TestHelper.InitializeDatabase(dbContext);

            var controller = new ProductsController(dbContext);

            // Act
            var result = await controller.GetProductsByFilter(code: "1");

            // Assert
            Assert.Equal(result.Value.ToList().Count, dbContext.Products.Where(p => p.Code == "1").ToList().Count);
        }

        [Fact]
        public async Task GetProductsById_ReturnsData()
        {
            // Arrange
            var dbContext = TestHelper.CreateTestingContext();

            TestHelper.InitializeDatabase(dbContext);

            var testGuid = Guid.NewGuid();

            var product = new Product
            {
                Id = testGuid,
                Code = "code",
                Name = "Shoes",
                Price = 111m,
                Photo = "testphotobase64string"
            };

            dbContext.Add(product);
            dbContext.SaveChanges();

            var controller = new ProductsController(dbContext);

            // Act
            var result = await controller.GetProduct(testGuid);

            // Assert
            Assert.Equal(result.Value, product);
        }

        [Fact]
        public async Task GetProductsById_ReturnsNotFound()
        {
            // Arrange
            var dbContext = TestHelper.CreateTestingContext();

            TestHelper.InitializeDatabase(dbContext);

            var testGuid = Guid.NewGuid();

            var product = new Product
            {
                Id = testGuid,
                Code = "code",
                Name = "Shoes",
                Price = 111m,
                Photo = "testphotobase64string"
            };

            dbContext.Add(product);
            dbContext.SaveChanges();

            var controller = new ProductsController(dbContext);

            // Act
            var result = await controller.GetProduct(Guid.NewGuid());

            // Assert
            Assert.NotEqual(result.Value, product);
            Assert.Equal(404, (result.Result as StatusCodeResult).StatusCode);
        }

        [Fact]
        public async Task PutProduct_Updated_ReturnsNoContent()
        {
            // Arrange
            var dbContext = TestHelper.CreateTestingContext();

            TestHelper.InitializeDatabase(dbContext);

            var testGuid = Guid.NewGuid();
            var initialName = "Shoes";
            var updatedName = "Socks";

            var product = new Product
            {
                Id = testGuid,
                Code = "code",
                Name = initialName,
                Price = 111m,
                Photo = "testphotobase64string"
            };

            dbContext.Add(product);
            dbContext.SaveChanges();

            product.Name = updatedName;

            var controller = new ProductsController(dbContext);

            // Act
            var result = await controller.PutProduct(testGuid, product);

            // Assert
            Assert.NotEqual(initialName, dbContext.Products.Find(testGuid).Name);
            Assert.Equal(204, (result as StatusCodeResult).StatusCode);
        }

        [Fact]
        public async Task PostProduct_Inserted()
        {
            // Arrange
            var dbContext = TestHelper.CreateTestingContext();

            TestHelper.InitializeDatabase(dbContext);

            var product = new Product
            {
                Code = "code",
                Name = "Glasses",
                Price = 111m,
                Photo = "testphotobase64string"
            };

            var controller = new ProductsController(dbContext);

            var initialProductCount = dbContext.Products.Count();

            // Act
            var result = await controller.PostProduct(product);

            // Assert
            Assert.NotEqual(initialProductCount, dbContext.Products.Count());
        }

        [Fact]
        public async Task DeleteProduct_Deleted()
        {
            // Arrange
            var dbContext = TestHelper.CreateTestingContext();

            TestHelper.InitializeDatabase(dbContext);

            var testGuid = Guid.NewGuid();

            var product = new Product
            {
                Id = testGuid,
                Code = "code",
                Name = "Glasses",
                Price = 111m,
                Photo = "testphotobase64string"
            };

            dbContext.Add(product);
            dbContext.SaveChanges();

            var controller = new ProductsController(dbContext);

            var initialProductCount = dbContext.Products.Count();

            // Act
            var result = await controller.DeleteProduct(testGuid);

            // Assert
            Assert.NotEqual(initialProductCount, dbContext.Products.Count());
        }

    }
}
