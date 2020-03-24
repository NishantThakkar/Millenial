using Millennial.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Millennial.Core.Repository.Interface
{
    public interface IProductService : IBaseService<Product, long>
    {
        ProductListViewModel GetList(int page, int take, string sortBy, string sortDirection, string search);
    }
}
