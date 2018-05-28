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
        private string sDepartureDate;
        private string sArrivalDate;
        private DateTime departureDate;
        private DateTime arrivalDate;
        private Line flightLine;
        private double flightTimeH;
        private int idLine;
        //Average speed for an airplane
        private int airplaneSpeed = 900;
        private string lineName = string.Empty;

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

        public Line FlightLine
        {
            get
            {
                return flightLine;
            }

            set
            {
                flightLine = value;
            }
        }



        public double FlightTimeH
        {
            get
            {
                return flightTimeH;
            }

            set
            {
                flightTimeH = value;
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

        public string LineName
        {
            get
            {
                return lineName;
            }

            set
            {
                lineName = value;
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
            arrivalDate = departureDate.AddHours(flightTimeH);
        }

        public Flight(int idFlight, string name, string departureDate, string arrivalDate, int idLine)
        {
            this.idFlight = idFlight;
            this.name = name;
            this.sDepartureDate = departureDate;
            this.sArrivalDate = arrivalDate;
            this.idLine = idLine;
        }

        //Return the flightTime in hours
        public double calculateFlightTime(int distance)
        {
            flightTimeH = distance / airplaneSpeed;
            return flightTimeH;
        }

        public int getDepartureAirportId()
        {
            string acronym = name.Substring(0, 3);
            int airportId = dbConnection.GetAirportId(acronym);
            return airportId;
        }

        public int getArrivalAirportId()
        {
            string acronym = name.Substring(3, 3);
            int airportId = dbConnection.GetAirportId(acronym);
            return airportId;
        }
    }
}
