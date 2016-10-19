
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Models.BusinessModels;
using XYJPersonalSite.Repo;

public class TagsRepo : BaseRepo<Tag, string>
{
    public TagsRepo(DbContext context) : base(context)
    {
    }
}