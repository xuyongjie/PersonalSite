using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Repo
{
    interface IBaseRepo<T,Tkey> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByKey(Tkey key);
        Task<IEnumerable<T>> GetListBy(Func<T,bool> expression);
        Task<T> Add(T item);
        Task<bool> Edit(T item);
        Task<bool> DeleteByKey(Tkey key);
        Task<int> DeleteBySQL(string sql);
    }
}
