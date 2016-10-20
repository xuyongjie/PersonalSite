using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYJPersonalSite.Data;
using XYJPersonalSite.Models.BusinessModels;

namespace XYJPersonalSite.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.MediaTypes.Any())
                {
                    context.MediaTypes.AddRange(new MediaType
                    {
                        Name = MediaType.IMAGE
                    }, new MediaType
                    {
                        Name = MediaType.VIDEO
                    }, new MediaType
                    {
                        Name = MediaType.AUDIO
                    }, new MediaType
                    {
                        Name = MediaType.HTML
                    }, new MediaType
                    {
                        Name = MediaType.TXT
                    }, new MediaType
                    {
                        Name = MediaType.MARKDOWN
                    });
                }
                if(!context.BlogTypes.Any())
                {
                    context.BlogTypes.AddRange(new BlogType{
                        TypeName=BlogType.TECH,
                        TypeDesc=BlogType.TECH_DESC,
                        ThisTypeBlogCount=0
                    },new BlogType{
                        TypeName=BlogType.LIFE,
                        TypeDesc=BlogType.LIFE_DESC,
                        ThisTypeBlogCount=0
                    }, new BlogType{
                        TypeName=BlogType.IDEA,
                        TypeDesc=BlogType.IDEA_DESC,
                        ThisTypeBlogCount=0
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
