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
        private double flightTimeM;
        private double flightTimeH;
        private int idLine;
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

        public double FlightTimeM
        {
            get
            {
                return flightTimeM;
            }

            set
            {
                flightTimeM = value;
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


        public Flight(string name, DateTime departureDate,Line flightLine)
        {
            this.name = name;
            this.departureDate = departureDate;
            this.flightLine = flightLine;
            /*
            FlightTimeM = (flightLine.Distance / airplaneSpeed)*60;
            FlightTimeH = (FlightTimeM - (FlightTimeM % 60)) / 60;
            FlightTimeM = FlightTimeM - (FlightTimeH * 60);*/
            flightTimeH = (this.flightLine.Distance / airplaneSpeed);
            
            arrivalDate = departureDate.AddHours(flightTimeH);
            //arrivalDate = arrivalDate.AddMinutes(FlightTimeM);

        }

        public Flight(int idFlight,string name, string departureDate, string arrivalDate, int idLine)
        {
            this.idFlight = idFlight;
            this.name = name;
            this.SDepartureDate = departureDate;
            this.SArrivalDate = arrivalDate;
            this.idLine = idLine;

            //this.lineName = dbConnection.GetLineName(idLine);
        }
    }
}
