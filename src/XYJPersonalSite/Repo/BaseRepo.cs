using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Repo
{
    public abstract class BaseRepo<T, Tkey> : IBaseRepo<T, Tkey> where T : class
    {
        protected readonly DbContext _context;
        public BaseRepo(DbContext context)
        {
            _context = context;
        }


        public T Add(T item)
        {
            _context.Add<T>(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteByKey(Tkey key)
        {
            try
            {
                _context.Remove<T>(GetByKey(key));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Edit(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByKey(Tkey key)
        {
            return GetItemByKey(key);
        }

        public abstract T GetItemByKey(Tkey key);

        public ICollection<T> GetListBy(Func<T, bool> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }
    }
}
