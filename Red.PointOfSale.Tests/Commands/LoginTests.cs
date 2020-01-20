using System;
using NUnit.Framework;
using Red.PointOfSale.Commands;

namespace Red.PointOfSale.Tests.Commands
{
    [TestFixture]
    public class LoginTests
    {
        [Test]
        public void TestMethod()
        {
            var c = new Login();
            c.Run();
        }
    }
}
