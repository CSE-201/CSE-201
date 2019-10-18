using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScholarlySoftwareSearch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScholarlySoftwareSearch.Models.Tests {
    [TestClass()]
    public class ClippedSoftwareTests {
        [TestMethod()]
        public void ClippedSoftwareTest() {
            ClippedSoftware clippedSoftware = new ClippedSoftware();

            Assert.AreEqual("1", clippedSoftware.UploaderID);
            Assert.AreEqual("2", clippedSoftware.SoftwareID);
            Assert.AreEqual(DateTime.MinValue, clippedSoftware.ClipDate);

        }

        [TestMethod()]
        public void ClippedSoftwareTest1() {
            ClippedSoftware clippedSoftware = new ClippedSoftware("1e56", "2g52", DateTime.Today);

            Assert.AreEqual("1e56", clippedSoftware.UploaderID);
            Assert.AreEqual("2g52", clippedSoftware.SoftwareID);
            Assert.AreEqual(DateTime.Today, clippedSoftware.ClipDate);
        }
    }
}