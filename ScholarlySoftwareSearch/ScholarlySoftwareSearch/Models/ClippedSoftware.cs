using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Models {
    public class ClippedSoftware {


        /// <summary>
        /// Creates an instance of ClippedSoftware with default values.
        /// UploaderID = "1", SoftwareID = "2", and ClipDate = DateTime.MinValue.
        /// </summary>
        public ClippedSoftware() {
            UploaderID = "1";
            SoftwareID = "2";
            ClipDate = DateTime.MinValue;
            Id = 0;
        }

        /// <summary>
        /// Creates an instance of ClippedSoftware.
        /// </summary>
        /// <param name="uploaderID"></param>
        /// <param name="softwareID"></param>
        /// <param name="clipDate"></param>
        public ClippedSoftware(string uploaderID, string softwareID, DateTime clipDate, int id) {
            UploaderID = uploaderID;
            SoftwareID = softwareID;
            ClipDate = clipDate;
            Id = id;
        }

        public int Id { get; set; }
        public string UploaderID { get; set; }

        public string SoftwareID { get; set; }

        public DateTime ClipDate { get; set; }
    }
}
