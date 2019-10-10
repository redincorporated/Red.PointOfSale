using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Gui
{
    public partial class LoginPane : UserControl
    {
        public LoginPane()
        {
            InitializeComponent();

            usernamePane.Go += delegate (object sender, EventArgs e) {
                AddChild(passwordPane);
            };
            passwordPane.Go += delegate (object sender, EventArgs e) {
                OnLogin(new UserEventArgs(new User(usernamePane.Value, passwordPane.Value)));
            };

            AddChild(usernamePane);
        }

        public event EventHandler<UserEventArgs> Login;

        protected virtual void OnLogin(UserEventArgs e)
        {
            if (Login != null) {
                Login(this, e);
            }
        }

        void AddChild(Control control)
        {
            panel1.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel1.Controls.Add(control);
        }

        NumPane usernamePane = new NumPane();
        NumPane passwordPane = new NumPane(true);
    }
}
