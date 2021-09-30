using System;
using System.Windows.Forms;
using TP4.Common.CustomExceptions;
using TP4.Entities;
using TP4.Logic;

namespace TP4.UI
{
    public partial class CustomerForm : Form
    {
        private readonly ILogic<Customers> customerLogic;
        private Customers selectedCustomer;
        private readonly Mode mode;
        public CustomerForm(ILogic<Customers> customerLogic)
        {
            InitializeComponent();
            mode = Mode.New;
            this.customerLogic = customerLogic;
        }
        public CustomerForm(Customers customer, ILogic<Customers> customerLogic) : this(customerLogic)
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
                        ValidateRequiredFields();
                        newCustomer = FillCustomerMembers(newCustomer);
                        this.customerLogic.AddOne(newCustomer);
                        break;
                    case Mode.Modify:
                        ValidateRequiredFields();
                        selectedCustomer = FillCustomerMembers(selectedCustomer);
                        this.customerLogic.Update();
                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to save the customer\n\n{ex.Message}\n\n{ex.GetType()}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidateRequiredFields()
        {
            if ((tbCompanyName.Text == "") || (tbCustomerID.Text == ""))
                throw new RequiredFieldsIncompleteException();
        }
        Customers FillCustomerMembers(Customers customer)
        {
            if (int.TryParse(tbCustomerID.Text, out _))
                throw new ArgumentException("The customer ID can only be made of letters");
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
