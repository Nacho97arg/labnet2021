using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP4.Logic;
using TP4.Entities;

namespace TP4.UI
{
    public partial class SuppliersMenu : Form
    {
        private readonly SupplierLogic supplierLogic;
        public SuppliersMenu()
        {
            supplierLogic = new SupplierLogic();
            InitializeComponent();
            SetDataSource();
        }

        private void SetDataSource()
        {
            try
            {
                dgvSuppliers.DataSource = supplierLogic.GetAll();
            }
            catch(Exception e)
            {
                MessageBox.Show($"An error occurred while trying to connect to the database\n{e.Message}", "Connection error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void TsbCreate_Click(object sender, EventArgs e)
        {
            new SupplierForm(supplierLogic).ShowDialog();
            SetDataSource();
        }

        private void TsbUpdate_Click(object sender, EventArgs e)
        {
            Suppliers dgvSelectedSupplier = (Suppliers)dgvSuppliers.SelectedRows[0].DataBoundItem;
            new SupplierForm(dgvSelectedSupplier, supplierLogic).ShowDialog();
            SetDataSource();
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Suppliers dgvSelectedSupplier = (Suppliers)dgvSuppliers.SelectedRows[0].DataBoundItem;
                supplierLogic.DeleteOne(dgvSelectedSupplier);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"This supplier provides a product. Please delete that product first\nError message:\n{ex.InnerException.InnerException.Message}", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetDataSource();
        }
    }
}
