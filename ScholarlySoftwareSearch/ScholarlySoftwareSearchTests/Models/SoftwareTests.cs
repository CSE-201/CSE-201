using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScholarlySoftwareSearch.Models.Tests {
    [TestClass()]
    public class SoftwareTests {
        [TestMethod()]
        public void SoftwareTest() {
            Software software = new Software();

            Assert.AreEqual(0, software.Id);
            Assert.AreEqual(string.Empty, software.SoftwareName);
            Assert.AreEqual(string.Empty, software.Authors);
            Assert.AreEqual(string.Empty, software.UploaderID);
            Assert.AreEqual(DateTime.MinValue, software.UploadDate);
            Assert.AreEqual(string.Empty, software.Description);
            Assert.AreEqual(string.Empty, software.Publisher);
            Assert.AreEqual(string.Empty, software.DownloadURL);
            Assert.AreEqual(string.Empty, software.Tag);
        }

        [TestMethod()]
        public void SoftwareTestParams() {
            Software software = new Software(1, "SoftwareName", "Jubal Foo", "1e56", DateTime.Today, "This is a description.",
                                                "Jubal Foo Inc.", "www.jubalfoo.com", "Bioinformatics");

            Assert.AreEqual(1, software.Id);
            Assert.AreEqual("SoftwareName", software.SoftwareName);
            Assert.AreEqual("Jubal Foo", software.Authors);
            Assert.AreEqual("1e56", software.UploaderID);
            Assert.AreEqual(DateTime.Today, software.UploadDate);
            Assert.AreEqual("This is a description.", software.Description);
            Assert.AreEqual("Jubal Foo Inc.", software.Publisher);
            Assert.AreEqual("www.jubalfoo.com", software.DownloadURL);
            Assert.AreEqual("Bioinformatics", software.Tag);
        }
    }
}