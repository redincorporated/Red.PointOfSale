using System;
using NSubstitute;
using NUnit.Framework;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Models;
using Red.PointOfSale.Repositories;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        [Test]
        public void TestMethod()
        {
            var userRepo = Substitute.For<IUserRepository>();
            userRepo.ReadByUsernameAndPassword("root", "toor").Returns(new User("root", "toor"));
            var loginView = Substitute.For<ILoginView>();
            var controller = new UserController(userRepo, loginView);
            
            controller.Login();
            
            loginView.PerformLogin("root", "toor");
        }
    }
}
