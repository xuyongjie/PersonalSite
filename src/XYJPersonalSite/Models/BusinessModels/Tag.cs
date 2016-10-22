using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Models.BusinessModels
{
    public class Tag
    {
        public Tag(string tagName)
        {
            TagName = tagName;
        }
        public Tag() { }
        [Key]
        public string TagName { get; set; }

    }
}
