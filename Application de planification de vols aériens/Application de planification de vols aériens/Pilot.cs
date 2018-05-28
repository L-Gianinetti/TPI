using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class Pilot
    {
        DBConnection dbConnection = new DBConnection();
        private string name;
        private string firstName;
        private int id;
        private int flightTime;
        private Airport assignmentAirport;
        string assignmentAirportName;

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

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public int FlightTime
        {
            get
            {
                return flightTime;
            }

            set
            {
                flightTime = value;
            }
        }

        public Airport AssignmentAirport
        {
            get
            {
                return assignmentAirport;
            }

            set
            {
                assignmentAirport = value;
            }
        }

        public string AssignmentAirportName
        {
            get
            {
                return assignmentAirportName;
            }

            set
            {
                assignmentAirportName = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }



        #endregion


        public Pilot(string name, string firstName, int flightTime, Airport assignmentAirport)
        {
            this.name = name;
            this.firstName = firstName;
            this.flightTime = flightTime;
            this.assignmentAirport = assignmentAirport;
        }
        public Pilot()
        {

        }

        //Test pour l'affichage pilotes
        public Pilot(int id, string name, string firstName, int flightTime, string assignmentAirportName)
        {
            this.name = name;
            this.firstName = firstName;
            this.flightTime = flightTime;
            this.AssignmentAirportName = assignmentAirportName;
            this.id = id;
        }


        public void UpdatePilotsCurrentLocation()
        {
            //List<string> to store all pilots' id
            List<string> pilotsId = new List<string>();
            pilotsId = dbConnection.GetPilotsId();
            //Foreach pilot updates his current location
            for (int i = 0; i < pilotsId.Count; i++)
            {
                int idPilot = int.Parse(pilotsId[i]);
                //Get idAirport from pilot last location
                int idAirport = dbConnection.GetPilotCurrentLocation(idPilot, DateTime.Now);

                if(idAirport == 0)
                {
                    idAirport = dbConnection.GetPilotAssignmentAirportId(idPilot);
                }
                //Update pilot current location
                dbConnection.UpdatePilotCurrentLocation(idPilot, idAirport);
            }
        }

        
    }
}
