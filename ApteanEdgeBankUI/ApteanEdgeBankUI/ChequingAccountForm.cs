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
    public partial class ChequingAccountForm : Form
    {
        private CustomerForm parent;
        private DataHandler DH;
        private ChequingAccount account;
        private Customer customer;
        private bool statusChanged;
        private bool depositOkButtonClicked;
        private bool withdrawOkButtonClicked;
        private bool amountOkButtonClicked;
        private bool toAccountOkButtonClicked;
        private string toAccNo;
        
        public ChequingAccountForm(CustomerForm parent, DataHandler DH, 
                                   ChequingAccount account, Customer customer)
        {
            InitializeComponent();

            this.parent = parent;
            this.DH = DH;
            this.account = account;
            this.customer = customer;

            statusChanged = false;
            depositOkButtonClicked = false;
            withdrawOkButtonClicked = false;
            amountOkButtonClicked = false;
            toAccountOkButtonClicked = false;

            accountIDTextBox.Text = account.AccountID;
            customerIDTextBox.Text = account.CustomerID;
            dateOpenedTextBox.Text = account.OpeningDate;
            balanceTextBox.Text = account.Balance.ToString();
            typeTextBox.Text = Default.Chequing;

            depositBox.Maximum = Default.CHEQUING_ACCOUNT_TRANS_LIMIT;
            withdrawBox.Maximum = Default.CHEQUING_ACCOUNT_TRANS_LIMIT;
            amountBox.Maximum = Default.CHEQUING_ACCOUNT_TRANS_LIMIT;

            InitializeUI();

        }

        private void InitializeUI()
        {

            if (account.IsAccountOpen)
            {
                statusTextBox.Text = AccountStatus.ACTIVE;
                dateClosedTextBox.Hide();
                dateClosedLabel.Hide();
                closeAccountButton.Text = "Close Account";
                transactionsGroupBox.Enabled = true;

                amountBox.Enabled = false;
                amountOkButton.Enabled = false;
            }

            else
            {
                transactionsGroupBox.Enabled = false;
                statusTextBox.Text = AccountStatus.CLOSED;
                closeAccountButton.Text = "Reopen Account";
                dateClosedLabel.Visible = true;
                dateClosedTextBox.Visible = true;
                dateClosedTextBox.Text = account.ClosingDate;
            }
        }

        private void closeWindowButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeAccountButton_Click(object sender, EventArgs e)
        {
  
            if (account.IsAccountOpen) // close the account
            {

                if (account.Balance == 0.0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to close this account?",
                    "Close Account", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        DH.CloseChequingAccount(customer, account);
                        InitializeUI();
                        statusChanged = true;
                    }
                }

                else
                {
                    string message = "An account with a non-zero balance cannot be closed.";
                    MessageBox.Show(message, "Close Account");
                }

            }

            else // reopen Account
            {
                DialogResult result = MessageBox.Show("Are you sure you want to reopen this account?",
                    "Close Account", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    DH.ReopenChequingAccount(customer, account);
                    InitializeUI();
                    statusChanged = true;
                }
            }
        }

        private void ChequingAccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (statusChanged)
                parent.PopulateCustomerAccountListView();
        }

        private void depositOkButton_Click(object sender, EventArgs e)
        {
            if (depositOkButtonClicked)
            {
                long depositAmount = (long)depositBox.Value;
                DH.UpdateChequingAccountBalance(account, depositAmount);
                
                string message = "Rs " + depositAmount + " deposited to the account " 
                                  + account.AccountID;

                MessageBox.Show(message, "Money Deposited");

                depositOkButtonClicked = false;
                depositOkButton.Text = "OK";
                balanceTextBox.Text = account.Balance.ToString();
            }

            else
            {
                depositOkButton.Text = "GO";
                depositOkButtonClicked = true;
            }
        }

        private void withdrawOkButton_Click(object sender, EventArgs e)
        {
            if (withdrawOkButtonClicked)
            {
                long amountWithdraw = (long)withdrawBox.Value;
                if (amountWithdraw <= account.Balance)
                {
                    DH.UpdateChequingAccountBalance(account, -amountWithdraw);

                    string msg = "Rs " + amountWithdraw + " withdrawn from the account " + account.AccountID;
                    MessageBox.Show(msg, "Amount Withdrawn");

                    balanceTextBox.Text = account.Balance.ToString();
                }

                else
                {
                    string message = "Transaction Failed: Withdrawl amount exceeds balance!";
                    MessageBox.Show(message, "Withdraw Failed");
                }

                withdrawOkButtonClicked = false;
                withdrawOkButton.Text = "OK";
            }

            else
            {
                withdrawOkButtonClicked = true;
                withdrawOkButton.Text = "GO";
            }

        }

        private void toAccountOkButton_Click(object sender, EventArgs e)
        {
            toAccNo = toAccountTextBox.Text;

            if (toAccountOkButtonClicked)
            {
                amountBox.Enabled = true;
                amountOkButton.Enabled = true;
            }

            else
            {

                if (isAccountValid(toAccNo))
                {
                    toAccountOkButtonClicked = true; ;
                    toAccountOkButton.Text = "GO";
                }
            }
        }

        private void amountOkButton_Click(object sender, EventArgs e)
        {
            if (amountOkButtonClicked)
            {

                long amount = (long)amountBox.Value;
                
                if (amount <= account.Balance)
                {
                    bool transactionSuccessful = false;

                    if (toAccNo.StartsWith("CA")) // chequingAccount
                    {
                        Customer customer = DH.FindCustomerByChequingAccountID(toAccNo);
                        ChequingAccount toAccount = DH.FindCustomerChequingAccount(customer, toAccNo);

                        DH.UpdateChequingAccountBalance(account, -amount);
                        DH.UpdateChequingAccountBalance(toAccount, amount);
                        transactionSuccessful = true;
    
                    }

                    else if (toAccNo.StartsWith("TFSA")) // TFSAccount
                    {
                        Customer customer = DH.FindCustomerByTFSAccountID(toAccNo);
                        TFSAccount toAccount = customer.myTFSAccount;

                        long balanceAfterDeposit = toAccount.Balance + amount;
                        if (balanceAfterDeposit <= Default.TFS_ACCOUNT_BALANCE_LIMIT)
                        {
                            DH.UpdateChequingAccountBalance(account, -amount);
                            DH.UpdateTFSAccountBalance(toAccount, amount);
                            transactionSuccessful = true;
                        }

                        else
                        {
                            string msg = "Transfer Fail: This transfer exceeds the TFS balance limit of " +
                                Default.TFS_ACCOUNT_BALANCE_LIMIT;

                            MessageBox.Show(msg, "Money Transfer Failed");
                        }
                    }


                    if (transactionSuccessful)
                    {
                        string message = "Rs " + amount + " transfered from account no. "
                            + account.AccountID + " to account no. " + toAccNo;

                        MessageBox.Show(message, "Money Transfer");

                        balanceTextBox.Text = account.Balance.ToString();
                    }
                }

                else
                {
                    string message = "Transfer Failed: Transfer amount exceeds account balance!";
                    MessageBox.Show(message, "Money Transfer");  
                }

                amountOkButtonClicked = false;
                amountOkButton.Text = "OK";
                amountOkButton.Enabled = false;
                amountBox.Enabled = false;
                toAccountOkButtonClicked = false;
                toAccountOkButton.Text = "OK";
            }

            else
            {
                amountOkButtonClicked = true;
                amountOkButton.Text = "GO";
            }
        }

        private void ChequingAccountForm_Load(object sender, EventArgs e)
        {
            depositBox.TextChanged += new EventHandler(depositBox_TextChanged);
            withdrawBox.TextChanged += new EventHandler(withdrawBox_TextChanged);
            amountBox.TextChanged += new EventHandler(amountBox_TextChanged);
        }

        void depositBox_TextChanged(object sender, EventArgs args)
        {
            if (depositOkButtonClicked)
            {
                depositOkButton.Text = "OK";
                depositOkButtonClicked = false;
            }
        }

        void withdrawBox_TextChanged(object sender, EventArgs args)
        {
            if (withdrawOkButtonClicked)
            {
                withdrawOkButton.Text = "OK";
                withdrawOkButtonClicked = false;
            }
        }

        void amountBox_TextChanged(object sender, EventArgs args)
        {
            if (amountOkButtonClicked)
            {
                amountOkButton.Text = "OK";
                amountOkButtonClicked = false;
            }
        }

        private void toAccountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (toAccountOkButtonClicked)
            {
                toAccountOkButtonClicked = false;
                toAccountOkButton.Text = "OK";


                if (amountOkButtonClicked)
                {
                    amountOkButtonClicked = false;
                    amountOkButton.Text = "OK";
                }
                
                amountOkButton.Enabled = false;
                amountBox.Enabled = false;
            }
        }


        private bool isAccountValid(string accNo)
        {
            accNo = accNo.ToUpper();
            
            bool isValid = true;
            string status;

            if (string.IsNullOrEmpty(accNo))
            {
                string msg = "Please enter an account ID";
                MessageBox.Show(msg, "Money Transfer");
                return false;
            }
            
            else if (accNo == account.AccountID)
            {
                string msg = "Transaction Failed: Can not transfer funds to the same account";
                MessageBox.Show(msg, "Money Transfer");
                return false;
            }


            if (accNo.StartsWith("CA"))
            {
                status = DH.ReadChequingAccountStatus(accNo);
            }   

            else if (accNo.StartsWith("TFSA"))
            {
                status = DH.ReadTFSAccountStatus(accNo);
            }

            else
            {
                status = AccountStatus.NOT_EXISTS;
            }


            if (status == AccountStatus.CLOSED)
            {
                string msg = "Transaction Failed: Account " + accNo + " is not open";
                MessageBox.Show(msg, "Money Transfer");

                isValid = false;
            }

            else if (status == AccountStatus.NOT_EXISTS)
            {
                bool isLiabilityAccount = false;

                if(accNo.StartsWith("LA"))
                {

                    if (DH.IsLiabilityAcccountValid(accNo))
                    {
                        isLiabilityAccount = true;
                        string msg = "Transaction Failed: Money transfer not allowed for liability accounts";
                        MessageBox.Show(msg, "Money Transfer");
                    }
                }

                if (!isLiabilityAccount)
                {
                    string msg = "Transaction Failed: Account " + accNo + " does not exists";
                    MessageBox.Show(msg, "Money Transfer");
                }
            
                isValid = false;
            }

            return isValid;
        }

        private void activityLogbutton_Click(object sender, EventArgs e)
        {
            ActivityLogForm form = new ActivityLogForm(account.AccountID);
            form.ShowDialog();
        }


    
    }
}
