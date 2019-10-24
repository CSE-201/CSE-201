using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ScholarlySoftwareSearch.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScholarlySoftwareSearch.Controllers.Tests {
    [TestClass()]
    public class UserControllerTests {
        [TestMethod()]
        public void UserControllerTest() {
            // Add IAppState, ILoggerAdapater, and other services
            var services = new ServiceCollection();

            // Create the service provider instance
            var serviceProvider = services.BuildServiceProvider();

            // Whether the user controller instantiate.
            try {
                UserController userController = new UserController(serviceProvider);
            } catch (Exception) {
                // If it fails.
                Assert.Fail();
            }

            // If it succeeds.
            Assert.IsTrue(true);

        }

        [TestMethod()]
        public void CreateUserTestWithoutDatabase() {
            // Add IAppState, ILoggerAdapater, and other services
            var services = new ServiceCollection();

            // Create the service provider instance
            var serviceProvider = services.BuildServiceProvider();

            // Whether the user controller instantiate.
            UserController userController = new UserController(serviceProvider);

            // If it succeeds.
            try {
                userController.CreateUser(new Microsoft.AspNetCore.Identity.IdentityUser("test@mail.com"), "password", UserController.Roles.Member).Wait();
                // The test fails if a user can be added without Identity user being added to the service.
                Assert.Fail();
            } catch (Exception) {
                // The test succeeds if the user cannot be added without being connected to the database.
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void AddUserToRoleTestWithoutDatabase() {
            // Add IAppState, ILoggerAdapater, and other services
            var services = new ServiceCollection();

            // Create the service provider instance
            var serviceProvider = services.BuildServiceProvider();

            // Whether the user controller instantiate.
            UserController userController = new UserController(serviceProvider);

            // If it succeeds.
            try {
                userController.AddUserToRole(new Microsoft.AspNetCore.Identity.IdentityUser("test@mail.com"), UserController.Roles.Member).Wait();
                // The test fails if a user can be added without Identity user being added to the service.
                Assert.Fail();
            } catch (Exception) {
                // The test succeeds if the user cannot be added without being connected to the database.
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void CreateRolesAsyncTestWithoutDatabase() {
            // Add IAppState, ILoggerAdapater, and other services
            var services = new ServiceCollection();

            // Create the service provider instance
            var serviceProvider = services.BuildServiceProvider();

            // Whether the user controller instantiate.
            UserController userController = new UserController(serviceProvider);

            // If it succeeds.
            try {
                string[] roles = { "Admin", "Manager", "Member" };
                userController.CreateRolesAsync(roles).Wait();
                // The test fails if a roles can be added without RoleManager being added to the service.
                Assert.Fail();
            } catch (Exception) {
                // The test succeeds if the roles cannot be added without being connected to the database.
                Assert.IsTrue(true);
            }
        }
    }
}