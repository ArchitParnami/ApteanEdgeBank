using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
    public class ChequingAccount : Account
    {
        internal ChequingAccount(string customerID, long startingBalance = 0)
        {
            accountID = Bank.ChequingAccountID.Next();
            balance = startingBalance;
            openingDate = Utility.getCurrentDate();
            isAccountOpen = true;
            closingDate = "";
            this.customerID = customerID;
            AmountDeposited(startingBalance, accountID);
        }


        private ChequingAccount() { }

        public override void Deposit(long amount)
        {
            string message = "Can not deposit in a closed account";
            VerifyAccountStatus(message);

            if (amount > 0)
            {
                balance += amount;
                AmountDeposited(amount, accountID);                
            }

            else
            {
                string msg = "Trying to deposit non-positive amount";
                throw new InvalidBankOperationException(msg);
            }
        }

        public static ChequingAccount Generate(string accountID, string customerID,
                                        bool isAccountOpen, string openingDate,
                                        string closingDate, long balance)
        {
            ChequingAccount account = new ChequingAccount();
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
