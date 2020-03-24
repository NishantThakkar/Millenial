using Microsoft.EntityFrameworkCore;
using Millennial.Core.Service.Interface;
using Millennial.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millennial.Core.Service.Implementation
{
    public class ProductRepository : BaseRepository<Product,long>, IProductRepository
    {
        ECommerceDemoContext _context;
        public ProductRepository(ECommerceDemoContext context):base(context)
        {
            _context = context;
        }

        public IQueryable<Product> GetList(int skip, int take,  string sortBy, string sortDirection, string search, ref int count)
        {   
            var products = _context.Products.Include(x => x.ProductCategory).Take(take).Skip(skip);
            switch (sortBy)
            {
                case "ProdName":
                    products = sortDirection == "asc" ?  products.OrderBy(x => x.ProdName) : products.OrderByDescending(x => x.ProdName);
                    break;
                case "ProductCategory":
                    products = sortDirection == "asc" ? products.OrderBy(x => x.ProductCategory) : products.OrderByDescending(x => x.ProductCategory);
                    break;
                default:
                    products = products.OrderBy(x => x.ProdName);
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.ProdName.StartsWith(search) || x.ProductCategory.CategoryName.StartsWith(search) || x.ProdDescription.Contains(search));
            }
            
            count = _context.Products.Count();
            return products;
        }
    }
}
