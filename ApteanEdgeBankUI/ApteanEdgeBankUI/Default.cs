using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankUI
{
    public static class Default
    {
        public static readonly long BANK_BALANCE = 1000000;
        public static readonly long LOAN_LIMIT = 10000;
        public static readonly int CUSTOMER_ID_COUNT = 0;
        public static readonly int CHEQUING_ACCOUNT_ID_COUNT = 0;
        public static readonly int TFS_ACCOUNT_ID_COUNT = 0;
        public static readonly int LIABILITY_ACCOUNT_ID_COUNT = 0;
        public static readonly int ACTIVITY_COUNT = 0;

        public static readonly long CHEQUING_ACCOUNT_STARTING_BALANCE_LIMIT = 100000;
        public static readonly long TFS_ACCOUNT_BALANCE_LIMIT = 5000;

        public static readonly string Chequing = "Chequing";
        public static readonly string TFSA = "TFSA";
        public static readonly string Liability = "Liability";

        public static readonly long CHEQUING_ACCOUNT_TRANS_LIMIT = 100000;
    }
}
