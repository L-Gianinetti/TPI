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
    public partial class frmAffectationVol : Form
    {
        DBConnection dbConnection = new DBConnection();
        private string flightName;
        private int idFlight;
        Flight flight = new Flight();
        
        public frmAffectationVol(string name)
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


        private void cmdAjouter_Click(object sender, EventArgs e)
        {
            if(lstPilotesDisponibles.SelectedIndex > -1)
            {
                lstPilotesAffectes.Items.Add(lstPilotesDisponibles.SelectedItem);
            }
        }

        private void cmdPlanifier_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < lstPilotesAffectes.Items.Count; i++)
            {
                string infosPilot = lstPilotesAffectes.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);
                dbConnection.AddPilotToFlight(idPilot, idFlight);
            }
        }

        private void frmAffectationVol_Load(object sender, EventArgs e)
        {
            int distance = dbConnection.GetLineDistance(flight.IdLine);
            double flightTime = flight.calculateFlightTime(distance);

            LoadAllPilotsInCurrentAirport();
            RemovePilotsNoRestAfterFlight();


            /*if(flightTime > 10)
            {

            }*/
        }

        private void LoadAllPilotsInCurrentAirport()
        {
            int departureAirportId = flight.getDepartureAirportId();
            List<string> pilotsName = new List<string>();
            pilotsName = dbConnection.GetPilotsName(departureAirportId);
            List<string> pilotsFirstName = new List<string>();
            pilotsFirstName = dbConnection.GetPilotsFirstName(departureAirportId);
            List<string> pilotsId = new List<string>();
            pilotsId = dbConnection.GetPilotsId(departureAirportId);
            for (int i = 0; i < pilotsName.Count; i++)
            {
                string fullname = pilotsId[i] + ":" + pilotsName[i] + " " + pilotsFirstName[i];
                lstPilotesDisponibles.Items.Add(fullname);
            }
        }

        private void RemovePilotsNoRestAfterFlight()
        {
            for(int i = 0; i < lstPilotesDisponibles.Items.Count; i++)
            {
                string infosPilot = lstPilotesDisponibles.Items[i].ToString();
                string[] infoPilot = infosPilot.Split(':');
                int idPilot = int.Parse(infoPilot[0]);
                DateTime lastArrivalDate = dbConnection.GetPilotLastArrivalTime(idPilot);

                double hours = (DateTime.Now - lastArrivalDate).TotalHours;
                if(hours < 12)
                {
                    lstPilotesAffectes.Items.Remove(lstPilotesDisponibles.Items[i]);
                }


            }
        }
    }
}
