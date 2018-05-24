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
        private bool pilotHasRest;
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

        public bool PilotHasRest
        {
            get
            {
                return pilotHasRest;
            }

            set
            {
                pilotHasRest = value;
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
        public Pilot(int id,string name, string firstName, int flightTime, string assignmentAirportName)
        {
            this.name = name;
            this.firstName = firstName;
            this.flightTime = flightTime;
            this.AssignmentAirportName = assignmentAirportName;
            this.id = id;
        }

        public void updatePilotsCurrentLocation()
        {
            List<string> pilotsId = new List<string>();
            pilotsId = dbConnection.GetPilotsId();
            for (int i = 0; i < pilotsId.Count; i++)
            {
                int idPilot = int.Parse(pilotsId[i]);
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                string sMonth = string.Empty;
                string sDay = string.Empty;
                string sHour = string.Empty;
                string sMin = string.Empty;
                string sSec = string.Empty;
                int hour = DateTime.Now.Hour;
                int min = DateTime.Now.Minute;
                int sec = DateTime.Now.Second;
                if(month < 10)
                {
                    sMonth = "0" + month;
                }
                else
                {
                    sMonth = month.ToString();
                }
                if(day < 10)
                {
                    sDay = "0" + day;
                }
                else
                {
                    sDay = day.ToString();
                }
                if (hour < 10)
                {
                    sHour = "0" + hour;
                }
                else
                {
                    sHour = hour.ToString();
                }
                if (min < 10)
                {
                    sMin = "0" + min;
                }
                else
                {
                    sMin = min.ToString();
                }
                if (sec < 10)
                {
                    sSec = "0" + sec;
                }
                else
                {
                    sSec = sec.ToString();
                }

                string date =   year + "-" + sMonth + "-" + sDay + " " + hour + ":" + min + ":" + sec ;
                //date = "\"" + date + "\"";

                int idAirport = dbConnection.GetPilotCurrentLocation(idPilot, date);
                if(idAirport != 0)
                {
                    dbConnection.UpdatePilotCurrentLocation(idPilot, idAirport);
                }
                
            }
        }

        public bool HasPilotRestThisWeek(int idPilot)
        {
            this.id = idPilot;
            bool output = false;
            bool monday = false;
            bool tuesday = false;
            bool wednesday = false;
            bool thursday = false;
            bool friday = false;
            bool saturday = false;
            bool sunday = false;
            int restDays = 0;
            DateTime _monday = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime _sunday = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            List<DateTime> startTime = new List<DateTime>();
            List<DateTime> endTime = new List<DateTime>();
            startTime = dbConnection.GetPilotWorkStartTimeThisWeek(this.id, _monday, _sunday);
            endTime = dbConnection.GetPilotWorkEndTimeThisWeek(this.id, _monday, _sunday);
            startTime.ForEach(delegate (DateTime date)
            {
                if (date.DayOfWeek == DayOfWeek.Monday && monday == false)
                {
                    monday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Thursday && thursday == false)
                {
                    thursday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Wednesday && wednesday == false)
                {
                    wednesday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Tuesday && tuesday == false)
                {
                    tuesday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Friday && friday == false)
                {
                    friday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Saturday && saturday == false)
                {
                    saturday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Sunday && sunday == false)
                {
                    sunday = true;
                    restDays += 1;
                }
            });
            endTime.ForEach(delegate (DateTime date)
            {
                if (date.DayOfWeek == DayOfWeek.Monday && monday == false)
                {
                    monday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Thursday && thursday == false)
                {
                    thursday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Wednesday && wednesday == false)
                {
                    wednesday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Tuesday && tuesday == false)
                {
                    tuesday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Friday && friday == false)
                {
                    friday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Saturday && saturday == false)
                {
                    saturday = true;
                    restDays += 1;
                }
                else if (date.DayOfWeek == DayOfWeek.Sunday && sunday == false)
                {
                    sunday = true;
                    restDays += 1;
                }
            });

            if(restDays >= 2)
            {
                output = true;
            }
            return output;
        }
    }
}
