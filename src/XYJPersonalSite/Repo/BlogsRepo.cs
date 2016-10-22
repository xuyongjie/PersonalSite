using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Models.BusinessModels;
using XYJPersonalSite.Models.BusinessViewModels;
using System.Text;

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
            return await _context.Set<Blog>().Include(b => b.Comments).FirstOrDefaultAsync(b => b.Id == key);
        }


        public override Task<IEnumerable<Blog>> GetListBy(Func<Blog, bool> expression)
        {
            CheckDispose();
            return Task.FromResult((IEnumerable<Blog>)_context.Set<Blog>().Include(b => b.PostUser).Where(expression).OrderByDescending(b => b.CreateTime).ToList());
        }

        public override async Task<IEnumerable<Blog>> GetAll()
        {
            CheckDispose();
            return await _context.Set<Blog>().Include(b => b.PostUser).OrderByDescending(e => e.CreateTime).ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetByTag(string tagName)
        {
            CheckDispose();
            var query = from b in _context.Set<Blog>() join resultbt in (from bt in _context.Set<BlogTag>() where bt.TagName == tagName select bt) on b.Id equals resultbt.BlogId select b;
            return await query.ToListAsync(); 
        }

        public async Task<IEnumerable<Blog>> Search(string searchString)
        {
            var tagQuery = from t in _context.Set<Tag>() where t.TagName.Contains(searchString) select t;
            List<Blog> blogs = new List<Blog>();
            foreach(var item in await tagQuery.ToListAsync())
            {
                blogs.AddRange(await GetByTag(item.TagName));
            }
            return blogs;
        }

        public async Task<BlogDetailDTO> GetBlogDetail(int blogId)
        {
            Blog blog=await GetItemByKeyAsync(blogId);
            if(blog==null)
            {
                throw new ArgumentException("blogid not exist");    
            }
            BlogTagRepo blogTagRepo = new BlogTagRepo(_context);
            var tags = await blogTagRepo.GetTagsByBlogId(blogId);
            StringBuilder builder = new StringBuilder();
            int index = 0;
            foreach(var item in tags)
            {
                index++;
                builder.Append(item.TagName);
                if(index<tags.Count())
                {
                    builder.Append(',');
                }
            }
            BlogDetailDTO blogDetail = new BlogDetailDTO(blog,builder.ToString());
            return blogDetail;
        }
    }
}
