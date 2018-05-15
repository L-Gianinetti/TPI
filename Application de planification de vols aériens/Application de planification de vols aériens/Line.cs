using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class Line
    {
        private Airport departureAirport;
        private Airport arrivalAirport;
        private string distance;

        #region accessors
        internal Airport DepartureAirport
        {
            get
            {
                return departureAirport;
            }

            set
            {
                departureAirport = value;
            }
        }

        internal Airport ArrivalAirport
        {
            get
            {
                return arrivalAirport;
            }

            set
            {
                arrivalAirport = value;
            }
        }

        public string Distance
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

        public Line(Airport departureAirport, Airport arrivalAirport, string distance)
        {

        }
    }
}
