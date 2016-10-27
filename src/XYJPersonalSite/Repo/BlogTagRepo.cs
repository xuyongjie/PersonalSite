using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Models.BusinessModels;

namespace XYJPersonalSite.Repo
{
    public class BlogTagRepo : BaseRepo<BlogTag, KeyValuePair<string,string>>
    {
        public BlogTagRepo(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// get blogtag by blogid and tagname
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override async Task<BlogTag> GetItemByKeyAsync(KeyValuePair<string, string> key)
        {
            CheckDispose();
            return await _context.Set<BlogTag>().Where(bt => bt.BlogId == key.Key && bt.TagName == key.Value).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tag>> GetTagsByBlogId(string blogId)
        {
            var query = from bt in _context.Set<BlogTag>().Include(bt=>bt.Tag) where bt.BlogId == blogId select bt.Tag;
            return await query.ToListAsync();
        }
    }
}
