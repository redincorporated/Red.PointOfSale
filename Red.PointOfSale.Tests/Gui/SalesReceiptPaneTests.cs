using System;
using NUnit.Framework;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Tests.Gui
{
    [TestFixture]
    public class SalesReceiptPaneTests
    {
        SalesReceiptPane p;
        
        [SetUp]
        public void Setup()
        {
            p = new SalesReceiptPane();
        }
        
        [Test]
        public void TestEndOfDayReading()
        {
            p.ReadEndOfDay();
        }
        
        [Test]
        public void TestVoidItem()
        {
            p.VoidItem();
        }
        
        [Test]
        public void TestAddPayment()
        {
            p.AddPayment(new Payment());
        }
        
        [Test]
        public void TestVoid()
        {
            p.AddItem(new Item("001"));
            p.Void();
            Assert.AreEqual(0, p.Receipt.Items.Count);
        }
        
        [Test]
        public void TestSearchItem()
        {
            p.ItemSearch += delegate(object sender, ItemEventArgs e) { 
                Assert.AreEqual("001", e.Item.Code);
                p.AddItem(e.Item);
                Assert.AreEqual(1, p.Receipt.Items.Count);
            };
            p.SearchItem("001");
        }
        
        [Test]
        public void TestSearchCustomer()
        {
            p.CustomerSearch += delegate(object sender, CustomerEventArgs e) { 
                Assert.AreEqual("customer1", e.Customer.Code);
                p.Receipt.Customer = e.Customer;
                Assert.AreEqual("customer1", p.Receipt.Customer.Code);
            };
            p.SearchCustomer("customer1");
        }
        
        [Test]
        public void TestSave()
        {
            p.Save += delegate(object sender, SalesReceiptEventArgs e) { 
            };
            p.PerformSave();
        }
    }
}
