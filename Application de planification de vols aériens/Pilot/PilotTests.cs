using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application_de_planification_de_vols_aériens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens.Tests
{
    [TestClass()]
    public class PilotTests
    {
        [TestMethod()]
        public void UpdatePilotsCurrentLocationTest()
        {
            int idPilot = 9;
            int idActualAirport = 10;
            int idAirportAttendu;

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            string sMonth = string.Empty;
            string sDay = string.Empty;
            string sHour = string.Empty;
            string sMin = string.Empty;
            string sSec = string.Empty;
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            if (month < 10)
            {
                sMonth = "0" + month;
            }
            else
            {
                sMonth = month.ToString();
            }
            if (day < 10)
            {
                sDay = "0" + day;
            }
            else
            {
                sDay = day.ToString();
            }
            if (hour < 10)
            {
                sHour = "0" + hour;
            }
            else
            {
                sHour = hour.ToString();
            }
            if (min < 10)
            {
                sMin = "0" + min;
            }
            else
            {
                sMin = min.ToString();
            }
            if (sec < 10)
            {
                sSec = "0" + sec;
            }
            else
            {
                sSec = sec.ToString();
            }

            string date = year + "-" + sMonth + "-" + sDay + " " + hour + ":" + min + ":" + sec;



        }
    }
}