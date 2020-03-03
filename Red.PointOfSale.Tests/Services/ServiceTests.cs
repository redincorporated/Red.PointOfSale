using System;
using NUnit.Framework;
using Red.PointOfSale.Models;
using Red.PointOfSale.Services;

namespace Red.PointOfSale.Tests.Services
{
    [TestFixture]
    public class ServiceTests
    {
        Service service;
        
        [SetUp]
        public void Setup()
        {
            string url = "http://pos-backend.scoollabs.com";
            string token = "BE823A6D-3D07-4134-B5F1-3364AF19FC81";
            service = new Service(url, token);
        }
        
        [Test]
        public void TestMethod()
        {
            service.ResponseReceived += delegate(object sender, ResponseEventArgs e) {
                if (e.Response.Data is Item) {
                    var item = e.Response.Data as Item;
                    Console.WriteLine(item);
                } else {
                    Console.WriteLine(e.Response.Message);
                }
            };
            service.PullItems();
        }
    }
}
