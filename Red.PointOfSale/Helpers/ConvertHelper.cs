using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.PointOfSale.Helpers
{
    public class ConvertHelper
    {
        public static int ToInt32(object val)
        {
            return ToInt32(val, 0);
        }

        public static int ToInt32(object val, int ret)
        {
            try {
                return Convert.ToInt32(val);
            } catch {
                return ret;
            }
        }

        public static double ToDouble(object val)
        {
            return ToDouble(val, 0);
        }

        public static double ToDouble(object val, int ret)
        {
            try {
                return Convert.ToDouble(val);
            } catch {
                return ret;
            }
        }
    }
}
