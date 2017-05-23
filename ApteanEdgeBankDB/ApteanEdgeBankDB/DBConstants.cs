using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankDB
{
    public abstract class DBConstants
    {
        protected static readonly string DATABASE_NAME = "ApteanEdgeBank";
        protected static readonly string CUSTOMER_TABLE = "Customer";
        protected static readonly string CHEQUING_ACCOUNT_TABLE = "Chequing Account";
        protected static readonly string TFS_ACCOUNT_TABLE = "TFS Account";
        protected static readonly string LIABILITY_ACCOUNT_TABLE = "Liability Account";
        protected static readonly string CONSTANTS_TABLE = "Constants";

        protected static readonly string CONNECTION_STRING = "Server= localhost;" +
                                                    "Database= ApteanEdgeBank;" +
                                                    "Integrated Security=True;";
        
        protected static readonly string TEMP_CONNECTION_STRING = "Server= localhost;" +
                                                               //     "Database= ApteanStore;" +
                                                                  "Integrated Security=True;";

        protected static readonly string CREATE_DATABASE = "CREATE DATABASE " + DATABASE_NAME;
        
        protected static readonly string CUSTOMER_ID = "Customer ID";
        protected static readonly string NAME = "Name";
        protected static readonly string JOINING_DATE = "Joining Date";
        protected static readonly string CHEQUING_ACCOUNT = "Chequing Account";
        protected static readonly string TFS_ACCOUNT = "TFS Account";
        protected static readonly string LIABILITY_ACCOUNT = "Liability Account";

        protected static readonly string CHEQUING_ACCOUNT_ID = "Chequing Account ID";
        protected static readonly string TFS_ACCOUNT_ID = "TFS Account ID";
        protected static readonly string LIABILITY_ACCOUNT_ID = "Liability Account ID";
        protected static readonly string ACCOUNT_STATUS = "Account Status";
        protected static readonly string BALANCE = "Balance";
        protected static readonly string OPENING_DATE = "Opening Date";
        protected static readonly string CLOSING_DATE = "Closing Date";

        public static readonly string BANK_BALANCE = "Bank Balance";
        public static readonly string LOAN_LIMIT = "Loan Limit";
        public static readonly string CUSTOMER_ID_COUNT = "Customer ID Count";
        public static readonly string CHEQUING_ACCOUNT_ID_COUNT = "Chequing Account ID Count";
        public static readonly string TFS_ACCOUNT_ID_COUNT = "TFS Account ID Count";
        public static readonly string LIABILITY_ACCOUNT_ID_COUNT = "Liability Account ID Count";
        public static readonly string ACTIVITY_COUNT = "Activity Count";


    }
}
