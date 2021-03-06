﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Red.PointOfSale.Gui
{
    public partial class NumPane : UserControl
    {
        public NumPane() : this(false)
        {
        }

        public string Value {
            get { return textBox1.Text;  }
            set { textBox1.Text = value; }
        }

        public NumPane(bool isPassword)
        {
            InitializeComponent();
            this.IsPassword = isPassword;
        }
        
        public void PerformGo(string @value)
        {
            textBox1.Text = @value;
            buttonGo_Click(this, null);
        }

        public bool IsPassword {
            set {
                if (value) {
                    textBox1.PasswordChar = '*';
                }
            }
        }
        
        public void Clear()
        {
            buttonClear_Click(this, null);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        public event EventHandler Go;

        protected virtual void OnGo(EventArgs e)
        {
            if (Go != null) {
                Go(this, e);
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            OnGo(null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }
    }
}
