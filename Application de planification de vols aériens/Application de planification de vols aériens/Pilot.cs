﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens
{
    public class Pilot
    {
        DBConnection dbConnection = new DBConnection();
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

        //Test pour l'affichage pilotes
        public Pilot(int id, string name, string firstName, float flightTime, string assignmentAirportName)
        {
            this.name = name;
            this.firstName = firstName;
            this.flightTime = flightTime;
            this.AssignmentAirportName = assignmentAirportName;
            this.id = id;
        }

        public void UpdatePilotsFlightTime(DateTime lastOpenedDate)
        {
            //TODO FINIR CA SI POSSIBLE MAIS PAS TROP PERDRE DE TEMPS
            //List<string> to store all pilots' id
            List<string> pilotsId = new List<string>();
            pilotsId = dbConnection.GetPilotsId();
            //Foreach pilot
            for(int i = 0; i < pilotsId.Count; i++)
            {
                float currentPilotFlightTime = dbConnection.GetPilotFlightTime(int.Parse(pilotsId[i]));
                string closedDate = buildMySQLDate.BuildDate(lastOpenedDate);
                
                string currentDate = buildMySQLDate.BuildDate(DateTime.Now);
                
                
                List<string> distances = dbConnection.GetDistanceFromFlight(int.Parse(pilotsId[i]), closedDate, currentDate);
                for(int y = 0; y < distances.Count; y++)
                {
                    float distance = float.Parse(distances[y]);
                    float flightSpeed = 900;
                    currentPilotFlightTime += (distance / flightSpeed);
                }
                dbConnection.UpdatePilotFlightTime(int.Parse(pilotsId[i]), currentPilotFlightTime);
            }
            

        }

        
        public void UpdatePilotsCurrentLocation()
        {
            DateTime date = DateTime.Now;
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
