using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScholarlySoftwareSearch.Models.Tests {
    [TestClass()]
    public class ClippedSoftwareTests {
        [TestMethod()]
        public void ClippedSoftwareTestEmptyEqual() {
            ClippedSoftware clippedSoftware = new ClippedSoftware();

            Assert.AreEqual("1", clippedSoftware.UploaderID);
            Assert.AreEqual("2", clippedSoftware.SoftwareID);
            Assert.AreEqual(DateTime.MinValue, clippedSoftware.ClipDate);
            Assert.AreEqual(0, clippedSoftware.Id);
        }

        [TestMethod()]
        public void ClippedSoftwareTestEmptyNotEqual() {
            ClippedSoftware clippedSoftware = new ClippedSoftware();

            Assert.AreNotEqual("2", clippedSoftware.UploaderID);
            Assert.AreNotEqual("1", clippedSoftware.SoftwareID);
            Assert.AreNotEqual(DateTime.Today, clippedSoftware.ClipDate);
            Assert.AreNotEqual(1, clippedSoftware.Id);
        }

        [TestMethod()]
        public void ClippedSoftwareTestConfirmEqual() {
            ClippedSoftware clippedSoftware = new ClippedSoftware("1e56", "2g52", DateTime.Today, 20);

            Assert.AreEqual("1e56", clippedSoftware.UploaderID);
            Assert.AreEqual("2g52", clippedSoftware.SoftwareID);
            Assert.AreEqual(DateTime.Today, clippedSoftware.ClipDate);
            Assert.AreEqual(20, clippedSoftware.Id);
        }

        [TestMethod()]
        public void ClippedSoftwareTestConfirmNotEqual() {
            ClippedSoftware clippedSoftware = new ClippedSoftware("1e56", "2g52", DateTime.Today, 20);

            Assert.AreNotEqual("2e56", clippedSoftware.UploaderID);
            Assert.AreNotEqual("1g52", clippedSoftware.SoftwareID);
            Assert.AreNotEqual(DateTime.MinValue, clippedSoftware.ClipDate);
            Assert.AreNotEqual(19, clippedSoftware.Id);
        }
    }
}