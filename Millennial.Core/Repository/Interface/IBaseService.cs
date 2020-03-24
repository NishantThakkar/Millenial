using System;
using System.Collections.Generic;
using System.Text;

namespace Millennial.Core.Repository.Interface
{
    public interface IBaseService<T, P>
    {
        void Add(T t);
        int Save();
        T GetById(P Id);
        void Remove(P Id);
    }
}
