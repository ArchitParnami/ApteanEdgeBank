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
    public partial class LoginForm : Form
    {
        private DataHandler DH;
        public LoginForm(DataHandler DH)
        {
            InitializeComponent();
            this.DH = DH;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (username == "archit" && password == "archit")
            {
                CustomerManagementForm csmForm = new CustomerManagementForm(this, DH);
                csmForm.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Invalid username or password!");
            }
           
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
