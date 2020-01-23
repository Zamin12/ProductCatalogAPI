using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalogAPI.Model;
using System;

namespace Test
{
    public class TestHelper
    {
        public static ProductCatalogContext CreateTestingContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<ProductCatalogContext>()
                .UseInMemoryDatabase("ProductCatalogAPI")
                .UseInternalServiceProvider(serviceProvider);
            return new ProductCatalogContext(builder.Options);
        }

        public static void InitializeDatabase(ProductCatalogContext dbContext)
        {
            var product1 = new Product
            {
                Id = Guid.NewGuid(),
                Code = "1",
                Name = "Jeans",
                Price = 15.34m,
                Photo = "testphotobase64string"
            };

            var product2 = new Product
            {
                Id = Guid.NewGuid(),
                Code = "2",
                Name = "Tshirt",
                Price = 124.55m,
                Photo = "testphotobase64string"
            };

            var product3 = new Product
            {
                Id = Guid.NewGuid(),
                Code = "3",
                Name = "Jacket",
                Price = 2567.55m,
                Photo = "testphotobase64string"
            };

            dbContext.Add(product1);
            dbContext.Add(product2);
            dbContext.SaveChanges();
        }
    }
}
