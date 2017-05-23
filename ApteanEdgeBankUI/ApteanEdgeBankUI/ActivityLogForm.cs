using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ApteanEdgeBankAPI;

namespace ApteanEdgeBankUI
{
    public partial class ActivityLogForm : Form
    {
        private string accountID;
        private string file;
        public ActivityLogForm(string accountID)
        {
            InitializeComponent();
            this.accountID = accountID;
            file = Bank.Logger.DirectoryPath + accountID + ".txt";

            string text;

            if (File.Exists(file))
            {
                text = File.ReadAllText(file);
            }
            else
            {
                FileStream fileStream = File.Create(file);
                text = "";
                fileStream.Close();
            }

                logTextBox.Text = text;
        }

        private void calculateBalanceButton_Click(object sender, EventArgs e)
        {
            StreamReader myFile = null;

            try
            {

                string line;
                myFile = new StreamReader(file);
                long balance = 0;
                while ((line = myFile.ReadLine()) != null)
                {
                    int len = line.Length;
                    string word = "";
                    int i = len - 1;
                    while (i >= 0 && line[i] != '+' && line[i] != '-')
                    {
                        word += line[i];
                        --i;
                    }

                    char[] charArray = word.ToCharArray();

                    Array.Reverse(charArray);

                    word = new string(charArray);
                    word = word.Trim();
                    long num = long.Parse(word);

                    if (line[i] == '+')
                        balance += num;
                    else if (line[i] == '-')
                        balance -= num;
                }

                myFile.Close();
                if (accountID == "Bank")
                    balance += Default.BANK_BALANCE;

                MessageBox.Show("Current balance amount should be Rs " + balance, "Calculate Balance");
            }

            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                myFile.Close();
            }
        
        }
    }
}
