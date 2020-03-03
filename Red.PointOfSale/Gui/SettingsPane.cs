using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Gui
{
    public partial class SettingsPane : UserControl, ISettingsView
    {
        public SettingsPane()
        {
            InitializeComponent();
        }
        
        public event EventHandler ItemsSync;
        
        protected virtual void OnItemsSync(EventArgs e)
        {
            if (ItemsSync != null) {
                ItemsSync(this, e);
            }
        }
        
        void Button1Click(object sender, EventArgs e)
        {
            OnItemsSync(e);
        }
    }
}
