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
    public partial class CustomerForm : Form
    {
        private readonly CustomerLogic customerLogic;
        private Customers selectedCustomer;
        private readonly Mode mode;
        public CustomerForm(CustomerLogic customerLogic)
        {
            InitializeComponent();
            mode = Mode.New;
            this.customerLogic = customerLogic;
        }
        public CustomerForm(Customers customer, CustomerLogic customerLogic) : this(customerLogic)
        {
            mode = Mode.Modify;
            selectedCustomer = customer;
            FillControls();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (mode)
                {
                    case Mode.New:
                        Customers newCustomer = new Customers();
                        newCustomer = FillCustomerMembers(newCustomer);
                        if ((newCustomer.CompanyName == "") || (newCustomer.CustomerID == ""))
                            throw new Exception("Verify that the required fields have been completed");
                        else
                            this.customerLogic.AddOne(newCustomer);
                        break;
                    case Mode.Modify:
                        selectedCustomer = FillCustomerMembers(selectedCustomer);
                        this.customerLogic.Update();
                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to save the customer\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        Customers FillCustomerMembers(Customers customer)
        {
            if (int.TryParse(tbCustomerID.Text, out int parsed))
                throw new Exception("The customer ID can only be made up of letters");
            else
            {
                customer.CustomerID = tbCustomerID.Text.ToUpper();
                customer.CompanyName = tbCompanyName.Text;
                customer.ContactName = tbContactName.Text;
                customer.ContactTitle = tbContactTitle.Text;
                customer.Address = tbAddress.Text;
                customer.City = tbCity.Text;
                customer.Region = tbRegion.Text;
                customer.PostalCode = tbPostalCode.Text;
                customer.Country = tbCountry.Text;
                customer.Phone = tbPhone.Text;
                customer.Fax = tbFax.Text;
            }
            return customer;
        }
        void FillControls()
        {
            tbCustomerID.Text = selectedCustomer.CustomerID;
            tbCompanyName.Text = selectedCustomer.CompanyName;
            tbContactName.Text = selectedCustomer.ContactName;
            tbContactTitle.Text = selectedCustomer.ContactTitle;
            tbAddress.Text = selectedCustomer.Address;
            tbCity.Text = selectedCustomer.City;
            tbRegion.Text = selectedCustomer.Region;
            tbPostalCode.Text = selectedCustomer.PostalCode;
            tbCountry.Text = selectedCustomer.Country;
            tbPhone.Text = selectedCustomer.Phone;
            tbFax.Text = selectedCustomer.Fax;
        }
        enum Mode
        {
            New,
            Modify
        }

    }
}
