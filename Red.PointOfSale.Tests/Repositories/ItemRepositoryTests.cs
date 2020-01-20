using System;
using NUnit.Framework;
using Red.PointOfSale.Repositories.MySql;

namespace Red.PointOfSale.Tests.Repositories
{
    [TestFixture]
    public class ItemRepositoryTests
    {
        [Test]
        public void TestMethod()
        {
            var r = new MySqlItemRepository();
            var item = r.ReadByCode("001");
        }
    }
}
