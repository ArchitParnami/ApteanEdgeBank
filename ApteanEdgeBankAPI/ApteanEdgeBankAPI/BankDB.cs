using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
    public static class Bank
    {
        private static bool bankDBInitialized = false;
        
        private static long bankBalance;
        private static long loanLimit;

        public static long LoanLimit
        {
            get
            {
                if (!bankDBInitialized)
                    ThrowException();

                return loanLimit;
            }

            set
            {
                if (!bankDBInitialized)
                    loanLimit = value;
                else
                    ThrowException();
            }
        }

        public static long BankBalance
        {
            get
            {
                if (!bankDBInitialized)
                    ThrowException();

                return bankBalance;
            }

            set
            {
                if (!bankDBInitialized)
                    bankBalance = value;
                else
                    ThrowException();
            }
        }

        internal static void DepositAmount(long amount)
        {
            bankBalance += amount;
            ActivityLedger.LogDeposit(amount, "Bank");
        }

        internal static void WithdrawAmount(long amount)
        {
            bankBalance -= amount;
            ActivityLedger.LogWithdrawl(amount, "Bank");
        }

        public static class CustomerID
        {
            private static string code = "CS";
            private static int counter = 0;

            internal static string Next()
            {
                counter++;
                return code + counter.ToString();
            }

            public static int Current
            {
                get 
                {
                    if (!bankDBInitialized)
                        ThrowException();

                    return counter; 
                }

                set
                {
                    if (!bankDBInitialized)
                        counter = value;
                    else
                        ThrowException();
                }
            }
        }

        public static class ChequingAccountID
        {
            private static string code = "CA";
            private static int counter = 0;

            internal static string Next()
            {
                counter++;
                return code + counter.ToString();
            }

            public static int Current
            {
                get 
                {
                    if (!bankDBInitialized)
                        ThrowException();

                    return counter; 
                }

                set
                {
                    if (!bankDBInitialized)
                        counter = value;
                    else
                        ThrowException();
                }
            }

            

        }

        public static class TFSAccountID
        {
            private static string code = "TFSA";
            private static int counter = 0;

            internal static string Next()
            {
                counter++;
                return code + counter.ToString();
            }

            public static int Current
            {
                get 
                {
                    if (!bankDBInitialized)
                        ThrowException();

                    return counter; 
                }

                set
                {
                    if (!bankDBInitialized)
                        counter = value;
                    else
                        ThrowException();
                }
            }
        }

        public static class LiabilityAccountID
        {
            private static string code = "LA";
            private static int counter = 0;

            internal static string Next()
            {
                counter++;
                return code + counter.ToString();
            }

            public static int Current
            {
                get 
                {
                    if (!bankDBInitialized)
                        ThrowException();

                    return counter; 
                }

                set
                {
                    if (!bankDBInitialized)
                        counter = value;
                    else
                        ThrowException();
                }
            }


        }

        public static class Logger
        {
            private static int activityCounter = 0;
           
            // Change path to suite user system. Don't hardcode
            private static string directoryPath =
                "C:\\Users\\" + Environment.UserName + "\\My Documents\\Aptean Edge Bank\\";

            internal static int NextActivity
            {
                get
                {
                    ++activityCounter;
                    return activityCounter;
                }
            }
            
            public static string DirectoryPath
            {
                get
                {
                    return directoryPath;
                }
            }

            public static int CurrentActivity
            {
                get 
                {
                    if (!bankDBInitialized)
                        ThrowException();

                    return activityCounter; 
                }

                set
                {
                    if (!bankDBInitialized)
                        activityCounter = value;
                    else
                        ThrowException();
                }
            }

        }

        private static void ThrowException()
        {
            string message = "Bank Initialization Error";
            throw new InvalidBankOperationException(message);
        }

        public static void Initialize(long bankBalance, long loanLimit,
                                            int customerIDCount, int chequingAccountIDCount,
                                            int tfsAccountIDCount, int liabilityAccountIDCount,
                                            int activityCount)
        {
            if (bankDBInitialized)
                return;
            else
            {
                BankBalance = bankBalance;
                LoanLimit = loanLimit;
                CustomerID.Current = customerIDCount;
                ChequingAccountID.Current = chequingAccountIDCount;
                TFSAccountID.Current = tfsAccountIDCount;
                LiabilityAccountID.Current = liabilityAccountIDCount;
                Logger.CurrentActivity = activityCount;

                bankDBInitialized = true;
                
                string dirPath = "C:\\Users\\" + Environment.UserName + "\\My Documents\\Aptean Edge Bank\\";

                System.IO.Directory.CreateDirectory(dirPath);
                
            }
        }

        public static List<Customer> customerList = new List<Customer>();
    }
}
 

