using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product {Id=1,Name="Kalem1",CategoryId=1,Price=100,Stock=12,CreatedDate=DateTime.Now},
                new Product { Id = 2,Name="Kalem2", CategoryId = 1, Price = 50, Stock = 52, CreatedDate = DateTime.Now },
                new Product { Id = 3,Name="Kalem3", CategoryId = 1, Price = 200, Stock = 22, CreatedDate = DateTime.Now },
                new Product { Id = 4, Name = "Kitap1", CategoryId = 2, Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product { Id = 5, Name = "Kitap2", CategoryId = 2, Price = 70, Stock =10, CreatedDate = DateTime.Now }
                );
        }
    }
}
