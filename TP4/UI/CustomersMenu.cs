using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP4.Logic;
using TP4.Entities;

namespace TP4.UI
{
    public partial class CustomersMenu : Form
    {
        private readonly CustomerLogic customerLogic;
        public CustomersMenu()
        {
            customerLogic = new CustomerLogic();
            InitializeComponent();
            SetDataSource();
        }

        private void SetDataSource()
        {
            try
            {
                dgvCustomers.DataSource = customerLogic.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show($"An error occurred while trying to connect to the database\n{e.Message}", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbCreate_Click(object sender, EventArgs e)
        {
            new CustomerForm(customerLogic).ShowDialog();
            SetDataSource();
        }

        private void TsbUpdate_Click(object sender, EventArgs e)
        {
            Customers dgvSelectedCustomer = (Customers)dgvCustomers.SelectedRows[0].DataBoundItem;
            new CustomerForm(dgvSelectedCustomer, customerLogic).ShowDialog();
            SetDataSource();
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Customers dgvSelectedCustomer = (Customers)dgvCustomers.SelectedRows[0].DataBoundItem;
                customerLogic.DeleteOne(dgvSelectedCustomer);
                SetDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"This customer forms part of an order. Please delete that order first\nError message:\n{ex.InnerException.InnerException.Message}", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
