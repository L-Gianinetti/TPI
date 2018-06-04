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
        //used to build MySQLDate format
        BuildMySQLDate buildMySQLDate = new BuildMySQLDate();
        private string name;
        private string firstName;
        private int id;
        private float flightTime;
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

        public float FlightTime
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


        public Pilot(string name, string firstName, float flightTime, Airport assignmentAirport)
        {
            this.name = name;
            this.firstName = firstName;
            this.flightTime = flightTime;
            this.assignmentAirport = assignmentAirport;
        }
        public Pilot()
        {

        }

        //Used for pilot's display
        public Pilot(int id, string name, string firstName, float flightTime, string assignmentAirportName)
        {
            this.name = name;
            this.firstName = firstName;
            this.flightTime = flightTime;
            this.AssignmentAirportName = assignmentAirportName;
            this.id = id;
        }

        /// <summary>
        /// Add flights' time to pilot's flightTime for the flights he did between application's last closed date and now
        /// </summary>
        /// <param name="lastOpenedDate"></param>
        public void UpdatePilotsFlightTime(DateTime lastClosedDate)
        {
            //List<string> to store all pilots' id
            List<string> pilotsId = new List<string>();
            pilotsId = dbConnection.GetPilotsId();
            //Foreach pilot
            for(int i = 0; i < pilotsId.Count; i++)
            {
                //Get current pilot's flightTIme
                float currentPilotFlightTime = dbConnection.GetPilotFlightTime(int.Parse(pilotsId[i]));
                //Build last application's closed date in MySQLDate format
                string closedDate = buildMySQLDate.BuildDate(lastClosedDate);
                
                //Build current date in MySQLDate format
                string currentDate = buildMySQLDate.BuildDate(DateTime.Now);
                
                //Get the flight's distances
                List<string> distances = dbConnection.GetDistanceFromFlight(int.Parse(pilotsId[i]), closedDate, currentDate);
                //For each flight calculate flightTime
                for(int y = 0; y < distances.Count; y++)
                {
                    float distance = float.Parse(distances[y]);
                    float flightSpeed = 900;
                    // add flightTime for the current flight to pilot's flightTime
                    currentPilotFlightTime += (distance / flightSpeed);
                }
                //update Pilot's flight time in DB
                dbConnection.UpdatePilotFlightTime(int.Parse(pilotsId[i]), currentPilotFlightTime);
            }
            

        }

        /// <summary>
        /// Update pilots current location in db
        /// </summary>
        public void UpdatePilotsCurrentLocation()
        {
            DateTime date = DateTime.Now;
            //Build current time in MySQLDate format
            string sDate = buildMySQLDate.BuildDate(date);
            //List<string> to store all pilots' id
            List<string> pilotsId = new List<string>();
            pilotsId = dbConnection.GetPilotsId();
            //Foreach pilot updates his current location
            for (int i = 0; i < pilotsId.Count; i++)
            {
                int idPilot = int.Parse(pilotsId[i]);
                //Get idAirport from pilot last location
                int idAirport = dbConnection.GetPilotCurrentLocation(idPilot, sDate);

                //If idAirport = 0, it means that pilot hasn't work yet and he's in his assignmentAirport
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
