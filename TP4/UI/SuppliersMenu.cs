using System;
using System.Windows.Forms;
using TP4.Common.CustomExceptions;
using TP4.Entities;
using TP4.Logic;

namespace TP4.UI
{
    public partial class SuppliersMenu : Form
    {
        private readonly ILogic<Suppliers, int> supplierLogic;
        public SuppliersMenu()
        {
            supplierLogic = new SupplierLogic();
            InitializeComponent();
            SetDataSource();
        }

        private void SetDataSource()
        {
                dgvSuppliers.DataSource = supplierLogic.GetAll();
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
            catch(DatabaseIntegrityException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetDataSource();
        }
    }
}
