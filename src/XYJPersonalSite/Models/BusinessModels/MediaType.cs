using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XYJPersonalSite.Models.BusinessModels
{
    public class MediaType
    {
        public const string IMAGE = "image";
        public const string VIDEO = "video";
        public const string AUDIO = "audio";
        public const string HTML = "html";
        public const string TXT = "txt";
        public const string MARKDOWN = "markdown";
        [Key]
        public string Name { get; set; }
    }
}
