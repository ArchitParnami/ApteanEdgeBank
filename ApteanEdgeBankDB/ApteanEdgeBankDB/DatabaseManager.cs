using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ApteanEdgeBankDB
{
    public class DatabaseManager : DBQueries
    {
        private SqlConnection connection;

        private void CreateConstantsTable()
        {
            try
            {
                using (SqlCommand createConstantsTable = new SqlCommand(CREATE_CONSTANTS_TABLE, connection))
                {
                    connection.Open();
                    createConstantsTable.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        private void CreateLiabilityAccountTable()
        {
            try
            {
                using (SqlCommand createLiabilityAccountTable = new SqlCommand(CREATE_LIABILITY_ACCOUNT_TABLE, connection))
                {
                    connection.Open();
                    createLiabilityAccountTable.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        private void CreateTFSAccountTable()
        {
            try
            {
                using (SqlCommand createTFSAccountTable = new SqlCommand(CREATE_TFS_ACCOUNT_TABLE, connection))
                {
                    connection.Open();
                    createTFSAccountTable.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        private void CreateChequingAccountTable()
        {
            try
            {
                using (SqlCommand createChequingAccountTable = new SqlCommand(CREATE_CHEQUING_ACCOUNT_TABLE, connection))
                {
                    connection.Open();
                    createChequingAccountTable.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        private void CreateCustomerTable()
        {

            int timeout = 10 * 1000; //10 secs
            int time = 0;
            int interval = 1000;

            // serious problem...
            while (!checkIfDatabaseExists())
            {
                Thread.Sleep(interval);
                time = time + interval;
                if (time == timeout)
                    break;
            }

            try
            {

                using (SqlCommand createCustomerTable = new SqlCommand(CREATE_CUSTOMER_TABLE, connection))
                {
                    connection.Open();
                    createCustomerTable.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        private void CreateDatabase()
        {

            try
            {
                SqlConnection tempConnection = new SqlConnection(TEMP_CONNECTION_STRING);

                using (tempConnection)
                {

                    using (SqlCommand createDatabaseCommand = new SqlCommand(CREATE_DATABASE, tempConnection))
                    {
                        tempConnection.Open();
                        createDatabaseCommand.ExecuteNonQuery();
                        tempConnection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool checkIfDatabaseExists()
        {


            bool result = false;
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand(SELECT_DATABASE_QUERY, connection))
                {
                    connection.Open();
                    Object num = sqlCmd.ExecuteScalar();
                    if (num == null)
                        result = false;
                    else
                        result = true;

                    connection.Close();
                }
            }

            catch (Exception)
            {
                result = false;
            }

            finally
            {
                connection.Close();
            }

            return result;
        }

        private void InitializeDatabase()
        {
            bool exists = checkIfDatabaseExists();
            if (!exists)
            {
                CreateDatabase();
                CreateCustomerTable();
                CreateChequingAccountTable();
                CreateTFSAccountTable();
                CreateLiabilityAccountTable();
                CreateConstantsTable();
            }
        }

        public DatabaseManager()
        {
            connection = new SqlConnection(CONNECTION_STRING);
            InitializeDatabase();
        }

        public Constant ReadConstants()
        {
            Constant constant = null;

            try
            {

                using (SqlCommand cmd = new SqlCommand(SELECT_CONSTANTS_QUERY, connection))
                {
                    connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        constant = new Constant();
                        dr.Read();
                        constant.BANK_BALANCE = long.Parse(dr[BANK_BALANCE].ToString());
                        constant.LOAN_LIMIT = long.Parse(dr[LOAN_LIMIT].ToString());
                        constant.CUSTOMER_ID_COUNT = int.Parse(dr[CUSTOMER_ID_COUNT].ToString());
                        constant.CHEQUING_ACCOUNT_ID_COUNT = int.Parse(dr[CHEQUING_ACCOUNT_ID_COUNT].ToString());
                        constant.TFS_ACCOUNT_ID_COUNT = int.Parse(dr[TFS_ACCOUNT_ID_COUNT].ToString());
                        constant.LIABILITY_ACCOUNT_ID_COUNT = int.Parse(dr[LIABILITY_ACCOUNT_ID_COUNT].ToString());
                        constant.ACTIVITY_COUNT = int.Parse(dr[ACTIVITY_COUNT].ToString());
                    }

                    connection.Close();
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return constant;

        }

        public List<CustomerData> ReadCustomers()
        {
            List<CustomerData> customers = new List<CustomerData>();

            try
            {
               
                    using (SqlCommand cmd = new SqlCommand(SELECT_CUSTOMERS_QUERY, connection))
                    {
                        connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CustomerData customer;
                                customer.customerID = dr[CUSTOMER_ID].ToString();
                                customer.name = dr[NAME].ToString();
                                customer.joiningDate = dr[JOINING_DATE].ToString();
                                customer.chequingAccountStatus = dr[CHEQUING_ACCOUNT].ToString();
                                customer.tfsAccountStatus = dr[TFS_ACCOUNT].ToString();
                                customer.liabilityAccountStatus = dr[LIABILITY_ACCOUNT].ToString();

                                customers.Add(customer);
                            }
                        }

                        connection.Close();
                    }
                
            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return customers;
        }

        public List<ChequingAccountData> ReadChequingAccountOfCustomer(string customerID)
        {
            List<ChequingAccountData> chequingAccounts = new List<ChequingAccountData>();

            try
            {

                string QUERY = SELECT_CHEQUING_ACCOUNT_BY_CUSTOMER_ID(customerID);

                    using (SqlCommand cmd = new SqlCommand(QUERY, connection))
                    {
                        connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ChequingAccountData chequingAccount = new ChequingAccountData();
                                chequingAccount.accountID = dr[CHEQUING_ACCOUNT_ID].ToString();
                                chequingAccount.customerID = dr[CUSTOMER_ID].ToString();
                                chequingAccount.accountStatus = dr[ACCOUNT_STATUS].ToString();
                                chequingAccount.openingDate = dr[OPENING_DATE].ToString();
                                chequingAccount.closingDate = dr[CLOSING_DATE].ToString();
                                chequingAccount.balance = (long)dr[BALANCE];

                                chequingAccounts.Add(chequingAccount);
                            }
                        }

                        connection.Close();

                    }
                
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }


            return chequingAccounts;
        }

        public TFSAccountData ReadTFSAccountOfCustomer(string customerID)
        {
            TFSAccountData tfsAcccount = null;

            try
            {

                string QUERY = SELECT_TFS_ACCOUNT_BY_CUSTOMER_ID(customerID);

                    using (SqlCommand cmd = new SqlCommand(QUERY, connection))
                    {
                        connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            tfsAcccount = new TFSAccountData();
                            dr.Read();
                            tfsAcccount.accountID = dr[TFS_ACCOUNT_ID].ToString();
                            tfsAcccount.customerID = dr[CUSTOMER_ID].ToString();
                            tfsAcccount.accountStatus = dr[ACCOUNT_STATUS].ToString();
                            tfsAcccount.openingDate = dr[OPENING_DATE].ToString();
                            tfsAcccount.closingDate = dr[CLOSING_DATE].ToString();
                            tfsAcccount.balance = (long)dr[BALANCE];
                        }
                        connection.Close();
                    }
                
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }


            return tfsAcccount;
        }

        public LiabilityAccountData ReadLiabilityAccountOfCustomer(string customerID)
        {
            LiabilityAccountData liabilityAccount = null;

            try
            {

                string QUERY = SELECT_LIABILITY_ACCOUNT_BY_CUSTOMER_ID(customerID);

                    using (SqlCommand cmd = new SqlCommand(QUERY, connection))
                    {
                        connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            liabilityAccount = new LiabilityAccountData();
                            dr.Read();
                            liabilityAccount.accountID = dr[LIABILITY_ACCOUNT_ID].ToString();
                            liabilityAccount.customerID = dr[CUSTOMER_ID].ToString();
                            liabilityAccount.balance = (long)dr[BALANCE];
                        }

                        connection.Close();
                    }
                
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }

            return liabilityAccount;
        }

        public void InsertCustomer(CustomerData customerData)
        {
            string QUERY = INSERT_INTO_CUSTOMER(customerData);
            ExecuteNonQuery(QUERY);
        }

        public void InitializeConstant(Constant constant)
        {
            string QUERY = INSERT_INTO_CONSTANTS(constant);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateBankBalance(long bankBalance)
        {
            string QUERY = UPDATE_BANK_BALANCE_CONSTANT(bankBalance);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateLoanLimit(long loanLimit)
        {
            string QUERY = UPDATE_LOAN_LIMIT_CONSTANT(loanLimit);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateCustomerIDCount(int count)
        {
            string QUERY = UPDATE_CUSTOMER_ID_CONSTANT(count);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateChequingAccountIDCount(int count)
        {
            string QUERY = UPDATE_CHEQUING_ACCOUNT_ID_CONSTANT(count);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateLiabilityAccountIDCount(int count)
        {
            string QUERY = UPDATE_LIABILITY_ACCOUNT_ID_CONSTANT(count);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateTFSAccountIDCount(int count)
        {
            string QUERY = UPDATE_TFS_ACCOUNT_ID_CONSTANT(count);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateActivityCount(int count)
        {
            string QUERY = UPDATE_ACTIVITY_COUNT_CONSTANT(count);
            ExecuteNonQuery(QUERY);
        }
        
        public void UpdateCustomerName(string customerID, string newName)
        {
            string QUERY = UPDATE_CUSTOMER_NAME(customerID, newName);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateCustomerDOJ(string customerID, string newDOJ)
        {
            string QUERY = UPDATE_CUSTOMER_DOJ(customerID, newDOJ);
            ExecuteNonQuery(QUERY);
        }

        public void InsertChequingAccount(ChequingAccountData data)
        {
            string QUERY = INSERT_INTO_CHEQUING_ACCOUNT(data);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateCustomerChequingAccountStatus(string customerID, string status)
        {
            string QUERY = UPDATE_CUSTOMER_CHEQUING_ACCOUNT_STATUS(customerID, status);
            ExecuteNonQuery(QUERY);
        }

        public void InsertTFSAccount(TFSAccountData data)
        {
            string QUERY = INSERT_INTO_TFS_ACCOUNT(data);
            ExecuteNonQuery(QUERY);
        }
        
        public void UpdateCustomerTFSAccountStatus(string customerID, string status)
        {
            string QUERY = UPDATE_CUSTOMER_TFS_ACCOUNT_STATUS(customerID, status);
            ExecuteNonQuery(QUERY);
        }

        public void InsertLiabilityAccount(LiabilityAccountData data)
        {
            string QUERY = INSERT_INTO_LIABILITY_ACCOUNT(data);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateCustomerLiabilityccountStatus(string customerID, string status)
        {
            string QUERY = UPDATE_CUSTOMER_LIABILITY_ACCOUNT_STATUS(customerID, status);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateChequingAccountStatus(string accountId, string status)
        {
            string QUERY = UPDATE_CHEQUING_ACCOUNT_STATUS(accountId, status);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateTFSAccountStatus(string accountId, string status)
        {
            string QUERY = UPDATE_TFS_ACCOUNT_STATUS(accountId, status);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateChequingAccountBalance(string accountID, long balance)
        {
            string QUERY = UPDATE_CHEQUING_ACCOUNT_BALANCE(accountID, balance);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateTFSAccountBalance(string accountID, long balance)
        {
            string QUERY = UPDATE_TFS_ACCOUNT_BALANCE(accountID, balance);
            ExecuteNonQuery(QUERY);
        }

        public void UpdateLiabilityAccountBalance(string accountID, long balance)
        {
            string QUERY = UPDATE_LIABILITY_ACCOUNT_BALANCE(accountID, balance);
            ExecuteNonQuery(QUERY);
        }


        public string ReadChequingAccountStatus(string accountID)
        {
            string QUERY = SELECT_CHEQUING_ACCOUNT_STATUS(accountID);
            string status = "Not Exists";
            ExecuteReadStatusQuery(QUERY, ref status);
            return status;
        }

        public string ReadTFSAccountStatus(string accountID)
        {
            string QUERY = SELECT_TFS_ACCOUNT_STATUS(accountID);
            string status = "Not Exists";
            ExecuteReadStatusQuery(QUERY, ref status);
            return status;
        }

        public string ReadChequingAccountCustomerID(string accountID)
        {
            string customerID = "";
            string QUERY = SELECT_CUSTOMER_ID_BY_CHEQUING_ACCOUNT(accountID);
            ExecuteFindCustomerQuery(QUERY, ref customerID);
            return customerID;
        }

        public string ReadTFSAccountCustomerID(string accountID)
        {
            string customerID = "";
            string QUERY = SELECT_CUSTOMER_ID_BY_TFS_ACCOUNT(accountID);
            ExecuteFindCustomerQuery(QUERY, ref customerID);
            return customerID;
        }

        public string ReadLiabilityAccountCustomerID(string accountID)
        {
            string customerID = "";
            string QUERY = SELECT_CUSTOMER_ID_BY_LIABILITY_ACCOUNT(accountID);
            ExecuteFindCustomerQuery(QUERY, ref customerID);
            return customerID;
        }

        private void ExecuteNonQuery(string QUERY)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(QUERY, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        private void ExecuteReadStatusQuery(string QUERY, ref string status)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(QUERY, connection))
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        status = dr[ACCOUNT_STATUS].ToString();
                    }
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        private void ExecuteFindCustomerQuery(string QUERY, ref string customerID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(QUERY, connection))
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        customerID = dr[0].ToString();
                    }
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }
    
        
    }
}
