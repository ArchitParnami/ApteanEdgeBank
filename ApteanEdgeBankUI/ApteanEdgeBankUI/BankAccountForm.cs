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
    public partial class BankAccountForm : Form
    {
        public BankAccountForm()
        {
            InitializeComponent();
            balanceTextBox.Text = Bank.BankBalance.ToString();
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            ActivityLogForm form = new ActivityLogForm("Bank");
            form.ShowDialog();
        }

        
    }
}
