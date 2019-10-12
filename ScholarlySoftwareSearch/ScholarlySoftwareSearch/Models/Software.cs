using System;

namespace Scholary_Software_Search.Models {
    public class Software {
        [System.ComponentModel.DataAnnotations.Key]
        public string UrlAddress { get; set; }
        public string SoftwareName { get; set; }
        public int CitedArticles { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}