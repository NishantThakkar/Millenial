using Millennial.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millennial.Core.Service.Interface
{
    public interface IProductRepository : IBaseRepository<Product, long>
    {
        IQueryable<Product> GetList(int skip, int take,  string sortBy, string sortDirection, string search, ref int count);
    }
}
