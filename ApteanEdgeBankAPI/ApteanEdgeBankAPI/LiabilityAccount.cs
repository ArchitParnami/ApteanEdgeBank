using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
 
    public class LiabilityAccount
    {
        private string accountID;
        private string customerID;
        private long loanBalance;

        public string AccountID
        {
            get { return accountID; }
        }

        public string CustomerID
        {
            get { return customerID; }
        }

        public long LoanBalance
        {
            get { return loanBalance; }
        }

        private LiabilityAccount() { }

        internal LiabilityAccount(string customerID, long loan)
        {
            accountID = Bank.LiabilityAccountID.Next();
            VerifyLoanAvailibility(loan);
            loanBalance = loan;
            LoanIssued(loan);
            this.customerID = customerID;
        }

        public void RepayLoan(long amount, long interestAmount)
        {
            VerifyLoanDeposit(amount, interestAmount);
            loanBalance = loanBalance - amount;
            LoanRepayed(amount, interestAmount);
        }

        public void IssueLoan(long amount)
        {
            if (loanBalance != 0)
            {
                string msg = "Loan can not be issue until the current loan balance is zero";
                throw new InvalidBankOperationException(msg);
            }

            VerifyLoanAvailibility(amount);

            loanBalance = amount;
            LoanIssued(amount);
        }


        private void VerifyLoanAvailibility(long loan)
        {
            if (loan < 0)
            {
                string msg = "Loan amount must be Non Negative";
                throw new InvalidBankOperationException(msg);
            }

            else
            {
                long bankBalance = Bank.BankBalance;
                long loanLimit = Bank.LoanLimit;
                if (loan > loanLimit)
                {
                    string msg = "Loan amount exceeds the maximum allowable amount\n" +
                        "Loan Limit = " + loanLimit;

                    throw new InvalidBankOperationException(msg);
                }

                else if (loan > bankBalance)
                {
                    string msg = "Bank does not have money to loan";
                    throw new InvalidBankOperationException(msg);
                }
            }
        }

        private void LoanIssued(long amount)
        {
            ActivityLedger.LogDeposit(amount, accountID);
            Bank.WithdrawAmount(amount);
        }

        private void VerifyLoanDeposit(long amount, long interestAmount)
        {
            if (amount <= 0)
            {
                string msg = "Loan repayment amount be positive";
                throw new InvalidBankOperationException(msg);
            }

            else
            {
                if (amount > loanBalance)
                {
                    string msg = "Loan repayment amount must be less than " +
                        "or equal to the loan balance\n" +
                        "Loan balance = " + loanBalance;

                    throw new InvalidBankOperationException(msg);
                }
            }

            if (interestAmount < 0)
            {
                string msg = "Interest amount should be positive";
                throw new InvalidBankOperationException(msg);
            }

        }

        private void LoanRepayed(long amount, long interestAmount)
        {
            ActivityLedger.LogWithdrawl(amount, accountID);
            Bank.DepositAmount(amount + interestAmount);
        }

        public static LiabilityAccount Generate(string accountID, string customerID,
                                                long balance)
        {
            LiabilityAccount account = new LiabilityAccount();
            account.accountID = accountID;
            account.customerID = customerID;
            account.loanBalance = balance;
            return account;
        }

    }
}
