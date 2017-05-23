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
    public partial class LiabilityAccountForm : Form
    {
        private DataHandler DH;
        private Customer customer;
        private LiabilityAccount account;
        private bool okButtonClicked;
        private long interest;
        private long totalAmount;
        private long amount;

        public LiabilityAccountForm(DataHandler DH, 
                            Customer customer, LiabilityAccount account)
        {
            InitializeComponent();
            this.DH = DH;
            this.customer = customer;
            this.account = account;
            okButtonClicked = false;

            accountIDTextBox.Text = account.AccountID;
            customerIDTextBox.Text = account.CustomerID;
            typeTextBox.Text = Default.Liability;
            statusTextBox.Text = AccountStatus.ACTIVE;
            balanceTextBox.Text = account.LoanBalance.ToString();
            repayAmountBox.Maximum = Bank.LoanLimit;

            PopulateComboBox();

        }

        private void okButton_Click(object sender, EventArgs e)
        {

            if (okButtonClicked)
            {
                
                if (accountCheckbox.Checked)
                {
                     Object item = accountTransferComboBox.SelectedItem;
                     if (item == null)
                     {
                         string msg = "Please select an account to repay loan amount";
                         MessageBox.Show(msg, "Loan Repayment");
                     }

                     else
                     {
                         if (amount <= account.LoanBalance)
                         {
                             bool success = false;
                             
                             if (item is ChequingAccount)
                             {
                                 ChequingAccount acc = (ChequingAccount)item;
                                 if (totalAmount <= acc.Balance)
                                 {

                                     // deduct amount from Chequing Account
                                     DH.UpdateChequingAccountBalance(acc, -totalAmount);

                                     // deposit to Liability Account
                                     DH.PayLoan(account, amount, interest);

                                     success = true;

                                     string msg =
                                         "Amount deducted from Account " + acc.AccountID + ": " + totalAmount + Environment.NewLine +
                                         "Loan Payment done for Account " + account.AccountID + ": " + amount + Environment.NewLine +
                                         "Interest Paid to bank : " + interest;

                                     MessageBox.Show(msg, "Loan Repayment");

                                 }

                                 else
                                 {
                                     string msg = "Account " + acc.AccountID + " has insufficient funds to repay the amount " + totalAmount;
                                     MessageBox.Show(msg, "Repay Loan");
                                 }
                             }

                             else // TFS Account
                             {
                                 TFSAccount acc = (TFSAccount)item;
                                 if (totalAmount <= acc.Balance)
                                 {

                                     // deduct amount from TFS Account
                                     DH.UpdateTFSAccountBalance(acc, -totalAmount);

                                     // deposit to Liability Account
                                     DH.PayLoan(account, amount, interest);

                                     success = true;

                                     string msg =
                                         "Amount deducted from Account " + acc.AccountID + ": " + totalAmount + Environment.NewLine +
                                         "Loan Payment done for Account " + account.AccountID + ": " + amount + Environment.NewLine +
                                         "Interest Paid to bank : " + interest;

                                     MessageBox.Show(msg, "Loan Repayment");

                                 }

                                 else
                                 {
                                     string msg = "Account " + acc.AccountID + " has insufficient funds to repay the amount " + totalAmount;
                                     MessageBox.Show(msg, "Repay Loan");
                                 }
                             }

                             if (success)
                             {
                                 balanceTextBox.Text = account.LoanBalance.ToString();
                                 PopulateComboBox();
                             }
                         }

                         else
                         {
                             string msg = "Transaction Failed: Payment amount exceeds liability";
                             MessageBox.Show(msg, "Loan Repayment");
                         }
                     }
                    
                }

                else
                {
                    if (amount <= account.LoanBalance)
                    {
                        DH.PayLoan(account, amount, interest);
                        string msg = "Transaction Successful:" + Environment.NewLine +
                            "Loan repaid: " + amount + Environment.NewLine +
                            "Interest paid: " + interest;

                        MessageBox.Show(msg, "Loan Repayment");

                        balanceTextBox.Text = account.LoanBalance.ToString();
                    }

                    else
                    {
                        string msg = "Transaction Failed: Payment amount exceeds liability";
                        MessageBox.Show(msg, "Loan Repayment");
                    }
                }

                okButtonClicked = false;
                okButton.Text = "OK";
                interestTextBox.Text = "";
                totalPaymentTextBox.Text = "";
            }

            else
            {
                okButtonClicked = true;
                okButton.Text = "PAY";
                
                amount = (long)repayAmountBox.Value;
                interest = amount / 10;
                totalAmount = amount + interest;

                interestTextBox.Text = interest.ToString();
                totalPaymentTextBox.Text = totalAmount.ToString();
                
            }
        }

        private void LiabilityAccountForm_Load(object sender, EventArgs e)
        {
            repayAmountBox.TextChanged += new EventHandler(repayAmountBox_TextChanged);
        }

        void repayAmountBox_TextChanged(object sender, EventArgs args)
        {
            if (okButtonClicked)
            {
                okButtonClicked = false;
                okButton.Text = "OK";
                interestTextBox.Text = "";
                totalPaymentTextBox.Text = "";

            }
        }

        private void closeWindowButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void issueLoanButton_Click(object sender, EventArgs e)
        {
            if (account.LoanBalance != 0)
            {
                string msg = "More loan can not be issued until current loan balance is 0";
                MessageBox.Show(msg, "Issue Loan");
            }

            else
            {
                // Issue Loan
                IssueLoanForm form = new IssueLoanForm(this, DH, customer, account);
                form.ShowDialog();
            }
        }

        public void UpdateBalance()
        {
            balanceTextBox.Text = account.LoanBalance.ToString();
        }

        private void PopulateComboBox()
        {
            ComboBox box = accountTransferComboBox;
            box.Items.Clear();

            // Add valid Chequing Accounts

            if (customer.HasChequingAccount)
            {

                foreach (ChequingAccount ca in customer.myChequingAccounts)
                {
                    if (ca.IsAccountOpen && ca.Balance > 0)
                    {
                        box.Items.Add(ca);
                    }
                }
            }

            if (customer.HasTFSAccount)
            {
                TFSAccount account = customer.myTFSAccount;
                if (account.IsAccountOpen && account.Balance > 0)
                {
                    box.Items.Add(account);
                }
            }

            int itemCount = accountTransferComboBox.Items.Count;
            
            
            if (itemCount == 0)
            {
                transferAccountBalanceTextBox.Text = "";
                accountTransferGroupBox.Enabled = false;
            }

            else
            {
                transferAccountBalanceTextBox.Enabled = false;
                accountCheckbox.Checked = false;
                accountTransferComboBox.Enabled = false;
            }

        }

        private void accountTransferComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountTransferComboBox.SelectedItem != null)
            {
                Account account = (Account)accountTransferComboBox.SelectedItem;
                transferAccountBalanceTextBox.Text = account.Balance.ToString();
            }

            else
            {
                transferAccountBalanceTextBox.Text = "";
            }
            
        }

        private void accountCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (accountCheckbox.Checked)
            {
                accountTransferComboBox.Enabled = true;
                transferAccountBalanceTextBox.Enabled = true;
            }

            else
            {
                accountTransferComboBox.Enabled = false;
                transferAccountBalanceTextBox.Enabled = false;
                transferAccountBalanceTextBox.Text = "";
                accountTransferComboBox.SelectedIndex = -1;
            }
        }

        private void activityLogbutton_Click(object sender, EventArgs e)
        {
            ActivityLogForm form = new ActivityLogForm(account.AccountID);
            form.ShowDialog();
        }
    }
}
