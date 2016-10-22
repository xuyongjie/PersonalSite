using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYJPersonalSite.Models.BusinessModels;

namespace XYJPersonalSite.Models.BusinessViewModels
{
    public class BlogDetailDTO
    {
        public BlogDetailDTO() { }
        public BlogDetailDTO(Blog blog,string tags)
        {
            Blog = blog;
            Tags = tags;
        }
        public Blog Blog { get; set; }
        /// <summary>
        /// looks like tag1,tag2,tag3
        /// split by ,
        /// </summary>
        public string Tags { get; set; }
    }
}
