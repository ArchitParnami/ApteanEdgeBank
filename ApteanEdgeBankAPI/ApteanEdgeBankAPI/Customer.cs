using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
    public class Customer
    {
        private string customerID;
        private string name;
        private string dateJoined;

        private bool hasChequingAccount;
        private bool hasTFSAccount;
        private bool hasLiabilityAccount;

        public List<ChequingAccount> myChequingAccounts;
        public TFSAccount myTFSAccount;
        public LiabilityAccount myLiabilityAccount;

        public string CustomerID
        {
            get { return customerID; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string DateJoined
        {
            get { return dateJoined; }
            set { dateJoined = value; }
        }

        public bool HasChequingAccount
        {
            get { return hasChequingAccount; }
        }

        public bool HasTFSAccount
        {
            get { return hasTFSAccount; }
        }

        public bool HasLiabilityAccount
        {
            get { return hasLiabilityAccount; }
        }

        public Customer(string name)
        {
            this.name = name;
            dateJoined = Utility.getCurrentDate();
            customerID = Bank.CustomerID.Next();

            myChequingAccounts = null;
            myLiabilityAccount = null;
            myTFSAccount = null;
            hasChequingAccount = false;
            hasLiabilityAccount = false;
            hasTFSAccount = false;
        }

        private Customer() { }

        public Account OpenGeneralAccount(AccountType type, long startingBalance = 0)
        {
            if (type == AccountType.ChequingAccount)
            {
                if (!hasChequingAccount)
                {
                    hasChequingAccount = true;
                    myChequingAccounts = new List<ChequingAccount>();
                }
                
                ChequingAccount ca = new ChequingAccount(customerID, startingBalance);
                myChequingAccounts.Add(ca);

                return ca;
            }

            else // if (type == AccountType.TFSAccount)
            {
                if (hasTFSAccount)
                {
                    string msg = "Customer already has a TFS Account";
                    throw new InvalidBankOperationException(msg);
                }

                else
                {
                    myTFSAccount = new TFSAccount(customerID, startingBalance);
                    hasTFSAccount = true;
                    return myTFSAccount;
                }
            }

        }

        public LiabilityAccount OpenLiabilityAccount(long loanAmount)
        {
            if (hasLiabilityAccount)
            {
                string msg = "Customer already has a Liabiliity Account";
                throw new InvalidBankOperationException(msg);
            }

            else
            {
                if (hasChequingAccount || hasTFSAccount)
                {
                    myLiabilityAccount = new LiabilityAccount(customerID, loanAmount);
                    hasLiabilityAccount = true;
                    return myLiabilityAccount;
                }

                else
                {
                    string msg = "Customer should have a Chequing or TFS Account" +
                        " to open a Liability account";

                    throw new InvalidBankOperationException(msg);
                }

            }
        }

        public static Customer Generate(string customerID, string name, string joiningDate,
                                        bool hasChequingAccount, List<ChequingAccount> chequingAccounts,
                                        bool hasTFSAccount, TFSAccount tfsAccount,
                                        bool hasLiabilityAccount, LiabilityAccount liabilityAccount)
        {
            Customer customer = new Customer();
            customer.name = name;
            customer.customerID = customerID;
            customer.dateJoined = joiningDate;
            customer.hasChequingAccount = hasChequingAccount;
            customer.myChequingAccounts = chequingAccounts;
            customer.hasTFSAccount = hasTFSAccount;
            customer.myTFSAccount = tfsAccount;
            customer.hasLiabilityAccount = hasLiabilityAccount;
            customer.myLiabilityAccount = liabilityAccount;
            return customer;
        }

    }

   
      

}
