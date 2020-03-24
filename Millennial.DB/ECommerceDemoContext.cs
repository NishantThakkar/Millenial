using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Millennial.DB
{
    public class ECommerceDemoContext : DbContext
    {
        public ECommerceDemoContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeLookup> ProductAttributeLookups { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasKey(x => new { x.ProductId, x.AttributeId });
                entity.Property(x => x.AttributeValue).IsUnicode(false);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(x => x.ProdDescription).IsUnicode(false);
                entity.Property(x => x.ProdName).IsUnicode(false);
            });
            modelBuilder.Entity<ProductAttributeLookup>(entity =>
            {
                entity.Property(x => x.AttributeName).IsUnicode(false);
                entity.HasData(new ProductAttributeLookup() { AttributeId = 1, AttributeName = "Color", ProdCatId = 1 },
                   new ProductAttributeLookup() { AttributeId = 2, AttributeName = "Make", ProdCatId = 1 },
                   new ProductAttributeLookup() { AttributeId = 3, AttributeName = "Model", ProdCatId = 1 },
                   new ProductAttributeLookup() { AttributeId = 4, AttributeName = "RAM", ProdCatId = 2 },
                   new ProductAttributeLookup() { AttributeId = 5, AttributeName = "Front Camera", ProdCatId = 2 },
                   new ProductAttributeLookup() { AttributeId = 6, AttributeName = "Rear Camera", ProdCatId = 2 });
            });
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(x => x.CategoryName).IsUnicode(false);
                entity.HasData(new ProductCategory() { CategoryName = "Car", ProdCatId = 1 },
                   new ProductCategory() { CategoryName = "Mobile", ProdCatId = 2 });
            });

        }
    }
}
