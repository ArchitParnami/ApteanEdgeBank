using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
    public class TFSAccount : Account
    {
        internal TFSAccount(string customerID, long startingBalance = 0)
        {
            accountID = Bank.TFSAccountID.Next();
            balance = startingBalance;
            isAccountOpen = true;
            openingDate = Utility.getCurrentDate();
            closingDate = "";
            this.customerID = customerID;
            AmountDeposited(startingBalance, accountID);
        }

        private TFSAccount() { }

        public override void Deposit(long amount)
        {

            const long limit = 5000;

            string message = "Can not deposit in a closed account";
            VerifyAccountStatus(message);


            if (amount > 0)
            {

                if (balance + amount <= limit)
                {
                    balance += amount;
                    AmountDeposited(amount, accountID);
                }

                else
                {
                    double maxDepositAllowed = limit - balance;
                    string msg = "Maximum allowed balance = " + limit + "\n"
                        + "Maximum allowed deposit for current balance  = "
                        + maxDepositAllowed;
                    throw new InvalidBankOperationException(msg);
                }
 
            }

            else
            {
                string msg = "Trying to deposit non-positive amount";
                throw new InvalidBankOperationException(msg);
            }
        }

        public static TFSAccount Generate(string accountID, string customerID,
                                        bool isAccountOpen, string openingDate,
                                        string closingDate, long balance)
        {
            TFSAccount account = new TFSAccount();
            account.accountID = accountID;
            account.customerID = customerID;
            account.isAccountOpen = isAccountOpen;
            account.openingDate = openingDate;
            account.closingDate = closingDate;
            account.balance = balance;

            return account;
        }
    }
}
