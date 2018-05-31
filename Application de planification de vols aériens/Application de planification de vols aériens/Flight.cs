using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class Flight
    {
        DBConnection dbConnection = new DBConnection();
        private string name;
        private int idFlight;
        //String to store departureDate in MySQLDate format
        private string sDepartureDate;
        //String to store arrivalDate in MySQLDate format
        private string sArrivalDate;
        private DateTime departureDate;
        private DateTime arrivalDate;
        private Line flightLine;
        //flightTime in hours
        private float flightTimeH;
        private int idLine;
        //Average speed for an airplane
        private float airplaneSpeed = 900;

        #region accessors
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public DateTime DepartureDate
        {
            get
            {
                return departureDate;
            }

            set
            {
                departureDate = value;
            }
        }

        public DateTime ArrivalDate
        {
            get
            {
                return arrivalDate;
            }

            set
            {
                arrivalDate = value;
            }
        }


        public int IdLine
        {
            get
            {
                return idLine;
            }

            set
            {
                idLine = value;
            }
        }

        public string SDepartureDate
        {
            get
            {
                return sDepartureDate;
            }

            set
            {
                sDepartureDate = value;
            }
        }

        public string SArrivalDate
        {
            get
            {
                return sArrivalDate;
            }

            set
            {
                sArrivalDate = value;
            }
        }

        public int IdFlight
        {
            get
            {
                return idFlight;
            }

            set
            {
                idFlight = value;
            }
        }
        #endregion

        public Flight()
        {

        }

        public Flight(string name, DateTime departureDate, Line flightLine)
        {
            this.name = name;
            this.departureDate = departureDate;
            this.flightLine = flightLine;
            flightTimeH = calculateFlightTime(this.flightLine.Distance);
            //flightTimeinMinutes
            double flightTimeM = flightTimeH * 60;
            //Add flightTimeMinutes to departureDate to get arrivalDate
            arrivalDate = departureDate.AddMinutes(flightTimeM);
        }

        public Flight(int idFlight, string name, string departureDate, string arrivalDate, int idLine)
        {
            this.idFlight = idFlight;
            this.name = name;
            this.sDepartureDate = departureDate;
            this.sArrivalDate = arrivalDate;
            this.idLine = idLine;
        }

        /// <summary>
        /// Return the flightTime in hours
        /// </summary>
        /// <param name="distance">flight's distance</param>
        /// <returns></returns>
        public float calculateFlightTime(float distance)
        {
            flightTimeH = distance / airplaneSpeed;
            return flightTimeH;
        }

        /// <summary>
        /// Return departureAirport's id
        /// </summary>
        /// <returns></returns>
        public int getDepartureAirportId()
        {
            //Get the airport's acronym from airport's name
            string acronym = name.Substring(0, 3);
            int airportId = dbConnection.GetAirportId(acronym);
            return airportId;
        }

        /// <summary>
        /// Return arrivalAirport's id
        /// </summary>
        /// <returns></returns>
        public int getArrivalAirportId()
        {
            string acronym = name.Substring(3, 3);
            int airportId = dbConnection.GetAirportId(acronym);
            return airportId;
        }
    }
}
