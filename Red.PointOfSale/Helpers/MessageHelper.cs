using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Red.PointOfSale.Helpers
{
    public class MessageHelper
    {
        public static void ShowWarning(string text)
        {
            MessageBox.Show(MainForm.Instance, text, "Warning", MessageBoxButtons.OK);
        }
    }
}
