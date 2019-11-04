using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScholarlySoftwareSearch.Models.Tests {
    [TestClass()]
    public class SoftwareTests {
        [TestMethod()]
        public void SoftwareTestEmptySuccess() {
            Software software = new Software();

            // Checks if software is created with it's default values.
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
        public void SoftwareTestEmptyFail() {
            Software software = new Software();

            // Checks if software is created with it's default values.
            Assert.AreEqual(1, software.Id);
            Assert.AreEqual(" ", software.SoftwareName);
            Assert.AreEqual(" ", software.Authors);
            Assert.AreEqual(" ", software.UploaderID);
            Assert.AreEqual(DateTime.Today, software.UploadDate);
            Assert.AreEqual(" ", software.Description);
            Assert.AreEqual(" ", software.Publisher);
            Assert.AreEqual(" ", software.DownloadURL);
            Assert.AreEqual(" ", software.Tag);
        }

        [TestMethod()]
        public void SoftwareTestConfirmSuccess() {
            Software software = new Software(1, "SoftwareName", "Jubal Foo", "1e56", DateTime.Today, "This is a description.",
                                                "Jubal Foo Inc.", "www.jubalfoo.com", "Bioinformatics");

            // Tests if the software parameters assigned correctly and are equal to the correct values.
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

        [TestMethod()]
        public void SoftwareTestConfirmFail () {
            Software software = new Software(1, "SoftwareName", "Jubal Foo", "1e56", DateTime.Today, "This is a description.",
                                    "Jubal Foo Inc.", "www.jubalfoo.com", "Bioinformatics");

            // Tests if the software parameters assigned correctly and are not equal to the incorrect values.
            Assert.AreEqual(2, software.Id);
            Assert.AreEqual("SoftwareCame", software.SoftwareName);
            Assert.AreEqual("Jubal Coo", software.Authors);
            Assert.AreEqual("1e52", software.UploaderID);
            Assert.AreEqual(DateTime.MinValue, software.UploadDate);
            Assert.AreEqual("This a description.", software.Description);
            Assert.AreEqual("Bubal Foo Inc.", software.Publisher);
            Assert.AreEqual("www.bubalfoo.com", software.DownloadURL);
            Assert.AreEqual("Bioformatics", software.Tag);
        }

        [TestMethod()]
        public void ToStringTestSuccess() {
            Software software = new Software(1, "SoftwareName", "Jubal Foo", "1e56", DateTime.Today, "This is a description.",
                                                "Jubal Foo Inc.", "www.jubalfoo.com", "Bioinformatics");

            // Tests if to string output correctly.
            Assert.AreEqual("1 SoftwareName Jubal Foo 1e56 " + DateTime.Today.ToString() + " This is a description. Jubal Foo Inc. www.jubalfoo.com Bioinformatics", software.ToString());
        }

        [TestMethod()]
        public void ToStringTestFail () {
            Software software = new Software(1, "SoftwareName", "Jubal Foo", "1e56", DateTime.Today, "This is a description.",
                                    "Jubal Foo Inc.", "www.jubalfoo.com", "Bioinformatics");

            // Tests if to string outputs incorrectly.
            Assert.AreEqual("2    SoftwareName Jubal Foo 1e56 " + DateTime.Today.ToString() + " This is a . Jubal Foo Inc. www.jubalfooatics", software.ToString());
        }
    }
}