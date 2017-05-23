using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApteanEdgeBankUI
{
    public partial class AddCustomerForm : Form
    {
        private CustomerManagementForm CMForm;
        private DataHandler DH;

        public AddCustomerForm(CustomerManagementForm form, DataHandler DH)
        {
            InitializeComponent();
            CMForm = form;
            this.DH = DH;
            submitButton.Enabled = false;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            name = name.Trim();
            DH.AddCustomer(name);
            CMForm.PopulateListView();
            this.Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(text))
                submitButton.Enabled = false;
            else
                submitButton.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {

        }

     
    }
}
