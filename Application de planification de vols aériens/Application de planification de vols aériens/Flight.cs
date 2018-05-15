using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class Flight
    {
        private string name;
        private DateTime departureDate;
        private DateTime arrivalDate;
        private Line flightLine;

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
        #endregion

        public Airport Airport
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Line Line
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public FlightSchedule FlightSchedule
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Flight(string name, DateTime departureDate, DateTime arrivalDate, Line flightLine)
        {

        }

    }
}
