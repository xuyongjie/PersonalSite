
using System;
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Models.BusinessModels;
using XYJPersonalSite.Repo;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TagsRepo : BaseRepo<Tag, string>
{
    public TagsRepo(DbContext context) : base(context)
    {
    }

    public override async Task<Tag> GetItemByKeyAsync(string key)
    {
        CheckDispose();
        return await _context.Set<Tag>().FirstOrDefaultAsync(t => t.TagName == key);
    }

    public async Task<ICollection<Tag>> GetTop(int count)
    {
        CheckDispose();
        var query =from bt in _context.Set<BlogTag>() group bt by bt.TagName into nbt select new
        KeyValuePair<string, int>(nbt.Key, nbt.Count());
        return await query.OrderByDescending(k => k.Value).Take(count).Select(k => new Tag { TagName = k.Key }).ToListAsync();
    }
}