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
    public partial class SupplierForm : Form
    {
        private readonly SupplierLogic supplierLogic;
        private Suppliers selectedSupplier;
        private readonly Mode mode;
        public SupplierForm(SupplierLogic supplierLogic)
        {
            InitializeComponent();
            mode = Mode.New;
            this.supplierLogic = supplierLogic;
        }
        public SupplierForm(Suppliers supplier, SupplierLogic supplierLogic) : this(supplierLogic)
        {
            mode = Mode.Modify;
            selectedSupplier = supplier;
            FillControls();
        }
        Suppliers FillSupplierMembers(Suppliers supplier)
        {
            supplier.CompanyName = tbCompanyName.Text;
            supplier.ContactName = tbContactName.Text;
            supplier.ContactTitle = tbContactTitle.Text;
            supplier.Address = tbAddress.Text;
            supplier.City = tbCity.Text;
            supplier.Region = tbRegion.Text;
            supplier.PostalCode = tbPostalCode.Text;
            supplier.Country = tbCountry.Text;
            supplier.Phone = tbPhone.Text;
            supplier.Fax = tbFax.Text;
            supplier.HomePage = tbHomePage.Text;

            return supplier;
        }
        void FillControls()
        {
            tbSupplierId.Text = selectedSupplier.SupplierID.ToString();
            tbCompanyName.Text = selectedSupplier.CompanyName;
            tbContactName.Text = selectedSupplier.ContactName;
            tbContactTitle.Text = selectedSupplier.ContactTitle;
            tbAddress.Text = selectedSupplier.Address;
            tbCity.Text = selectedSupplier.City;
            tbRegion.Text = selectedSupplier.Region;
            tbPostalCode.Text = selectedSupplier.PostalCode;
            tbCountry.Text = selectedSupplier.Country;
            tbPhone.Text = selectedSupplier.Phone;
            tbFax.Text = selectedSupplier.Fax;
            tbHomePage.Text = selectedSupplier.HomePage;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                switch (mode)
                {
                    case Mode.New:
                        Suppliers newSupplier = new Suppliers();
                        newSupplier = FillSupplierMembers(newSupplier);
                        if (newSupplier.CompanyName == "")
                            throw new Exception("Verify that the required fields have been completed");
                        else
                            this.supplierLogic.AddOne(newSupplier);
                        break;
                    case Mode.Modify:
                        selectedSupplier = FillSupplierMembers(selectedSupplier);
                        this.supplierLogic.Update();
                        break;
                }
                this.Close();
            }
            catch (Exception exeption)
            {
                MessageBox.Show($"An error occurred while trying to save the supplier\n{exeption.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        enum Mode
        {
            New,
            Modify
        }

    }
}
