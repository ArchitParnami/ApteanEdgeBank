using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApteanEdgeBankDB;
using ApteanEdgeBankAPI;

namespace ApteanEdgeBankUI
{
    public class DataHandler
    {
        private DatabaseManager DM;

        public DataHandler()
        {
           DM = new DatabaseManager();
           InitializeBank();
           ReadCustomerRecordsIntoBank();
        }

        private void InitializeBank()
        {
            Constant constant = DM.ReadConstants();
            if (constant == null)
            {
                Bank.Initialize(Default.BANK_BALANCE, Default.LOAN_LIMIT,
                    Default.CUSTOMER_ID_COUNT, Default.CHEQUING_ACCOUNT_ID_COUNT,
                    Default.TFS_ACCOUNT_ID_COUNT, Default.LIABILITY_ACCOUNT_ID_COUNT,
                    Default.ACTIVITY_COUNT);

                constant = new Constant();
                constant.BANK_BALANCE = Default.BANK_BALANCE;
                constant.LOAN_LIMIT = Default.LOAN_LIMIT;
                constant.CUSTOMER_ID_COUNT = Default.CUSTOMER_ID_COUNT;
                constant.CHEQUING_ACCOUNT_ID_COUNT = Default.CHEQUING_ACCOUNT_ID_COUNT;
                constant.TFS_ACCOUNT_ID_COUNT = Default.CHEQUING_ACCOUNT_ID_COUNT;
                constant.ACTIVITY_COUNT = Default.ACTIVITY_COUNT;

                DM.InitializeConstant(constant);
            }

            else
            {
                Bank.Initialize(constant.BANK_BALANCE, constant.LOAN_LIMIT,
                    constant.CUSTOMER_ID_COUNT, constant.CHEQUING_ACCOUNT_ID_COUNT,
                    constant.TFS_ACCOUNT_ID_COUNT, constant.LIABILITY_ACCOUNT_ID_COUNT,
                    constant.ACTIVITY_COUNT);
            }
        }

        private void ReadCustomerRecordsIntoBank()
        {
            List<CustomerData> allCustomerData = DM.ReadCustomers();
            foreach (CustomerData customerData in allCustomerData)
            {
                string customerID = customerData.customerID;
                string name = customerData.name;
                string joiningDate = customerData.joiningDate;
                bool hasChequingAccount = false;
                List<ChequingAccount> myChequingAccounts = null;
                bool hasTFSAccount = false;
                TFSAccount myTFSAccount = null;
                bool hasLiabilityAccount = false;
                LiabilityAccount myLiabilityAccount = null;

                if (customerData.chequingAccountStatus == AccountStatus.ACTIVE || 
                    customerData.chequingAccountStatus == AccountStatus.CLOSED)
                {
                    hasChequingAccount = true;
                    myChequingAccounts = new List<ChequingAccount>();
                    List<ChequingAccountData> allChequingAccountData =
                        DM.ReadChequingAccountOfCustomer(customerID);

                    foreach (ChequingAccountData chequingAccountData in allChequingAccountData)
                    {
                        string accountID = chequingAccountData.accountID;
                        bool isAccountOpen = chequingAccountData.accountStatus == AccountStatus.ACTIVE;
                        string openingDate = chequingAccountData.openingDate;
                        string closingDate = chequingAccountData.closingDate;
                        long balance = chequingAccountData.balance;

                        ChequingAccount chequingAccount = ChequingAccount.Generate(accountID, customerID,
                            isAccountOpen, openingDate, closingDate, balance);

                        myChequingAccounts.Add(chequingAccount);
                    }
                }

                if (customerData.tfsAccountStatus == AccountStatus.ACTIVE ||
                    customerData.tfsAccountStatus == AccountStatus.CLOSED)
                {
                    hasTFSAccount = true;
                    TFSAccountData tfsAccountData = DM.ReadTFSAccountOfCustomer(customerID);
                    string accountID = tfsAccountData.accountID;
                    bool isAccountOpen = tfsAccountData.accountStatus == AccountStatus.ACTIVE;
                    string openingDate = tfsAccountData.openingDate;
                    string closingDate = tfsAccountData.closingDate;
                    long balance = tfsAccountData.balance;

                    myTFSAccount = TFSAccount.Generate(accountID, customerID,
                        isAccountOpen, openingDate, closingDate, balance);
                }

                if (customerData.liabilityAccountStatus == AccountStatus.ACTIVE)
                {

                    LiabilityAccountData liabilityAccountData = DM.ReadLiabilityAccountOfCustomer(customerID);
                    string accountID = liabilityAccountData.accountID;
                    long balance = liabilityAccountData.balance;

                    hasLiabilityAccount = true;
                    myLiabilityAccount = LiabilityAccount.Generate(accountID, customerID, balance);
                }


                Customer customer = Customer.Generate(customerID, name, joiningDate, hasChequingAccount,
                    myChequingAccounts, hasTFSAccount, myTFSAccount, hasLiabilityAccount, myLiabilityAccount);

                Bank.customerList.Add(customer);

            }
        }

        private void AddCustomerToDatabase(Customer customer)
        {
            CustomerData customerData = new CustomerData();

            customerData.customerID = customer.CustomerID;
            customerData.name = customer.Name;
            customerData.joiningDate = customer.DateJoined;

            if (customer.HasChequingAccount)
            {
                customerData.chequingAccountStatus = AccountStatus.CLOSED;

                foreach (ChequingAccount chA in customer.myChequingAccounts)
                {
                    if (chA.IsAccountOpen)
                    {
                        customerData.chequingAccountStatus = AccountStatus.ACTIVE;
                        break;
                    }
                }
            }
            else
            {
                customerData.chequingAccountStatus = AccountStatus.NOT_EXISTS;
            }

            if (customer.HasTFSAccount)
            {
                if (customer.myTFSAccount.IsAccountOpen)
                    customerData.tfsAccountStatus = AccountStatus.ACTIVE;
                else
                    customerData.tfsAccountStatus = AccountStatus.CLOSED;
            }

            else
            {
                customerData.tfsAccountStatus = AccountStatus.NOT_EXISTS;
            }

            if (customer.HasLiabilityAccount)
            {
                customerData.liabilityAccountStatus = AccountStatus.ACTIVE;
            }

            else
            {
                customerData.liabilityAccountStatus = AccountStatus.NOT_EXISTS;
            }

            DM.InsertCustomer(customerData);
        }

        public void AddCustomer(string name)
        {
            Customer customer = new Customer(name);
      
            AddCustomerToDatabase(customer);
            Bank.customerList.Add(customer);
            DM.UpdateCustomerIDCount(Bank.CustomerID.Current);
        }

        public void UpdateCustomerName(Customer customer, string newName)
        {
            customer.Name = newName;
            DM.UpdateCustomerName(customer.CustomerID, newName);
        }

        public void UpdateCustomerDateOfJoining(Customer customer, string newDate)
        {
            customer.DateJoined = newDate;
            DM.UpdateCustomerDOJ(customer.CustomerID, newDate);
        }

        public void AddChequingAccount(Customer customer, long balance)
        {
            ChequingAccount account = (ChequingAccount) customer.OpenGeneralAccount(
                                                        AccountType.ChequingAccount, balance);

            ChequingAccountData data = new ChequingAccountData();
            data.accountID = account.AccountID;
            data.customerID = account.CustomerID;
            data.accountStatus = AccountStatus.ACTIVE;
            data.openingDate = account.OpeningDate;
            data.closingDate = account.ClosingDate;
            data.balance = account.Balance;

            DM.InsertChequingAccount(data);

            if (customer.myChequingAccounts.Count == 1)
                DM.UpdateCustomerChequingAccountStatus(customer.CustomerID, AccountStatus.ACTIVE);

            DM.UpdateChequingAccountIDCount(Bank.ChequingAccountID.Current);
            DM.UpdateActivityCount(Bank.Logger.CurrentActivity);
            DM.UpdateBankBalance(Bank.BankBalance);
        }

        public void AddTFSAccount(Customer customer, long balance)
        {
            TFSAccount account = (TFSAccount)customer.OpenGeneralAccount(AccountType.TFSAccount, balance);

            TFSAccountData data = new TFSAccountData();
            data.accountID = account.AccountID;
            data.customerID = customer.CustomerID;
            data.accountStatus = AccountStatus.ACTIVE;
            data.openingDate = account.OpeningDate;
            data.closingDate = account.ClosingDate;
            data.balance = account.Balance;

            DM.InsertTFSAccount(data);
            DM.UpdateCustomerTFSAccountStatus(customer.CustomerID, AccountStatus.ACTIVE);
            DM.UpdateTFSAccountIDCount(Bank.TFSAccountID.Current);
            DM.UpdateActivityCount(Bank.Logger.CurrentActivity);
            DM.UpdateBankBalance(Bank.BankBalance);
        }

        public void AddLiabilityAccount(Customer customer, long balance)
        {
            LiabilityAccount account = customer.OpenLiabilityAccount(balance);

            LiabilityAccountData data = new LiabilityAccountData();
            data.accountID = account.AccountID;
            data.customerID = customer.CustomerID;
            data.balance = balance;

            DM.InsertLiabilityAccount(data);
            DM.UpdateCustomerLiabilityccountStatus(customer.CustomerID, AccountStatus.ACTIVE);
            DM.UpdateLiabilityAccountIDCount(Bank.LiabilityAccountID.Current);
            DM.UpdateActivityCount(Bank.Logger.CurrentActivity);
            DM.UpdateBankBalance(Bank.BankBalance);
        }

        public void CloseChequingAccount(Customer customer, ChequingAccount account)
        {
            //call close method
            account.Close();

            // update account status in Chequing Account Table
            DM.UpdateChequingAccountStatus(account.AccountID, AccountStatus.CLOSED);

            // update customer chequing account status
            bool allClosed = true;
            foreach (ChequingAccount acc in customer.myChequingAccounts)
            {
                if (acc.IsAccountOpen)
                {
                    allClosed = false;
                    break;
                }
            }

            if(allClosed)
                DM.UpdateCustomerChequingAccountStatus(account.CustomerID, AccountStatus.CLOSED);
        }

        public void CloseTFSAccount(Customer customer, TFSAccount account)
        {
            account.Close();
            DM.UpdateTFSAccountStatus(account.AccountID, AccountStatus.CLOSED);
            DM.UpdateCustomerTFSAccountStatus(account.CustomerID, AccountStatus.CLOSED);
        }

        public void ReopenChequingAccount(Customer customer, ChequingAccount account)
        {
            // Reopen chequing account method
            account.Reopen();

            // Update Chequing Account status in Customer Table
            DM.UpdateCustomerChequingAccountStatus(customer.CustomerID, AccountStatus.ACTIVE);

            //Update Chequing Account status in Chequing Account Table
            DM.UpdateChequingAccountStatus(account.AccountID, AccountStatus.ACTIVE);
        }

        public void ReopenTFSAccount(Customer customer, TFSAccount account)
        {
            account.Reopen();

            DM.UpdateCustomerTFSAccountStatus(customer.CustomerID, AccountStatus.ACTIVE);

            DM.UpdateTFSAccountStatus(account.AccountID, AccountStatus.ACTIVE);
        }


        public void UpdateChequingAccountBalance(ChequingAccount account, long byAmount)
        {

            if (byAmount > 0)
                account.Deposit(byAmount);
            else
                account.Withdraw(-byAmount);

            long newBalance = account.Balance;

            DM.UpdateChequingAccountBalance(account.AccountID, newBalance);
            
            DM.UpdateActivityCount(Bank.Logger.CurrentActivity);
            DM.UpdateBankBalance(Bank.BankBalance);
        }

        public string ReadChequingAccountStatus(string accountID)
        {
             return DM.ReadChequingAccountStatus(accountID);  
        }

        public string ReadTFSAccountStatus(string accountID)
        {
            return DM.ReadTFSAccountStatus(accountID);
        }

        public void UpdateTFSAccountBalance(TFSAccount account, long byAmount)
        {
            if (byAmount > 0)
                account.Deposit(byAmount);
            else
                account.Withdraw(-byAmount);

            long newBalance = account.Balance + byAmount;

            DM.UpdateTFSAccountBalance(account.AccountID, newBalance);
            DM.UpdateActivityCount(Bank.Logger.CurrentActivity);
            DM.UpdateBankBalance(Bank.BankBalance);
        }

        public Customer FindCustomerByChequingAccountID(string accountID)
        {
            string customerID = DM.ReadChequingAccountCustomerID(accountID);
            return FindCustomerByCustomerID(customerID);
        }

        public Customer FindCustomerByTFSAccountID(string accountID)
        {
            string customerID = DM.ReadTFSAccountCustomerID(accountID);
            return FindCustomerByCustomerID(customerID);    
        }

        public Customer FindCustomerByLiabilityAccountID(string accountID)
        {
            string customerID = DM.ReadLiabilityAccountCustomerID(accountID);
            return FindCustomerByCustomerID(customerID);
        }

        public bool IsLiabilityAcccountValid(string accountID)
        {
            string customerID = DM.ReadLiabilityAccountCustomerID(accountID);
            return !string.IsNullOrEmpty(customerID);
        }

        public Customer FindCustomerByCustomerID(string customerID)
        {
            Customer myCustomer = null;
            foreach (Customer customer in Bank.customerList)
            {
                if (customer.CustomerID == customerID)
                {
                    myCustomer = customer;
                    break;
                }
            }

            return myCustomer;
        }

        public ChequingAccount FindCustomerChequingAccount(Customer customer, string accountID)
        {
            ChequingAccount ca = null;
            foreach (ChequingAccount account in customer.myChequingAccounts)
            {
                if (account.AccountID == accountID)
                {
                    ca = account;
                    break;
                }
            }

            return ca;
        }

        public void PayLoan(LiabilityAccount acccount, long amount, long interest)
        {
            // pay loan
            acccount.RepayLoan(amount, interest);
            
            //update Liability Account balance in table
            long loanBalance = acccount.LoanBalance;
            DM.UpdateLiabilityAccountBalance(acccount.AccountID, loanBalance);
            
            // Update Transaction number
            DM.UpdateActivityCount(Bank.Logger.CurrentActivity);
            DM.UpdateBankBalance(Bank.BankBalance);
        }

        public void IssueLoan(LiabilityAccount account, long amount)
        {
            account.IssueLoan(amount);
            DM.UpdateLiabilityAccountBalance(account.AccountID, amount);
            DM.UpdateActivityCount(Bank.Logger.CurrentActivity);
            DM.UpdateBankBalance(Bank.BankBalance);
        }
        

    
    }
}
