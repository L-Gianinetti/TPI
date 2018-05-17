using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class Line
    {
        private int idDepartureAirport;
        private int idArrivalAirport;
        private int distance;

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
        #endregion


        public Line(int idDepartureAirport, int idArrivalAirport, int distance)
        {
            this.IdArrivalAirport = idArrivalAirport;
            this.IdDepartureAirport = idDepartureAirport;
            this.distance = distance;
        }
    }
}
