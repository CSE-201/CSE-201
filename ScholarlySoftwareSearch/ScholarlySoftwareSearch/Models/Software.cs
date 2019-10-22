using System;

namespace ScholarlySoftwareSearch.Models {
    public class Software {

        /// <summary>
        /// Creates an instance of Software with default values.
        /// Id = 0, Authors = string.Empty, UploadID = string.Empty, UploadDate = DateTime.MinValue, 
        /// Description = string.Empty, Publisher = string.Empty, DownloadURL = string.Empty, and
        /// Tag = string.Empty.
        /// </summary>
        public Software() {
            Id = 0;
            SoftwareName = string.Empty;
            Authors = string.Empty;
            UploaderID = string.Empty;
            UploadDate = DateTime.MinValue;
            Description = string.Empty;
            Publisher = string.Empty;
            DownloadURL = string.Empty;
            Tag = string.Empty;
        }

        public Software(int id, string softwareName, string authors, string uploaderID, DateTime uploadDate,
                        string description, string publisher, string downloadURL, string tag) {
            Id = id;
            SoftwareName = softwareName;
            Authors = authors;
            UploaderID = uploaderID;
            UploadDate = uploadDate;
            Description = description;
            Publisher = publisher;
            DownloadURL = downloadURL;
            Tag = tag;
        }

        public int Id { get; set; }
        public string SoftwareName { get; set; }

        public string Authors { get; set; }

        public string UploaderID { get; set; }

        public DateTime UploadDate { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public string DownloadURL { get; set; }

        public string Tag { get; set; }

    }
}
