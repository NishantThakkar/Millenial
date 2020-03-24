using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Millennial.DB
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        [Required]
        [StringLength(250)]
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        [ForeignKey("ProdCatId")]
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

        public Product()
        {
            this.ProductAttributes = new List<ProductAttribute>();
        }
    }
}
