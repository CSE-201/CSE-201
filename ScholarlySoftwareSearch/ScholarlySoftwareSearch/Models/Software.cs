using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Models {
    public class Software {

        public int Id { get; set; }
        
        public string Authors { get; set; }
        
        public string UploaderID { get; set; }
       
        public DateTime UploadDate { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public string DownloadURL { get; set; }

        public string Tag { get; set; }

    }
}
