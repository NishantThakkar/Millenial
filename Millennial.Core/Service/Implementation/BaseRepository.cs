using Millennial.Core.Service.Interface;
using Millennial.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Millennial.Core.Service.Implementation
{
    public abstract class BaseRepository<T, P> : IBaseRepository<T, P> where T : class where P : struct
    {
        private readonly ECommerceDemoContext _context;
        public BaseRepository(ECommerceDemoContext context)
        {
            _context = context;
        }

        public void Add(T t)
        {
            _context.Set<T>().Add(t);
        }

        public void Remove(P Id)
        {
            var entity = GetById(Id);
            _context.Remove(entity);            
        }

        public T GetById(P Id)
        {
           var entity =  _context.Set<T>().Find(Id);
            return entity;
        }
        public int Save()
        {
            int records = _context.SaveChanges();
            return records;
        }
    }
}
