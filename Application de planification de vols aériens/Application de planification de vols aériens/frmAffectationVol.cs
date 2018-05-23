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
        private string flightName;
        public frmAffectationVol(string name)
        {
            InitializeComponent();
            this.flightName = name;
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

        }

        private void cmdPlanifier_Click(object sender, EventArgs e)
        {

        }
    }
}
