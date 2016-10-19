using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Repo
{
    public abstract class BaseRepo<T, Tkey> :IDisposable,IBaseRepo<T, Tkey> where T : class
    {
        protected readonly DbContext _context;
        public BaseRepo(DbContext context)
        {
            _context = context;
        }


        public async Task<T> Add(T item)
        {
            CheckDispose();
            _context.Add<T>(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteByKey(Tkey key)
        {
            CheckDispose();
            try
            {
                _context.Remove<T>(await GetByKey(key));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Edit(T item)
        {
            CheckDispose();
            try
            {
                _context.Set<T>().Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            CheckDispose();
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByKey(Tkey key)
        {
            return await GetItemByKeyAsync(key);
        }

        public abstract Task<T> GetItemByKeyAsync(Tkey key);

        public virtual Task<ICollection<T>> GetListBy(Func<T, bool> expression)
        {
            CheckDispose();
            return  Task.FromResult((ICollection<T>)_context.Set<T>().Where(expression).ToList());
        }

        protected void CheckDispose()
        {
            if(disposedValue)
            {
                throw new ObjectDisposedException("DBContext has been disposed");
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                _context.Dispose();
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepo() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
