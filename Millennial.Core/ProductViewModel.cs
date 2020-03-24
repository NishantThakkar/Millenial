using System;
using System.Collections.Generic;

namespace Millennial.Core
{
    public class ProductViewModel
    {
        public long ProductId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public string ProductCategory { get; set; }
    }
    public class ProductListViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public int Count { get; set; }
    }
}
