using System;
using System.Windows.Forms;
using TP4.Common.CustomExceptions;
using TP4.Entities;
using TP4.Logic;

namespace TP4.UI
{
    public partial class CustomersMenu : Form
    {
        private readonly ILogic<Customers> customerLogic;
        public CustomersMenu()
        {
            customerLogic = new CustomerLogic();
            InitializeComponent();
            SetDataSource();
        }

        private void SetDataSource()
        {
            dgvCustomers.DataSource = customerLogic.GetAll();            
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
            catch (DatabaseIntegrityException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
