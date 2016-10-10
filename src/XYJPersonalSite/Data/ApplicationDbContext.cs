using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Models;
using XYJPersonalSite.Models.BusinessModels;

namespace XYJPersonalSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BlogTag>().HasKey(bt => new { bt.BlogId, bt.TagName });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is ModelBase && (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(e => e.Entity as ModelBase))
            {
                history.ModifyTime = DateTime.Now;
                if (history.CreateTime == DateTime.MinValue)
                {
                    history.CreateTime = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
