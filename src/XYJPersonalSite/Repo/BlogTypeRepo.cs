using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Models.BusinessModels;

namespace XYJPersonalSite.Repo
{
    public class BlogTypeRepo : BaseRepo<BlogType, string>
    {
        public BlogTypeRepo(DbContext context) : base(context)
        {
        }

        public override async Task<BlogType> GetItemByKeyAsync(string key)
        {
            CheckDispose();
            return await _context.Set<BlogType>().Where(b => b.TypeName == key).FirstOrDefaultAsync();
        }
    }
}
