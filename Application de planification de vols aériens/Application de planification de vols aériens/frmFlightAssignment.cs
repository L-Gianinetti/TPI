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
        BuildMySQLDate buildMySQLDate = new BuildMySQLDate();
        private string flightName;
        private float flightTime;
        private int idFlight;
        Flight flight = new Flight();

        /// <summary>
        /// Constructor that create a flight object with the selected flight's name
        /// </summary>
        /// <param name="name"></param>
        public frmFlightAssignment(string name)
        {
            InitializeComponent();
            this.flightName = name;
            this.idFlight = dbConnection.GetFlightId(this.flightName);
            flight = dbConnection.GetFlight(flightName);
        }

        private void frmFlightAssignment_Load(object sender, EventArgs e)
        {
            cmdAdd.Enabled = false;
            cmdPlan.Enabled = false;
            //Get the flight distance to calculate flightTime
            int distance = dbConnection.GetLineDistance(flight.IdLine);
            flightTime = flight.calculateFlightTime(distance);

            LoadAllPilotsInCurrentAirport();
            RemovePilotsNoRestAfterFlight();
            RemovePilotsInVacation();
            RemovePilotsWorking();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //Get the distance of the flight
            int distance = dbConnection.GetLineDistance(flight.IdLine);
            flightTime = flight.calculateFlightTime(distance);
            //add the selectedPilot in lstPilotesDisponibles to lstPilotesAffectes
            if (lstAvailablePilots.SelectedIndex > -1)
            {
                lstAssignedPilots.Items.Add(lstAvailablePilots.SelectedItem);
                lstAvailablePilots.Items.Remove(lstAvailablePilots.SelectedItem);
            }
            //if flightTime <=10 only 1 pilot can be assigned
            if(flightTime <= 10 && lstAssignedPilots.Items.Count == 1)
            {
                cmdAdd.Enabled = false;
            }
            //if flightTime > 10 only 2 pilots can be assigned
            if(flightTime > 10 && lstAssignedPilots.Items.Count == 2)
            {
                cmdAdd.Enabled = false;
            }
        }


        public void cmdPlan_Click(object sender, EventArgs e)
        {
            //Get flight's distance to calculate flightTIme
            int distance = dbConnection.GetLineDistance(flight.IdLine);
            flightTime = flight.calculateFlightTime(distance);
            // flightTime > 10, 2 pilots have to be assigned
            if (flightTime > 10 && lstAssignedPilots.Items.Count != 2)
            {
                MessageBox.Show("Le vol dure plus de 10h, il faut assigner un second pilote à ce vol");
            }
            else
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
                }
                DialogResult res = MessageBox.Show("Le(s) pilote(s) a/ont bien été affecté(s) au vol", "", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }     

        /// <summary>
        /// Add pilots to lstPilotesDisponibles if their currentAirportLocation equals departureAirport
        /// </summary>
        private void LoadAllPilotsInCurrentAirport()
        {
            //Get departureAirportId
            int departureAirportId = flight.getDepartureAirportId();

            //Get pilots' id, name  firstname who are in departureAirport
            List<string> pilotsId = new List<string>();
            pilotsId = dbConnection.GetPilotsId();

            //Build a string that contain flight's departureDate in MySQLDate format
            string sDepartureDate = flight.SDepartureDate;
            int year = int.Parse(sDepartureDate.Substring(6, 4));
            int month = int.Parse(sDepartureDate.Substring(3,2));
            int day = int.Parse(sDepartureDate.Substring(0,2));
            int hour= int.Parse(sDepartureDate.Substring(11,2));
            int min = int.Parse(sDepartureDate.Substring(14,2));
            DateTime departureDate = new DateTime(year, month, day, hour, min, 0);
            string inputDepartureDate = buildMySQLDate.BuildDate(departureDate);

            //ForEach pilot, build his display name 
            for (int i = 0; i < pilotsId.Count; i++)
            {
                //Get pilot's location
                int idCurrentAirport = dbConnection.GetPilotCurrentLocation(int.Parse(pilotsId[i]), inputDepartureDate);     
                //if idCurrentAirport == 0, that means pilot's hasn't flight yet so his idCurrentAirport = idAssignmentAirport           
                if(idCurrentAirport == 0)
                {
                    idCurrentAirport = dbConnection.GetPilotAssignmentAirportId(int.Parse(pilotsId[i]));
                }
                //If the pilot is in the same airport than the plane
                if(idCurrentAirport == departureAirportId)
                {
                    //build pilot's fullname
                    string pilotName = dbConnection.GetPilotName(int.Parse(pilotsId[i]));
                    string pilotFirstName = dbConnection.GetPilotFirstName(int.Parse(pilotsId[i]));
                    string fullname = pilotsId[i] + ":" + pilotName+ " " + pilotFirstName;
                    //add fullname to lstPilotesDisponibles
                    lstAvailablePilots.Items.Add(fullname);
                }
            }
        }


        /// <summary>
        /// Remove form lstPilotesDisponibles every pilot who hasn't rest from his last flight
        /// </summary>
        private void RemovePilotsNoRestAfterFlight()
        {
            //foreach pilot in lstAvailablePilots
            for (int i = 0; i < lstAvailablePilots.Items.Count; i++)
            {
                //Get pilot's id
                string infosPilot = lstAvailablePilots.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);

                //Date that contains flight's departureDate
                DateTime currentFlightDepartureDate = DateTime.Parse(flight.SDepartureDate);
                //Date that contains pilot's flightLastArrivalDate befor flight's departureDate
                DateTime lastArrivalDate = dbConnection.GetPilotLastArrivalTime(idPilot, currentFlightDepartureDate);

                //Calculate numbers of hours between 2 dates
                double hours = (currentFlightDepartureDate - lastArrivalDate).TotalHours;
                //If pilot hasn't rest 12 hours since his last flight, remove pilot form lstPilotesDisponibles
                if (hours < 12)
                {
                    lstAvailablePilots.Items.Remove(lstAvailablePilots.Items[i]);
                }
            }
        }

        /// <summary>
        /// Remove pilots who are working during flight's date
        /// </summary>
        private void RemovePilotsWorking()
        {
            //foreach pilot in lstAvailablePilots
            for (int i = 0; i < lstAvailablePilots.Items.Count; i++)
            {
                //Get pilot's id
                string infosPilot = lstAvailablePilots.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);

                DateTime currentFlightDepartureDate = DateTime.Parse(flight.SDepartureDate);
                DateTime currentFlightArrivalDate = DateTime.Parse(flight.SArrivalDate);

                //If the pilot is working between currentFLightDepartureDate and currentFlightArrivalDate, pilot is removed from lstAvailablePilots
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
            //foreach pilots in lstAvailablePilots
            for(int i = 0; i < lstAvailablePilots.Items.Count; i++)
            {
                //Get idPilot
                string infosPilot = lstAvailablePilots.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);

                //Build date in string for sql query
                DateTime currentFlightDepartureDate = DateTime.Parse(flight.SDepartureDate);
                DateTime currentFlightArrivalDate = DateTime.Parse(flight.SArrivalDate);
                string departureDate = buildMySQLDate.BuildDate(currentFlightDepartureDate);
                string arrivalDate = buildMySQLDate.BuildDate(currentFlightArrivalDate);

                //Get idPilot if pilot is in vacation
                int idPilotInVacation = dbConnection.GetIdPilotInVacationDuringFlight(departureDate, arrivalDate);
                
                //if Pilot is in vacation, removes him from lstAvailablePilots
                if(idPilot == idPilotInVacation)
                {
                    lstAvailablePilots.Items.Remove(lstAvailablePilots.Items[i]);
                }
            }
        }

        #region unfinished Methods

        /*
        /// <summary>
        /// Remove pilots from lstAvailablePilots if pilot hasn't rest this week
        /// </summary>
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
                string sMonday = buildMySQLDate.BuildDate(monday);
                string sSunday = buildMySQLDate.BuildDate(sunday);

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



                //double workDays = 0;

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
        }*/
        #endregion

        private void lstAvailablePilots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstAvailablePilots.SelectedIndex != -1)
            {
                cmdAdd.Enabled = true;
            }
            else
            {
                cmdAdd.Enabled = false;
            }
        }

        private void lstAssignedPilots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstAssignedPilots.Items.Count >= 1)
            {
                cmdPlan.Enabled = true;
            }
            else
            {
                cmdPlan.Enabled = false;
            }
        }
    }
}
