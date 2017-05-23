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
    public partial class CustomerManagementForm : Form
    {
        private DataHandler DH;
        private LoginForm parent;
        public CustomerManagementForm(LoginForm parent, DataHandler DH)
        {
            InitializeComponent();
            this.DH = DH;
            PopulateListView();
            this.parent = parent;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm(this, DH);
            addCustomerForm.ShowDialog();
        }

        public void PopulateListView()
        {
            listView.Items.Clear();
            int i = 1;
            foreach (Customer customer in Bank.customerList)
            {
                ListViewItem lvi = new ListViewItem(i.ToString());
                lvi.SubItems.Add(customer.CustomerID);
                lvi.SubItems.Add(customer.Name);
                lvi.SubItems.Add(customer.DateJoined.ToString());

                string chequingAccountStatus;
                if (customer.HasChequingAccount)
                {
                    chequingAccountStatus = AccountStatus.CLOSED;

                    foreach(ChequingAccount account in customer.myChequingAccounts)
                    {
                        if (account.IsAccountOpen)
                        {
                            chequingAccountStatus = AccountStatus.ACTIVE;
                            break;
                        }
                    }
                }

                else
                {
                    chequingAccountStatus = AccountStatus.NOT_EXISTS;
                }

                lvi.SubItems.Add(chequingAccountStatus);

                string tfsAccountStatus;
                if (customer.HasTFSAccount)
                {
                    if (customer.myTFSAccount.IsAccountOpen)
                        tfsAccountStatus = AccountStatus.ACTIVE;
                    else
                        tfsAccountStatus = AccountStatus.CLOSED;
                }

                else
                {
                    tfsAccountStatus = AccountStatus.NOT_EXISTS;
                }

                lvi.SubItems.Add(tfsAccountStatus);

                string liabilityAccountStatus;
                if (customer.HasLiabilityAccount)
                {
                    liabilityAccountStatus = AccountStatus.ACTIVE;
                }
                else
                    liabilityAccountStatus = AccountStatus.NOT_EXISTS;

                lvi.SubItems.Add(liabilityAccountStatus);

                listView.Items.Add(lvi);
                
                ++i;

            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult response =  
                MessageBox.Show("Are you sure you want to Logout?", "Logout Alert", MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
                parent.Show();
            else
                e.Cancel = true;
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            int itemsSelected = listView.SelectedIndices.Count;

            if (itemsSelected == 0)
            {
                MessageBox.Show("Please select an account to view.");
                return;
            }

            int selectedIndex = listView.SelectedIndices[0];
            Customer selectedCustomer = Bank.customerList.ElementAt(selectedIndex);

            CustomerForm cusomerForm = new CustomerForm(this, DH, selectedCustomer);
            cusomerForm.ShowDialog();
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            viewButton_Click(null, null);
        }

        private void bankButton_Click(object sender, EventArgs e)
        {
            BankAccountForm form = new BankAccountForm();
            form.ShowDialog();
        }


    }
}
