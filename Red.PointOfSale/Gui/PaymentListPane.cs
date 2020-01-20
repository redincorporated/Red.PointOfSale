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
    public partial class PaymentListPane : UserControl
    {
        List<Payment> payments;
        
        public PaymentListPane()
        {
            InitializeComponent();
        }
        
        public void AddPayment(Payment payment)
        {
            payments.Add(payment);
        }
        
        public event EventHandler Pay;
        
        protected virtual void OnPay(EventArgs e)
        {
            if (Pay != null) {
                Pay(this, e);
            }
        }
    }
}
