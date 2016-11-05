using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Models.BusinessModels
{
    public class Comment:ModelBase
    {
        public const int DEFAUT_TO_COMMENTID = -1;
        public int Id { get; set; }
        public string BlogId { get; set; }
        public Blog Blog { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int ToCommentId { get; set; }
        [NotMapped]
        public string VerificationCode { get; set; }
    }
}
