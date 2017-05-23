using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankDB
{
    public abstract class DBQueries : DBConstants
    {

        protected static readonly string CREATE_CUSTOMER_TABLE =
            "CREATE TABLE " + " [" + CUSTOMER_TABLE + "] " +
            "(" +
                " [" + CUSTOMER_ID + "] " + "varchar(10)" + " PRIMARY KEY " + "," +
                " [" + NAME + "] " + "varchar(50)" + " ," +
                " [" + JOINING_DATE + "] " + "varchar(30)" + " ," +
                " [" + CHEQUING_ACCOUNT + "] " + "varchar(15)" + " ," +
                " [" + TFS_ACCOUNT + "] " + "varchar(15)" + " ," +
                " [" + LIABILITY_ACCOUNT + "] " + "varchar(15)" +
             ");";


        protected static readonly string CREATE_CHEQUING_ACCOUNT_TABLE =
             "CREATE TABLE " + " [" + CHEQUING_ACCOUNT_TABLE + "] " +
            "(" +
                " [" + CHEQUING_ACCOUNT_ID + "] " + "varchar(10)" + " PRIMARY KEY " + "," +
                " [" + CUSTOMER_ID + "] " + "varchar(10)" + " ," +
                " [" + ACCOUNT_STATUS + "] " + "varchar(15)" + " ," +
                " [" + OPENING_DATE + "] " + "varchar(30)" + " ," +
                " [" + CLOSING_DATE + "] " + "varchar(30)" + " ," +
                " [" + BALANCE + "] " + "bigint" +
             ");";

        protected static readonly string CREATE_TFS_ACCOUNT_TABLE =
             "CREATE TABLE " + " [" + TFS_ACCOUNT_TABLE + "] " +
            "(" +
                " [" + TFS_ACCOUNT_ID + "] " + "varchar(10)" + " PRIMARY KEY " + "," +
                " [" + CUSTOMER_ID + "] " + "varchar(10)" + " ," +
                " [" + ACCOUNT_STATUS + "] " + "varchar(15)" + " ," +
                " [" + OPENING_DATE + "] " + "varchar(30)" + " ," +
                " [" + CLOSING_DATE + "] " + "varchar(30)" + " ," +
                " [" + BALANCE + "] " + "bigint" +
             ");";

        protected static readonly string CREATE_LIABILITY_ACCOUNT_TABLE =
             "CREATE TABLE " + " [" + LIABILITY_ACCOUNT_TABLE + "] " +
            "(" +
                " [" + LIABILITY_ACCOUNT_ID + "] " + "varchar(10)" + " PRIMARY KEY " + "," +
                " [" + CUSTOMER_ID + "] " + "varchar(10)" + " ," +
                 " [" + BALANCE + "] " + "bigint" +
             ");";

        protected static readonly string CREATE_CONSTANTS_TABLE =
            "CREATE TABLE " + " [" + CONSTANTS_TABLE + "] " +
           "(" +
               " [" + BANK_BALANCE + "] " + "bigint" + ", " +
               " [" + LOAN_LIMIT + "] " + "int" + ", " +
               " [" + CUSTOMER_ID_COUNT + "] " + "int" + ", " +
               " [" + CHEQUING_ACCOUNT_ID_COUNT + "] " + "int" + ", " +
               " [" + TFS_ACCOUNT_ID_COUNT + "] " + "int" + ", " +
               " [" + LIABILITY_ACCOUNT_ID_COUNT + "] " + "int" + ", " +
               " [" + ACTIVITY_COUNT + "] " + "int" +
            ");";

        protected static readonly string SELECT_DATABASE_QUERY =
          "SELECT database_id " +
          "FROM sys.databases " +
          "WHERE Name = '" + DATABASE_NAME + "'";

        protected static readonly string SELECT_CONSTANTS_QUERY =
           "SELECT * " +
           "FROM " + CONSTANTS_TABLE;

        protected static readonly string SELECT_CUSTOMERS_QUERY =
            "SELECT * " +
            "FROM " + CUSTOMER_TABLE;

        protected static string SELECT_CHEQUING_ACCOUNT_BY_CUSTOMER_ID(string customerID)
        {
            string QUERY = 
            "SELECT * " +
            "FROM " + " [" + CHEQUING_ACCOUNT_TABLE + "] " +
            "WHERE " + " [" + CUSTOMER_ID + "] = " + "'" + customerID + "'";

            return QUERY;
        }

        protected static string SELECT_TFS_ACCOUNT_BY_CUSTOMER_ID(string customerID)
        {
            string QUERY =
            "SELECT * " +
            "FROM " + " [" + TFS_ACCOUNT_TABLE + "] " +
            "WHERE " + " [" + CUSTOMER_ID + "] = " + "'" + customerID + "'";

            return QUERY;
        }

        protected static string SELECT_LIABILITY_ACCOUNT_BY_CUSTOMER_ID(string customerID)
        {
            string QUERY =
             "SELECT * " +
            "FROM " + " [" + LIABILITY_ACCOUNT_TABLE + "] " +
            "WHERE " + " [" + CUSTOMER_ID + "] = " + "'" + customerID + "'";

            return QUERY;
        }

        protected static string SELECT_CUSTOMER_ID_BY_CHEQUING_ACCOUNT(string accountID)
        {
            string QUERY =
             "SELECT  " + " [" + CUSTOMER_ID + "] "+
            "FROM " + " [" + CHEQUING_ACCOUNT_TABLE + "] " +
            "WHERE " + " [" + CHEQUING_ACCOUNT_ID + "] = " + "'" + accountID + "'";
           
            return QUERY;
        }

        protected static string SELECT_CUSTOMER_ID_BY_TFS_ACCOUNT(string accountID)
        {
            string QUERY =
             "SELECT  " + " [" + CUSTOMER_ID + "] " +
            "FROM " + " [" + TFS_ACCOUNT_TABLE + "] " +
            "WHERE " + " [" + TFS_ACCOUNT_ID + "] = " + "'" + accountID + "'";

            return QUERY;
        }

        protected static string SELECT_CUSTOMER_ID_BY_LIABILITY_ACCOUNT(string accountID)
        {
            string QUERY =
             "SELECT  " + " [" + CUSTOMER_ID + "] " +
            "FROM " + " [" + LIABILITY_ACCOUNT_TABLE + "] " +
            "WHERE " + " [" + LIABILITY_ACCOUNT_ID + "] = " + "'" + accountID + "'";

            return QUERY;
        }


        protected static string INSERT_INTO_CUSTOMER(CustomerData customerData)
        {
            string QUERY =
                "INSERT INTO " + CUSTOMER_TABLE + " Values " +
                "(" +
                    "'" + customerData.customerID + "'" + ", " +
                    "'" + customerData.name + "'" + ", " +
                    "'" + customerData.joiningDate + "'" + ", " +
                    "'" + customerData.chequingAccountStatus + "'" + ", " +
                    "'" + customerData.tfsAccountStatus + "'" + ", " +
                    "'" + customerData.liabilityAccountStatus + "'" +
                ")";

            return QUERY;
        }

        protected static string INSERT_INTO_CONSTANTS(Constant constant)
        {
            string QUERY =
                "INSERT INTO " + CONSTANTS_TABLE + " Values " +
                "(" +
                        constant.BANK_BALANCE  + ", " +
                        constant.LOAN_LIMIT + ", " +
                        constant.CUSTOMER_ID_COUNT + ", " +
                        constant.CHEQUING_ACCOUNT_ID_COUNT + ", " +
                        constant.TFS_ACCOUNT_ID_COUNT + ", " +
                        constant.LIABILITY_ACCOUNT_ID_COUNT + ", " +
                        constant.ACTIVITY_COUNT + 
                ")";

            return QUERY;
        }

      
        protected static string UPDATE_BANK_BALANCE_CONSTANT(long bankBalance)
        {
            string QUERY =
                " UPDATE " + CONSTANTS_TABLE +
                " SET " + "[" + BANK_BALANCE + "]" + " = " + bankBalance;

            return QUERY;
        }


        protected static string UPDATE_LOAN_LIMIT_CONSTANT(long loanLimit)
        {
            string QUERY =
                " UPDATE " + CONSTANTS_TABLE +
                " SET " + "[" + LOAN_LIMIT + "]" + " = " + loanLimit;

            return QUERY;
        }

        protected static string UPDATE_CUSTOMER_ID_CONSTANT(int idCount)
        {
            string QUERY =
                " UPDATE " + CONSTANTS_TABLE +
                " SET " + "[" + CUSTOMER_ID_COUNT + "]" + " = " + idCount;

            return QUERY;
        }

        protected static string UPDATE_CHEQUING_ACCOUNT_ID_CONSTANT(int count)
        {
            string QUERY =
                " UPDATE " + CONSTANTS_TABLE +
                " SET " + "[" + CHEQUING_ACCOUNT_ID_COUNT + "]" + " = " + count;

            return QUERY;
        }

        protected static string UPDATE_LIABILITY_ACCOUNT_ID_CONSTANT(int count)
        {
            string QUERY =
                " UPDATE " + CONSTANTS_TABLE +
                " SET " + "[" + LIABILITY_ACCOUNT_ID_COUNT + "]" + " = " + count;

            return QUERY;
        }

        protected static string UPDATE_TFS_ACCOUNT_ID_CONSTANT(int count)
        {
            string QUERY =
                " UPDATE " + CONSTANTS_TABLE +
                " SET " + "[" + TFS_ACCOUNT_ID_COUNT + "]" + " = " + count;

            return QUERY;
        }

        protected static string UPDATE_ACTIVITY_COUNT_CONSTANT(int count)
        {
            string QUERY =
                " UPDATE " + CONSTANTS_TABLE +
                " SET " + "[" + ACTIVITY_COUNT + "]" + " = " + count;

            return QUERY;
        }

        protected static string UPDATE_CUSTOMER_NAME(string customerID, string newName)
        {
            string QUERY =
                " UPDATE " + CUSTOMER_TABLE +
                " SET " + "[" + NAME + "]" + " = " + "'" + newName + "'" +
                " WHERE " + "[" + CUSTOMER_ID + "]" + " = " + "'" + customerID + "'"; 

            return QUERY;
        }

        protected static string UPDATE_CUSTOMER_DOJ(string customerID, string newDOJ)
        {
            string QUERY =
                " UPDATE " + CUSTOMER_TABLE +
                " SET " + "[" + JOINING_DATE + "]" + " = " + "'" + newDOJ + "'" +
                " WHERE " + "[" + CUSTOMER_ID + "]" + " = " + "'" + customerID + "'";

            return QUERY;
        }

        protected static string UPDATE_CUSTOMER_CHEQUING_ACCOUNT_STATUS(string customerID, string status)
        {
            string QUERY =
                " UPDATE " +  CUSTOMER_TABLE  +
                " SET " + "[" + CHEQUING_ACCOUNT+ "]" + " = " + "'" + status + "'" +
                " WHERE " + "[" + CUSTOMER_ID + "]" + " = " + "'" + customerID + "'";

            return QUERY;
        }

        protected static string UPDATE_CUSTOMER_TFS_ACCOUNT_STATUS(string customerID, string status)
        {
            string QUERY =
                " UPDATE " + CUSTOMER_TABLE +
                " SET " + "[" + TFS_ACCOUNT + "]" + " = " + "'" + status + "'" +
                " WHERE " + "[" + CUSTOMER_ID + "]" + " = " + "'" + customerID + "'";

            return QUERY;
        }

        protected static string UPDATE_CUSTOMER_LIABILITY_ACCOUNT_STATUS(string customerID, string status)
        {
            string QUERY =
                " UPDATE " + CUSTOMER_TABLE +
                " SET " + "[" + LIABILITY_ACCOUNT + "]" + " = " + "'" + status + "'" +
                " WHERE " + "[" + CUSTOMER_ID + "]" + " = " + "'" + customerID + "'";

            return QUERY;
        }

        protected static string UPDATE_CHEQUING_ACCOUNT_STATUS(string accountID, string status)
        {
            string QUERY =
                " UPDATE " + "[" + CHEQUING_ACCOUNT_TABLE + "]" +
                " SET " + "[" + ACCOUNT_STATUS + "]" + " = " + "'" + status + "'" +
                " WHERE " + "[" + CHEQUING_ACCOUNT_ID + "]" + " = " + "'" + accountID + "'";

            return QUERY;
        }

        protected static string UPDATE_TFS_ACCOUNT_STATUS(string accountID, string status)
        {
            string QUERY =
                " UPDATE " + "[" + TFS_ACCOUNT_TABLE + "]" +
                " SET " + "[" + ACCOUNT_STATUS + "]" + " = " + "'" + status + "'" +
                " WHERE " + "[" + TFS_ACCOUNT_ID + "]" + " = " + "'" + accountID + "'";

            return QUERY;
        }

        protected static string UPDATE_CHEQUING_ACCOUNT_BALANCE(string accountID, long balance)
        {
            string QUERY =
                " UPDATE " + "[" + CHEQUING_ACCOUNT_TABLE + "]" +
                " SET " + "[" + BALANCE + "]" + " =  " + balance +
                " WHERE " + "[" + CHEQUING_ACCOUNT_ID + "]" + " = " + "'" + accountID + "'";

            return QUERY;
        }

        protected static string UPDATE_TFS_ACCOUNT_BALANCE(string accountID, long balance)
        {
            string QUERY =
                " UPDATE " + "[" + TFS_ACCOUNT_TABLE + "]" +
                " SET " + "[" + BALANCE + "]" + " =  " + balance +
                " WHERE " + "[" + TFS_ACCOUNT_ID + "]" + " = " + "'" + accountID + "'";

            return QUERY;
        }

        protected static string UPDATE_LIABILITY_ACCOUNT_BALANCE(string accountID, long balance)
        {
            string QUERY =
                " UPDATE " + "[" + LIABILITY_ACCOUNT_TABLE + "]" +
                " SET " + "[" + BALANCE + "]" + " =  " + balance +
                " WHERE " + "[" + LIABILITY_ACCOUNT_ID + "]" + " = " + "'" + accountID + "'";

            return QUERY;
        }

        protected static string INSERT_INTO_TFS_ACCOUNT(TFSAccountData data)
        {
            string QUERY =
                "INSERT INTO " + "[" + TFS_ACCOUNT_TABLE + "]" + " Values " +
                "(" +
                    "'" + data.accountID + "'" + ", " +
                    "'" + data.customerID + "'" + ", " +
                    "'" + data.accountStatus + "'" + ", " +
                    "'" + data.openingDate + "'" + ", " +
                    "'" + data.closingDate + "'" + ", " +
                          data.balance +
                ")";

            return QUERY;
        }

        protected static string INSERT_INTO_CHEQUING_ACCOUNT(ChequingAccountData data)
        {
            string QUERY =
                "INSERT INTO " + "[" + CHEQUING_ACCOUNT_TABLE + "]" + " Values " +
                "(" +
                    "'" + data.accountID + "'" + ", " +
                    "'" + data.customerID + "'" + ", " +
                    "'" + data.accountStatus + "'" + ", " +
                    "'" + data.openingDate + "'" + ", " +
                    "'" + data.closingDate + "'" + ", " +
                          data.balance +
                ")";

            return QUERY;
        }

        protected static string INSERT_INTO_LIABILITY_ACCOUNT(LiabilityAccountData data)
        {
            string QUERY =
                "INSERT INTO " + "[" + LIABILITY_ACCOUNT_TABLE + "]" + " Values " +
                "(" +
                    "'" + data.accountID + "'" + ", " +
                    "'" + data.customerID + "'" + ", " +
                          data.balance +
                ")";

            return QUERY;
        }

        protected static string SELECT_CHEQUING_ACCOUNT_STATUS(string accountID)
        {
            string QUERY =
            "SELECT  " + " [" + ACCOUNT_STATUS + "] " +
            "FROM " + " [" + CHEQUING_ACCOUNT_TABLE + "] " +
            "WHERE " + " [" + CHEQUING_ACCOUNT_ID + "] = " + "'" + accountID + "'";

            return QUERY;
        }

        protected static string SELECT_TFS_ACCOUNT_STATUS(string accountID)
        {
            string QUERY =
            "SELECT  " + " [" + ACCOUNT_STATUS + "] " +
            "FROM " + " [" + TFS_ACCOUNT_TABLE + "] " +
            "WHERE " + " [" + TFS_ACCOUNT_ID + "] = " + "'" + accountID + "'";

            return QUERY;
        }
    
    }
}
