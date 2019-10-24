using ScholarlySoftwareSearch.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScholarlySoftwareSearch.Models.Tests {
    [TestClass()]
    public class SoftwareTests {
        [TestMethod()]
        public void SoftwareTest() {
            Software software = new Software();

            // Should pass.
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

            // Tests that should pass -> They are equal.
            Assert.AreEqual(1, software.Id);
            Assert.AreEqual("SoftwareName", software.SoftwareName);
            Assert.AreEqual("Jubal Foo", software.Authors);
            Assert.AreEqual("1e56", software.UploaderID);
            Assert.AreEqual(DateTime.Today, software.UploadDate);
            Assert.AreEqual("This is a description.", software.Description);
            Assert.AreEqual("Jubal Foo Inc.", software.Publisher);
            Assert.AreEqual("www.jubalfoo.com", software.DownloadURL);
            Assert.AreEqual("Bioinformatics", software.Tag);

            // Tests that should fail -> They are not equal.
            Assert.AreNotEqual(2, software.Id);
            Assert.AreNotEqual("SoftwareCame", software.SoftwareName);
            Assert.AreNotEqual("Jubal Coo", software.Authors);
            Assert.AreNotEqual("1e52", software.UploaderID);
            Assert.AreNotEqual(DateTime.MinValue, software.UploadDate);
            Assert.AreNotEqual("This a description.", software.Description);
            Assert.AreNotEqual("Bubal Foo Inc.", software.Publisher);
            Assert.AreNotEqual("www.bubalfoo.com", software.DownloadURL);
            Assert.AreNotEqual("Bioformatics", software.Tag);
        }

        [TestMethod()]
        public void ToStringTest() {
            Software software = new Software(1, "SoftwareName", "Jubal Foo", "1e56", DateTime.Today, "This is a description.",
                                                "Jubal Foo Inc.", "www.jubalfoo.com", "Bioinformatics");

            // Should pass -> Equal.
            Assert.AreEqual("1 SoftwareName Jubal Foo 1e56 " + DateTime.Today.ToString() + " This is a description. Jubal Foo Inc. www.jubalfoo.com Bioinformatics", software.ToString());

            // Should fail -> Not equal.
            Assert.AreNotEqual("2    SoftwareName Jubal Foo 1e56 " + DateTime.Today.ToString() + " This is a . Jubal Foo Inc. www.jubalfooatics", software.ToString());

        }
    }
}