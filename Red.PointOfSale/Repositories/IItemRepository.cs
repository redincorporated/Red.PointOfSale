using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories
{
    public interface IItemRepository
    {
        Item ReadByCode(string code);
    }
}
