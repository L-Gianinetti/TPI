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
    public partial class frmVacancesAffichage : Form
    {
        public frmVacancesAffichage()
        {
            InitializeComponent();
        }

        public Vacation Vacation
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

        }
    }
}
