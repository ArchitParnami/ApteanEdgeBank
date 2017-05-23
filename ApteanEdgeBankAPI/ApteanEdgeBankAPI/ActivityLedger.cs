using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
    internal static class ActivityLedger
    {
        public static void LogDeposit(double amount, string accountID)
        {
            int activityNo = Bank.Logger.NextActivity;
            string drPath = Bank.Logger.DirectoryPath;
            string filePath = drPath + accountID + ".txt";

            string dateTime = DateTime.Now.ToString();

            const string format = "{0,-10}{1,-30}{2,-10}{3,-2}{4,-10}";
            string log = string.Format(format,
                                "[" + activityNo + "]", 
                                dateTime, 
                                accountID, 
                                "+", 
                                amount);
            log = log + Environment.NewLine;

            File.AppendAllText(filePath, log);
        }

        public static void LogWithdrawl(double amount, string accountID)
        {
            int activityNo = Bank.Logger.NextActivity;
            string drPath = Bank.Logger.DirectoryPath;
            string filePath = drPath + accountID + ".txt";

            string dateTime = DateTime.Now.ToString();

            const string format = "{0,-10}{1,-30}{2,-10}{3,-2}{4,-10}";
            string log = string.Format(format,
                                "[" + activityNo + "]",
                                dateTime,
                                accountID,
                                "-",
                                amount);
            log = log + Environment.NewLine;
            File.AppendAllText(filePath, log);
        }
    }
}
