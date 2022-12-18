using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ctest_model.Entities;
using ctest_model.Interface;
using Microsoft.EntityFrameworkCore;

namespace ctest_model
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private chatRoomContext _context { get; set; }

        public Repository()
            : this(new chatRoomContext())
        {
        }

        public Repository(chatRoomContext context)
        {
            _context = context ?? throw new ArgumentNullException("context");
        }

        public T Create_ReturnId(T instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            _context.Set<T>().Add(instance);
            SaveChanges();
            return instance;
        }

        public void Create(T instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            _context.Set<T>().Add(instance);
            SaveChanges();
        }

        public void Update(T instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            _context.Entry(instance).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(T instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            _context.Entry(instance).State = EntityState.Deleted;
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            _context.Set<T>().RemoveRange(instance);
            SaveChanges();
        }

        public void AddRange(IEnumerable<T> instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            _context.Set<T>().AddRange(instance);
            SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> predicate) => _context.Set<T>().FirstOrDefault(predicate);

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }



        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
