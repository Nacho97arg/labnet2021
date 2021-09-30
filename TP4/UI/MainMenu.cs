using System;
using System.Windows.Forms;

namespace TP4.UI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void TsbCustomersMenu_Click(object sender, EventArgs e)
        {
            try
            {
                new CustomersMenu().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.GetType()}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TsbSuppliersMenu_Click(object sender, EventArgs e)
        {
            try
            {
                new SuppliersMenu().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
