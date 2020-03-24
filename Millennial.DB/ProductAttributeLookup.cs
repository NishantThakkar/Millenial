using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Millennial.DB
{
    [Table("ProductAttributeLookup")]
    public class ProductAttributeLookup
    {
        public ProductAttributeLookup()
        {
            //this.Products = new List<Product>();
            this.ProductAttributes = new List<ProductAttribute>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttributeId { get; set; }
        public int ProdCatId { get; set; }
        [Required]
        [StringLength(250)]
        public string AttributeName { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

        [ForeignKey("ProdCatId")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
