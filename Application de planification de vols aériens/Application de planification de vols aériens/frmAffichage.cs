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
    public partial class Affichage : Form
    {
        DBConnection dbConnection = new DBConnection();
        public Affichage()
        {
            InitializeComponent();
        }

        private void cmdGestion_Click(object sender, EventArgs e)
        {

        }

        private void cmdAfficherVacances_Click(object sender, EventArgs e)
        {

        }

        private void cmdPlanifierVacances_Click(object sender, EventArgs e)
        {

        }

        private void cmdGenererPlanning_Click(object sender, EventArgs e)
        {

        }

        private void cmdPlanifier_Click(object sender, EventArgs e)
        {

        }

        private void Affichage_Load(object sender, EventArgs e)
        {
            displayPilots();
            displayFlights();
            displayLines();
        }

        private void grbAffichage_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPilotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void displayPilots()
        {
            List<Pilot> pilots = new List<Pilot>();
            pilots = dbConnection.GetPilots();
            pilots.ForEach(delegate (Pilot pilot)
            {
                string[] row = new string[] { pilot.Id.ToString(), pilot.Name, pilot.FirstName, pilot.AssignmentAirportName, pilot.FlightTime.ToString() };
                dgvPilotes.Rows.Add(row);
            });
        }
        private void displayFlights()
        {
            List<Flight> flights = new List<Flight>();
            flights = dbConnection.GetFlights();
            flights.ForEach(delegate (Flight flight)
            {
                string pilotName1 = string.Empty;
                string pilotName2 = string.Empty;
                if(flight.IdFlight > 0)
                {
                    List<string> idPilots = dbConnection.GetPilotsFromFlight(flight.IdFlight);
                    if (idPilots.Any())
                    {
                        pilotName1 = dbConnection.GetPilotFullName(int.Parse(idPilots[0].ToString()));
                        pilotName2 = dbConnection.GetPilotFullName(int.Parse(idPilots[1].ToString()));
                    }
                }
                
                

                string[] row = new string[] { flight.Name, flight.IdLine.ToString(), flight.SDepartureDate, flight.SArrivalDate, pilotName1, pilotName2};
                dgvVols.Rows.Add(row);
            });
        }

        private void displayLines()
        {
            List<Line> lines = new List<Line>();
            lines = dbConnection.GetLines();
            lines.ForEach(delegate (Line line)
            {
                string departureAirportName = dbConnection.GetAirportName(line.IdDepartureAirport);
                string arrivalAirportName = dbConnection.GetAirportName(line.IdArrivalAirport);
                string[] row = new string[] { line.IdLine.ToString(), departureAirportName, arrivalAirportName, line.Distance.ToString() };
                dgvLignes.Rows.Add(row);
            });
        }
    }
}
