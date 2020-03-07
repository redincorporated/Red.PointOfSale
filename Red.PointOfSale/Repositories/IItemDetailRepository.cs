using System;
using System.Collections.Generic;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories
{
    public interface IItemDetailRepository : IBaseRepository<ItemDetail>
    {
        List<ItemDetail> FindByItem(int itemId);
    }
}
