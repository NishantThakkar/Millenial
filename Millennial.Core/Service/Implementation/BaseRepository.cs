using Millennial.Core.Service.Interface;
using Millennial.DB;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Millennial.Core.Service.Implementation
{
    public abstract class BaseRepository<T, P> : IBaseRepository<T, P> where T : class where P : struct
    {
        private readonly ECommerceDemoContext _context;
        public BaseRepository(ECommerceDemoContext context)
        {
            _context = context;
        }

        public virtual void Add(T t)
        {
            _context.Set<T>().Add(t);
        }

        public virtual void Remove(P Id)
        {
            var entity = GetById(Id);
            _context.Remove(entity);            
        }

        public virtual T GetById(P Id)
        {
           var entity =  _context.Set<T>().Find(Id);
            return entity;
        }
        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> filter)
        {
            var query = _context.Set<T>();
            return query.Where(filter);
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
        }
        public int Save()
        {
            
            int records = _context.SaveChanges();
            return records;
        }
    }
}
