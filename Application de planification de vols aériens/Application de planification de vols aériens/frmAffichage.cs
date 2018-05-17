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
            List<Pilot> pilots = new List<Pilot>();
            pilots = dbConnection.GetPilots();
            pilots.ForEach(delegate (Pilot pilot)
            {
                string[] row = new string[] { pilot.Name, pilot.FirstName, pilot.AssignmentAirportName, pilot.FlightTime.ToString() };
                dgvPilotes.Rows.Add(row);
            });
        }

        private void grbAffichage_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPilotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
