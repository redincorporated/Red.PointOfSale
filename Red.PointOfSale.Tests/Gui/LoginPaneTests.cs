using System;
using NUnit.Framework;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Tests.Gui
{
    [TestFixture]
    public class LoginPaneTests
    {
        [Test]
        public void TestMethod()
        {
            var p = new LoginPane();
            p.Login += delegate(object sender, UserEventArgs e) { 
                Assert.AreEqual("admin", e.User.Username);
                Assert.AreEqual("password", e.User.Password);
            };
            
            p.PerformLogin("admin", "password");
        }
    }
}
