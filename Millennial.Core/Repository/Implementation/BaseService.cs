using Millennial.Core.Repository.Interface;
using Millennial.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Millennial.Core.Repository.Implementation
{
    public abstract class BaseService<T, P> : IBaseService<T, P> where T : class where P : struct
    {
        private readonly IBaseRepository<T, P> _baseRepository;
        public BaseService(IBaseRepository<T, P> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public void Add(T t)
        {
            _baseRepository.Add(t);
        }

        public T GetById(P Id)
        {
            return _baseRepository.GetById(Id);
        }

        public void Remove(P Id)
        {
            _baseRepository.Remove(Id);
        }

        public int Save()
        {
            return _baseRepository.Save();
        }
    }
}
