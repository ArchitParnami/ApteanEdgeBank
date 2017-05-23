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
    public partial class CustomerForm : Form
    {
        private DataHandler DH;
        private CustomerManagementForm parent;
        private Customer myCustomer;
        private bool nameChanged;
        private bool dateChanged;
        public bool listViewUpdated;
        private bool saveNameOrDate = false;

        public CustomerForm(CustomerManagementForm parent,  DataHandler DH, Customer customer)
        {
            InitializeComponent();
            myCustomer = customer;

            this.DH = DH;
            this.parent = parent;

            customerIDTextBox.Text = customer.CustomerID;
            nameTextBox.Text = customer.Name;
            dateJoinedMaskedTextBox.Text = customer.DateJoined;

            nameChanged = false;
            dateChanged = false;

            PopulateCustomerAccountListView();
            listViewUpdated = false;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            nameChanged = true;
        }

        private void dateJoinedMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            dateChanged = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (nameChanged)
            {
               string newName = nameTextBox.Text;
               DH.UpdateCustomerName(myCustomer, newName);
               saveNameOrDate = true;  
            }

            if (dateChanged)
            {
                string newDate = dateJoinedMaskedTextBox.Text;
                DH.UpdateCustomerDateOfJoining(myCustomer, newDate);
                saveNameOrDate = true;
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddAccountForm addAccountForm = new AddAccountForm(this, DH, myCustomer);
            addAccountForm.ShowDialog();
        }

        public void PopulateCustomerAccountListView()
        {
            listView.Items.Clear();
            listViewUpdated = true;
            ListViewItem lvi;
            int i = 1;

            if (myCustomer.HasChequingAccount)
            {
                foreach (ChequingAccount account in myCustomer.myChequingAccounts)
                {
                    lvi = new ListViewItem(i.ToString());
                    lvi.SubItems.Add(account.AccountID);
                    lvi.SubItems.Add(Default.Chequing);
                    if (account.IsAccountOpen)
                        lvi.SubItems.Add(AccountStatus.ACTIVE);
                    else
                        lvi.SubItems.Add(AccountStatus.CLOSED);

                    listView.Items.Add(lvi);
                    ++i;
                }
            }

            if (myCustomer.HasLiabilityAccount)
            {   
                LiabilityAccount account = myCustomer.myLiabilityAccount;
                lvi = new ListViewItem(i.ToString());
                lvi.SubItems.Add(account.AccountID);
                lvi.SubItems.Add(Default.Liability);
                lvi.SubItems.Add(AccountStatus.ACTIVE);

                listView.Items.Add(lvi);
                ++i;
            }

            if (myCustomer.HasTFSAccount)
            {
                TFSAccount account = myCustomer.myTFSAccount;
                lvi = new ListViewItem(i.ToString());
                lvi.SubItems.Add(account.AccountID);
                lvi.SubItems.Add(Default.TFSA);

                if (account.IsAccountOpen)
                    lvi.SubItems.Add(AccountStatus.ACTIVE);
                else
                    lvi.SubItems.Add(AccountStatus.CLOSED);

                listView.Items.Add(lvi);
            }
        }

        private void CustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((nameChanged || dateChanged) && !saveNameOrDate)
            {
                string msg = "Do You want to save the changes you made?";
                DialogResult result = MessageBox.Show(msg, "Save Alert", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saveButton_Click(null, null);
                }

                else if (result == DialogResult.Cancel)
                    e.Cancel = true;
            }

            if (saveNameOrDate || listViewUpdated && !e.Cancel)
            {
                parent.PopulateListView();
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            int count = this.listView.SelectedIndices.Count;
            if (count == 0)
            {
                MessageBox.Show("Please select an account to view.");
                return;
            }

            ListViewItem lvi = listView.SelectedItems[0];
            string accountType = lvi.SubItems[2].Text; // type
            int index = int.Parse(lvi.SubItems[0].Text); // index

            if (accountType == Default.Chequing)
            {
                ChequingAccount account = myCustomer.myChequingAccounts.ElementAt(index - 1);
                ChequingAccountForm form = new ChequingAccountForm(this, DH, account, myCustomer);
                form.ShowDialog();
            }

            else if (accountType == Default.TFSA)
            {
                TFSAccount account = myCustomer.myTFSAccount;
                TFSAccountForm form = new TFSAccountForm(this, DH, account, myCustomer);
                form.ShowDialog();
            }

            else
            {
                LiabilityAccount account = myCustomer.myLiabilityAccount;
                LiabilityAccountForm form = new LiabilityAccountForm(DH, myCustomer, account);
                form.ShowDialog();
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            viewButton_Click(null, null);
        }

    
    }
}
