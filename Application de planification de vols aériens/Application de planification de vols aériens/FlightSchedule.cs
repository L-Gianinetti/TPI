using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class FlightSchedule
    {

        public bool IsPilotAtAssignmentAirport()
        {
            return true;
        }

        public bool HadPilotRestAfterFlight()
        {
            return true;
        }

        public bool HadPilotRestAtAssignmentAirport()
        {
            return true;
        }

        public bool IsPilotOnVacation()
        {
            return true;
        }

        public string AvailablePilots()
        {
            return string.Empty;
        }
    }
}
