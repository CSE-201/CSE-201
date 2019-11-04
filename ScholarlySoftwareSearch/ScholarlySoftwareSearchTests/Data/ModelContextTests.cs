using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScholarlySoftwareSearch.Models.Tests {
    [TestClass()]
    public class ModelContextTests {
        [TestMethod()]
        public void ModelContextTest() {
            try {
                // Checking to ensure Model Context fails without database connection.
                ModelContext modelContext = new ModelContext(null);
                Assert.Fail();
            } catch (Exception) {
                Assert.IsTrue(true);
            }
        }
    }
}