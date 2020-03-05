using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red.PointOfSale.Helpers;

namespace Red.PointOfSale
{
    public partial class MainForm : Form
    {
        static MainForm instance = new MainForm();

        public static MainForm Instance {
            get { return instance; }
        }

        MainForm()
        {
            InitializeComponent();
            Text = Application.ProductName + " " + ApplicationHelper.GetVersion();
        }
        
        public DialogResult AddDialog(Control control)
        {
            var d = new Form();
            d.Controls.Clear();
            control.Dock = DockStyle.Fill;
            d.Controls.Add(control);
            
            return d.ShowDialog();
        }

        public void AddChild(Control control)
        {
            panel1.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel1.Controls.Add(control);
        }
    }
}
