using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Models.BusinessModels
{
    public class BlogTag
    {
        public BlogTag(int blogId,string tagName)
        {
            BlogId = blogId;
            TagName = tagName;
        }
        public BlogTag() { }
        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        [Required]
        public string TagName { get; set; }
        public Tag Tag { get; set; }
    }
}
