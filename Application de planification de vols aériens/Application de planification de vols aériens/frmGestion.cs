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
    public partial class frmGestion : Form
    {
        List<string> airportList = new List<string>();
        Pilot newPilot;
        Airport airport;
        DBConnection dbConnexion = new DBConnection();
        public frmGestion()
        {
            InitializeComponent();
        }

        private void cmdAffichage_Click(object sender, EventArgs e)
        {

        }

        private void cmdAjouterPilote_Click(object sender, EventArgs e)
        {
            if(cboAeroportAffectation.SelectedIndex > -1)
            {
                airport = new Airport(cboAeroportAffectation.SelectedItem.ToString());
                int idAirport = dbConnexion.GetAirportId(airport);
                newPilot = new Pilot(txtNom.Text, txtPrenom.Text, int.Parse(txtHeuresVol.Text), airport);
                dbConnexion.AddPilot(newPilot, idAirport);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un aéroport d'affectation svp!");
            }
        }

        private void cmdAjouterVol_Click(object sender, EventArgs e)
        {

        }

        private void cmdAjouterLigne_Click(object sender, EventArgs e)
        {

        }

        private void frmGestion_Load(object sender, EventArgs e)
        {
            airportList = dbConnexion.GetAirportName();
            airportList.ForEach(delegate (String airport)
                {
                    cboAeroportAffectation.Items.Add(airport);
                });
        }
    }
}
