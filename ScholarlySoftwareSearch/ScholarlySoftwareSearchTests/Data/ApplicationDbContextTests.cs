using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScholarlySoftwareSearch.Data.Tests {
    [TestClass()]
    public class ApplicationDbContextTests {
        [TestMethod()]
        public void ApplicationDbContextTest() {
            try {
                // Checking to ensure ApplicationDbContext fails without database connection.
                ApplicationDbContext applicationDbContext = new ApplicationDbContext(null);
                Assert.Fail();
            } catch (Exception) {
                Assert.IsTrue(true);
            }
        }
    }
}