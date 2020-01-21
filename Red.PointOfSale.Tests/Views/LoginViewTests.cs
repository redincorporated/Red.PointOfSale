using System;
using NUnit.Framework;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Tests.Views
{
    [TestFixture]
    public class LoginViewTests
    {
        [SetUp]
        public void Setup()
        {
            ApplicationHelper.Attach(new ConsoleApplication());
        }
        
        [Test]
        public void TestMethod()
        {
            var v = new ConsoleLoginView();
            ApplicationHelper.Show(v);
        }
    }
}
