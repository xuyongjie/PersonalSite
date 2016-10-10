using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Models.BusinessModels
{
    public class ModelBase
    {
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]
        public DateTime ModifyTime { get; set; }
    }
}
