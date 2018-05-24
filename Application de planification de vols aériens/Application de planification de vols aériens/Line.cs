using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class Line
    {
        DBConnection dbConnection = new DBConnection();
        private int idDepartureAirport;
        private int idArrivalAirport;
        private int distance;
        private string arrivalAirportName;
        private string departureAirportName;
        private int idLine;
        #region accessors


        public int Distance
        {
            get
            {
                return distance;
            }

            set
            {
                distance = value;
            }
        }

        public int IdDepartureAirport
        {
            get
            {
                return idDepartureAirport;
            }

            set
            {
                idDepartureAirport = value;
            }
        }

        public int IdArrivalAirport
        {
            get
            {
                return idArrivalAirport;
            }

            set
            {
                idArrivalAirport = value;
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

        public string ArrivalAirportName
        {
            get
            {
                return arrivalAirportName;
            }

            set
            {
                arrivalAirportName = value;
            }
        }

        public string DepartureAirportName
        {
            get
            {
                return departureAirportName;
            }

            set
            {
                departureAirportName = value;
            }
        }
        #endregion


        public Line(int idDepartureAirport, int idArrivalAirport, int distance)
        {
            this.idArrivalAirport = idArrivalAirport;
            this.idDepartureAirport = idDepartureAirport;
            this.distance = distance;
        }

        public Line(int idLine, int distance,int idDepartureAirport, int idArrivalAirport)
        {
            this.idArrivalAirport = idArrivalAirport;
            this.idDepartureAirport = idDepartureAirport;
            this.distance = distance;
            this.idLine = idLine;
        }
    }
}
