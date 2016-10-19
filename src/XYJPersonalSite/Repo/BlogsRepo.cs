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


        public override async Task<Blog> GetItemByKeyAsync(int key)
        {
            CheckDispose();
            return await _context.Set<Blog>().FirstOrDefaultAsync(b => b.Id == key);
        }


        public override Task<ICollection<Blog>> GetListBy(Func<Blog, bool> expression)
        {
            CheckDispose();
            return Task.FromResult((ICollection<Blog>)_context.Set<Blog>().Include(b=>b.PostUser).Where(expression).OrderByDescending(b => b.CreateTime).ToList());
        }

        public override async Task<ICollection<Blog>> GetAll()
        {
            CheckDispose();
            return await _context.Set<Blog>().Include(b=>b.PostUser).OrderByDescending(e=>e.CreateTime).ToListAsync();
        }
    }
}
