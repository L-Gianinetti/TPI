using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public static class DateTimeExtensions
    {
        //Used to create a DateTime with a specific day of the current week
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        //Get the numbers of days left in current week
        public  static int GetDaysLeftInCurrentWeek()
        {
            int i = 0;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                i = 7;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                i = 6;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                i = 5;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                i = 4;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                i = 3;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                i = 2;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                i = 1;
            }
            return i;
        }
    }
}
