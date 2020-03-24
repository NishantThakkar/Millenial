using System;
using System.Collections.Generic;
using System.Text;

namespace Millennial.Core.Service.Interface
{
    public interface IBaseRepository<T,P>
    {
        void Add(T t);
        int Save();
        T GetById(P Id);
        void Remove(P Id);
    }
}
