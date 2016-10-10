using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Models.BusinessModels
{
    public class Media:ModelBase
    {
        public int Id { get; set; }
        [Required]
        public string MediaTypeName { get; set; }
        public MediaType MediaType { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
