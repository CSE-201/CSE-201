using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScholarlySoftwareSearch.Data;
using System;
using System.Collections.Generic;
using System.Text;

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