using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Millennial.Core.Repository.Interface
{
    public interface IBaseService<T, P>
    {
        void Add(T t);
        int Save();
        T GetById(P Id);
        void Remove(P Id);
        void Update(T t);
        IQueryable<T> GetByPredicate(Expression<Func<T, bool>> filter);
    }
}
