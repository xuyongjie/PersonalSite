using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Models.BusinessModels;

namespace XYJPersonalSite.Repo
{
    public class BlogsRepo : BaseRepo<Blog, int>
    {
        public BlogsRepo(DbContext context) : base(context)
        {
        }

        public override Blog GetItemByKey(int key)
        {
            return _context.Set<Blog>().FirstOrDefault(b => b.Id == key);
        }
    }
}
