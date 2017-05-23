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
    public partial class IssueLoanForm : Form
    {
        private LiabilityAccountForm parent;
        private DataHandler DH;
        private Customer customer;
        private LiabilityAccount account;

        private bool okButtonClicked;

        public IssueLoanForm(LiabilityAccountForm parent, DataHandler DH, 
                                Customer customer, LiabilityAccount account)
        {
            InitializeComponent();
            this.parent = parent;
            this.DH = DH;
            this.account = account;
            this.customer = customer;

            okButtonClicked = false;
            amountBox.Maximum = Bank.LoanLimit;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (okButtonClicked)
            {
                long amount = (long)amountBox.Value;
                
                // check if bank has loan to pay
                if (amount <= Bank.BankBalance)
                {
                    // Issue Loan
                    DH.IssueLoan(account, amount);
                    string msg = "Loan of Rs " + amount + " issued to the account no. " +
                       account.AccountID;
                    MessageBox.Show(msg, "Issue Loan");
                    parent.UpdateBalance();
                    this.Close();
                }

                else
                {
                    string msg = "Bank does not have funds to issue loan";
                    MessageBox.Show(msg, "Issue Loan");
                    okButtonClicked = false;
                    okButton.Text = "Ok";
                }
            }

            else
            {
                okButtonClicked = true;
                okButton.Text = "Go";
            }
        }

        private void IssueLoanForm_Load(object sender, EventArgs e)
        {
            amountBox.TextChanged += new EventHandler(amountBox_TextChanged);
        }

        void amountBox_TextChanged(object sender, EventArgs args)
        {
            if (okButtonClicked)
            {
                okButtonClicked = false;
                okButton.Text = "Ok";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
