using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApteanEdgeBankAPI;

namespace ApteanEdgeBankUI
{
    public partial class AddAccountForm : Form
    {
        private CustomerForm parent;
        private DataHandler DH;
        private Customer customer;

        private bool okButtonClicked = false;

        public AddAccountForm(CustomerForm parent, DataHandler DH, Customer customer)
        {
            InitializeComponent();

            this.parent = parent;
            this.DH = DH;
            this.customer = customer;

            chequingAccountButton.Checked = true;
            liabilityAccountButton.Enabled = false;

            if (customer.HasTFSAccount)
                tfsAccountButton.Enabled = false;

            if ((customer.HasChequingAccount || customer.HasTFSAccount) && 
                   !customer.HasLiabilityAccount)
                liabilityAccountButton.Enabled = true;

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (okButtonClicked)
            {
                long balance = (long)balanceBox.Value;

                if (chequingAccountButton.Checked)
                {
                    DH.AddChequingAccount(customer, balance);
                    parent.PopulateCustomerAccountListView();
                }

                else if (tfsAccountButton.Checked)
                {
                    DH.AddTFSAccount(customer, balance);
                    parent.PopulateCustomerAccountListView();
                }

                else // (liabilityAccountButton.Checked)
                {
                    DH.AddLiabilityAccount(customer, balance);
                    parent.PopulateCustomerAccountListView();
                }

                this.Close();
            }

            else
            {
                okButton.Text = "Save";
                okButtonClicked = true;
            }
        }

        private void chequingAccountButton_CheckedChanged(object sender, EventArgs e)
        {
            if (chequingAccountButton.Checked)
                balanceBox.Maximum = Default.CHEQUING_ACCOUNT_STARTING_BALANCE_LIMIT;
        }

        private void tfsAccountButton_CheckedChanged(object sender, EventArgs e)
        {
            if (tfsAccountButton.Checked)
                balanceBox.Maximum = Default.TFS_ACCOUNT_BALANCE_LIMIT;
        }

        private void liabilityAccountButton_CheckedChanged(object sender, EventArgs e)
        {
            if (liabilityAccountButton.Checked)
                balanceBox.Maximum = Default.LOAN_LIMIT;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAccountForm_Load(object sender, EventArgs e)
        {
            balanceBox.TextChanged += new EventHandler(balanceBox_TextChanged);
        }

        void balanceBox_TextChanged(object sender, EventArgs e)
        {
            if (okButtonClicked)
            {
                okButtonClicked = false;
                okButton.Text = "Ok";
            }
        }

    }
}
