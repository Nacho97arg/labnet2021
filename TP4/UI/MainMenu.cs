using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace TP4.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TsbCustomersMenu_Click(object sender, EventArgs e)
        {
            new CustomersMenu().ShowDialog();
        }

        private void TsbSuppliersMenu_Click(object sender, EventArgs e)
        {
            new SuppliersMenu().ShowDialog();
        }
    }
}
