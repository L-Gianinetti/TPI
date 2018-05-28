using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_de_planification_de_vols_aériens
{
    public partial class frmFlightAssignment : Form
    {
        DBConnection dbConnection = new DBConnection();
        private string flightName;
        private double flightTime;
        private int idFlight;
        Flight flight = new Flight();

        public frmFlightAssignment(string name)
        {
            InitializeComponent();
            this.flightName = name;
            this.idFlight = dbConnection.GetFlightId(this.flightName);
            flight = dbConnection.GetFlight(flightName);
        }

        public string FlightName
        {
            get
            {
                return flightName;
            }

            set
            {
                flightName = value;
            }
        }

        public double FlightTime
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //add the selectedPilot in lstPilotesDisponibles to lstPilotesAffectes
            if (lstAvailablePilots.SelectedIndex > -1)
            {
                lstAssignedPilots.Items.Add(lstAvailablePilots.SelectedItem);
                lstAvailablePilots.Items.Remove(lstAvailablePilots.SelectedItem);
            }
        }


        private void cmdPlan_Click(object sender, EventArgs e)
        {
            //For each assigned Pilots
            for (int i = 0; i < lstAssignedPilots.Items.Count; i++)
            {
                //Get pilot's id
                string infosPilot = lstAssignedPilots.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);

                //Add pilot to flight
                dbConnection.AddPilotToFlight(idPilot, idFlight);

                int idArrivalAirport = flight.getArrivalAirportId();
            }
        }

        private void frmAffectationVol_Load(object sender, EventArgs e)
        {
            //Get the flight distance to calculate flightTime
            int distance = dbConnection.GetLineDistance(flight.IdLine);
            FlightTime = flight.calculateFlightTime(distance);

            LoadAllPilotsInCurrentAirport();
            RemovePilotsNoRestAfterFlight();
            RemovePilotsInVacation();
            RemovePilotsWorking();
            RemovePilotsNoRestThisWeek();
            /*if(flightTime > 10)
            {

            }*/
        }

     

        /// <summary>
        /// Add pilots to lstPilotesDisponibles if their currentAirportLocation equals departureAirport
        /// </summary>
        private void LoadAllPilotsInCurrentAirport()
        {
            //Get departureAirportId
            int departureAirportId = flight.getDepartureAirportId();

            //Get pilots' id, name  firstname who are in departureAirport
            List<string> pilotsName = new List<string>();
            pilotsName = dbConnection.GetPilotsName(departureAirportId);
            List<string> pilotsFirstName = new List<string>();
            pilotsFirstName = dbConnection.GetPilotsFirstName(departureAirportId);
            List<string> pilotsId = new List<string>();
            pilotsId = dbConnection.GetPilotsId(departureAirportId);

            //ForEach pilot, build his display name 
            for (int i = 0; i < pilotsName.Count; i++)
            {
                string fullname = pilotsId[i] + ":" + pilotsName[i] + " " + pilotsFirstName[i];
                //add fullname to lstPilotesDisponibles
                lstAvailablePilots.Items.Add(fullname);
            }
        }


        /// <summary>
        /// Remove form lstPilotesDisponibles every pilot who hasn't rest from his last flight
        /// </summary>
        private void RemovePilotsNoRestAfterFlight()
        {
            for (int i = 0; i < lstAvailablePilots.Items.Count; i++)
            {
                string infosPilot = lstAvailablePilots.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);

                DateTime currentFlightDepartureDate = DateTime.Parse(flight.SDepartureDate);
                DateTime lastArrivalDate = dbConnection.GetPilotLastArrivalTime(idPilot, currentFlightDepartureDate);

                double hours = (currentFlightDepartureDate - lastArrivalDate).TotalHours;
                //If pilot hasn't rest 12 hours since his last flight, remove pilot form lstPilotesDisponibles
                if (hours < 12)
                {
                    lstAvailablePilots.Items.Remove(lstAvailablePilots.Items[i]);
                }
            }
        }

        private void RemovePilotsWorking()
        {
            for (int i = 0; i < lstAvailablePilots.Items.Count; i++)
            {
                string infosPilot = lstAvailablePilots.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);

                DateTime currentFlightDepartureDate = DateTime.Parse(flight.SDepartureDate);
                DateTime currentFlightArrivalDate = DateTime.Parse(flight.SArrivalDate);

                if (idPilot == dbConnection.GetIdPilotIfPilotIsWorking(currentFlightDepartureDate, currentFlightArrivalDate, idPilot))
                {
                    lstAvailablePilots.Items.Remove(lstAvailablePilots.Items[i]);
                }
            }
        }

        /// <summary>
        /// Remove pilots that are in vacation during flightDates from lstPilotsAvailable
        /// </summary>
        private void RemovePilotsInVacation()
        {
            for(int i = 0; i < lstAvailablePilots.Items.Count; i++)
            {
                //Get idPilot
                string infosPilot = lstAvailablePilots.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);

                //Build date in string for sql query
                DateTime currentFlightDepartureDate = DateTime.Parse(flight.SDepartureDate);
                DateTime currentFlightArrivalDate = DateTime.Parse(flight.SArrivalDate);
                string departureDate = BuildMySQLDate(currentFlightDepartureDate);
                string arrivalDate = BuildMySQLDate(currentFlightArrivalDate);

                //Get idPilot if pilot is in vacation
                int idPilotInVacation = dbConnection.GetIdPilotInVacationDuringFlight(departureDate, arrivalDate);
                
                //if Pilot is in vacation, removes him from lstAvailablePilots
                if(idPilot == idPilotInVacation)
                {
                    lstAvailablePilots.Items.Remove(lstAvailablePilots.Items[i]);
                }

            }
        }

        private void RemovePilotsNoRestThisWeek()
        {
            for(int i = 0; i < lstAvailablePilots.Items.Count; i++)
            {
                //Get idPilot
                string infosPilot = lstAvailablePilots.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);

                DateTime currentFlightDepartureDate = DateTime.Parse(flight.SDepartureDate);
                DateTime currentFlightArrivalDate = DateTime.Parse(flight.SArrivalDate);


                DateTime monday = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                DateTime sunday = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                if(monday.DayOfYear > sunday.DayOfYear)
                {
                    sunday = sunday.AddDays(7);
                }
                string sMonday = BuildMySQLDate(monday);
                string sSunday = BuildMySQLDate(sunday);

                List<DateTime> startWork = new List<DateTime>();
                List<DateTime> endWork = new List<DateTime>();

                startWork = dbConnection.GetPilotStartWorkDatesThisWeek(sMonday, sSunday);
                endWork = dbConnection.GetPilotEndWorkDatesThisWeek(sMonday, sSunday);

                bool bMonday = false;
                bool bTuesday = false;
                bool bWednesday = false;
                bool bThursday = false;
                bool bFriday = false;
                bool bSaturday = false;
                bool bSunday = false;



                double workDays = 0;

                for(int y = 0; y < startWork.Count; y++)
                {
                    if(startWork[y].DayOfWeek == DayOfWeek.Monday)
                    {
                         bMonday = true;
                    }
                    else if(startWork[y].DayOfWeek == DayOfWeek.Tuesday)
                    {
                        bTuesday = true;
                    }
                    else if (startWork[y].DayOfWeek == DayOfWeek.Wednesday)
                    {
                        bWednesday = true;
                    }
                    else if (startWork[y].DayOfWeek == DayOfWeek.Thursday)
                    {
                        bThursday = true;
                    }
                    else if (startWork[y].DayOfWeek == DayOfWeek.Friday)
                    {
                        bFriday = true;
                    }
                    else if (startWork[y].DayOfWeek == DayOfWeek.Saturday)
                    {
                        bSaturday = true;
                    }
                    else if (startWork[y].DayOfWeek == DayOfWeek.Sunday)
                    {
                        bSunday = true;
                    }
                }
                for(int z=0; z < endWork.Count; z++)
                {
                    if (startWork[z].DayOfWeek == DayOfWeek.Monday)
                    {
                        bMonday = true;
                    }
                    else if (startWork[z].DayOfWeek == DayOfWeek.Tuesday)
                    {
                        bTuesday = true;
                    }
                    else if (startWork[z].DayOfWeek == DayOfWeek.Wednesday)
                    {
                        bWednesday = true;
                    }
                    else if (startWork[z].DayOfWeek == DayOfWeek.Thursday)
                    {
                        bThursday = true;
                    }
                    else if (startWork[z].DayOfWeek == DayOfWeek.Friday)
                    {
                        bFriday = true;
                    }
                    else if (startWork[z].DayOfWeek == DayOfWeek.Saturday)
                    {
                        bSaturday = true;
                    }
                    else if (startWork[z].DayOfWeek == DayOfWeek.Sunday)
                    {
                        bSunday = true;
                    }
                }

                bool pilotHasRest = HasPilotRest(bMonday, bTuesday, bWednesday, bThursday, bFriday, bSaturday, bSunday);
                if (!pilotHasRest)
                {

                }

            }
        }

        private string BuildMySQLDate(DateTime input)
        {
            int year = input.Year;
            int month = input.Month;
            int day = input.Day;
            string sMonth = month.ToString();
            string sDay = day.ToString();
            if(month < 10)
            {
                sMonth = "0" + sMonth;
            }
            if(day < 10)
            {
                sDay = "0" + sDay;
            }

            string output = year + "-" + sMonth + "-" + sDay;
            return output;
        }

        /// <summary>
        /// Si il le pilote n'a pas eu d'activité pendant 2 jours consécutif retourne true
        /// </summary>
        /// <param name="monday"></param>
        /// <param name="tuesday"></param>
        /// <param name="wednesday"></param>
        /// <param name="thursday"></param>
        /// <param name="friday"></param>
        /// <param name="saturday"></param>
        /// <param name="sunday"></param>
        /// <returns></returns>
        private bool HasPilotRest(bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday)
        {
            bool output = false;
            if(monday == false && tuesday == false || tuesday == false && wednesday == false || wednesday == false && thursday == false || thursday == false && friday == false || friday == false && saturday == false || saturday == false && sunday == false)
            {
                output = true;
            }
            return output;
        }

    }
}
