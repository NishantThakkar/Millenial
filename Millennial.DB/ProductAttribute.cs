using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Millennial.DB
{
    [Table("ProductAttribute")]
    public class ProductAttribute
    {
       
        public long ProductId { get; set; }
        public int AttributeId { get; set; }
        [StringLength(250)]
        public string AttributeValue { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("AttributeId")]
        public virtual ProductAttributeLookup ProductAttributeLookup { get; set; }
    }
}
