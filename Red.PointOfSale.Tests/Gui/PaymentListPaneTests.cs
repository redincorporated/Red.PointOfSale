using System;
using NUnit.Framework;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Tests.Gui
{
    [TestFixture]
    public class PaymentListPaneTests
    {
        [Test]
        public void TestAddPayment()
        {
            var p = new PaymentListPane();
            var s = new SalesReceipt();
            s.AddItem(new Item("001", "Pencil", 12));
            s.AddItem(new Item("002", "Ballpen", 27));
            Assert.AreEqual(39, s.TotalAmount);
            p.Receipt = s;
            p.AddPayment(new Payment(100));
            Assert.AreEqual(61, s.TotalChange);
        }
    }
}
