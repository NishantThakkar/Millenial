using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Millennial.DB
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new List<Product>();
            this.ProductAttributeLookups = new List<ProductAttributeLookup>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProdCatId { get; set; }
        [StringLength(250)]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductAttributeLookup> ProductAttributeLookups { get; set; }
    }
}
