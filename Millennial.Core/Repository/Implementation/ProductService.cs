using Millennial.Core.Repository.Interface;
using Millennial.Core.Service.Interface;
using Millennial.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Millennial.Core.Repository.Implementation
{
    public class ProductService : BaseService<Product, long>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductListViewModel GetList(int page, int take, string sortBy, string sortDirection,string search)
        {
            int count = 0;
            var skip = page * take;
            sortBy = sortBy.Replace(sortBy.Substring(0, 1), sortBy.Substring(0, 1).ToUpper());
            var productsQuery = _productRepository.GetList(skip, take, sortBy , sortDirection, search, ref count);
            var productsViewModel = from n in productsQuery
                                    select new ProductViewModel()
                                    {
                                        ProductId = n.ProductId,
                                        ProdName = n.ProdName,
                                        ProdDescription = n.ProdDescription,
                                        ProductCategory = n.ProductCategory.CategoryName
                                    };
            var products = productsViewModel.ToList();
            return new ProductListViewModel()
            {
                Count = count,
                Products = products
            };
        }
    }
}

