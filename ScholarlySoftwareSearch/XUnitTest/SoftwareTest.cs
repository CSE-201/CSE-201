using ScholarlySoftwareSearch.Models;
using Xunit;

namespace XUnitTest {
    public class SoftwareTest {

        Software _software;

        public SoftwareTest () {
            _software = new Software();

            _software.Id = 1;
            _software.Authors = "Jubal Foo";
            _software.UploaderID = "2";
            _software.UploadDate = new System.DateTime(2019, 10, 14, 5, 32, 0);
            _software.Description = "This is a description.";
            _software.Publisher = "Foo Inc.";
            _software.DownloadURL = "www.fooinc.com";
            _software.Tag = "research, software";

        }

        [Fact]
        public void GetId () {
            Assert.Equal(1, _software.Id);
        }

        [Fact]
        public void GetAuthors() {
            Assert.Equal("Jubal Foo", _software.Authors);
        }


    }
}
