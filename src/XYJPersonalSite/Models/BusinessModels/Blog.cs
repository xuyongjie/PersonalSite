using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Models.BusinessModels
{
    public class Blog : ModelBase
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        public string Content { get; set; }
        public int ReadCount { get; set; }
        public int LikeCount { get; set; }
        public List<Comment> Comments { get; set; }
        public string PostUserId { get; set; }
        public ApplicationUser PostUser { get; set; }
        public string TypeName{get;set;}
        public BlogType BlogType{get;set;}
    }
}
