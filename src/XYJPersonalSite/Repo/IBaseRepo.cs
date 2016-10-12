using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Repo
{
    interface IBaseRepo<T,Tkey> where T: class
    {
        ICollection<T> GetAll();
        T GetByKey(Tkey key);
        ICollection<T> GetListBy(Func<T,bool> expression);
        T Add(T item);
        bool Edit(T item);
        bool DeleteByKey(Tkey key);
    }
}
