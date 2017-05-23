using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
    public abstract class Account
    {
        protected string accountID;
        protected long balance;
        protected string openingDate;
        protected string closingDate;
        protected bool isAccountOpen;
        protected string customerID;

        public string AccountID
        {
            get { return accountID; }
        }

        public string CustomerID
        {
            get { return customerID; }
        }

        public long Balance
        {
            get { return balance; }
        }

        public string OpeningDate
        {
            get { return openingDate; }
        }

        public string ClosingDate
        {
            get {return closingDate;}
        }


        public bool IsAccountOpen
        {
            get { return isAccountOpen; }
        }

        protected static void AmountDeposited(long amount, string accountID)
        {
            ActivityLedger.LogDeposit(amount, accountID);
            Bank.DepositAmount(amount);
        }
        
        protected static void AmountWithdrawn(long amount, string accountID)
        {
            ActivityLedger.LogWithdrawl(amount, accountID);
            Bank.WithdrawAmount(amount);
        }
        
        public void Withdraw(long amount)
        {
            string message = "Can not withdraw money from a closed account";
            VerifyAccountStatus(message);

            if (amount <= balance)
            {
                balance = balance - amount;
                AmountWithdrawn(amount, accountID);
            }

            else
            {
                string message2 = "Account ID " + accountID + "\n" +
                                 "Error: Withdrawl amount excceeds account balance\n";

                throw new InsufficientFundException(message2);
            }
        }

        public void Close()
        {

            string message = "Error: Trying to close an already closed account";
            VerifyAccountStatus(message);

            if (balance == 0)
            {
                isAccountOpen = false;
                closingDate = Utility.getCurrentDate();
            }

            else
            {
                string msg = "Account balance not zero"; ;
                throw new InvalidBankOperationException(msg);
            }
        }

        public void Reopen()
        {
            if (isAccountOpen)
            {
                string message = "Error: Account already open";
                throw new InvalidBankOperationException(message);
            }

            else
            {
                isAccountOpen = true;
                closingDate = "";
            }
            
        }


        protected void VerifyAccountStatus(string message)
        {
            if (!isAccountOpen)
            {
                throw new InvalidBankOperationException(message);
            }
        }

        public abstract void Deposit(long amount);

        public override string ToString()
        {
            return accountID;
        }
    }


}
