using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBankAPI
{
    public static class Utility
    {
        public static string getCurrentDate()
        {

            DateTime date = DateTime.Now;
            string day = date.Day.ToString();
            if (date.Day < 10)
                day = "0" + day;

            string month = date.Month.ToString();
            if (date.Month < 10)
                month = "0" + month;

            string year = date.Year.ToString();

            string dateFormat = day + "/" + month + "/" + year;

            return dateFormat;
        }
    }
}
