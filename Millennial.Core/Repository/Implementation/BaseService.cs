using Microsoft.EntityFrameworkCore.Query;
using Millennial.Core.Repository.Interface;
using Millennial.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public virtual void Add(T t)
        {
            _baseRepository.Add(t);
        }

        public virtual T GetById(P Id)
        {
            return _baseRepository.GetById(Id);
        }

        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> filter)
        {
            return _baseRepository.GetByPredicate(filter);
        }

        public virtual void Remove(P Id)
        {
            _baseRepository.Remove(Id);
        }

        public virtual int Save()
        {
            return _baseRepository.Save();
        }

        public virtual void Update(T t)
        {
            _baseRepository.Update(t);
        }
    }
}
