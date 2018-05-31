using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class BuildMySQLDate
    {
        public BuildMySQLDate()
        {
        }

        /// <summary>
        /// Build a date into MySQLDate format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string BuildDate(DateTime input)
        {
            int year = input.Year;
            int month = input.Month;
            int day = input.Day;
            int hour = input.Hour;
            int min = input.Minute;
            string sMonth = month.ToString();
            string sDay = day.ToString();
            string sHour = hour.ToString();
            string sMin = min.ToString();
            if (month < 10)
            {
                sMonth = "0" + sMonth;
            }
            if (day < 10)
            {
                sDay = "0" + sDay;
            }
            if(hour < 10)
            {
                sHour = "0" + sHour;
            }
            if(min < 10)
            {
                sMin = "0" + sMin;
            }

            string output = year + "-" + sMonth + "-" + sDay +" " + sHour + ":" + sMin + ":00";
            return output;
        }
    }
}
