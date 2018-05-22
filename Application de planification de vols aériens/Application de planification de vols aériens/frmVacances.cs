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
    public partial class frmVacances : Form
    {
        DBConnection dbConnection = new DBConnection();
        private int idPilot;
        private int vacationDaysLeft;
        public frmVacances()
        {
            InitializeComponent();
        }


    public int IdPilot
        {
            get
            {
                return idPilot;
            }

            set
            {
                idPilot = value;
            }
        }

        public frmVacances(int id)
        {
            InitializeComponent();
            this.idPilot = id;
        }

        private void cmdValider_Click(object sender, EventArgs e)
        {
            List<string> vacations = new List<string>();
            vacations = dbConnection.GetVacation(idPilot);
            DateTime begin = new DateTime(dtpDebut.Value.Year, dtpDebut.Value.Month, dtpDebut.Value.Day, 0,0,0,0);
            DateTime end = new DateTime(dtpFin.Value.Year, dtpFin.Value.Month, dtpFin.Value.Day,0,0,0,0);
            dbConnection.addVacation(IdPilot, begin, end);
        }

        private void frmVacances_Load(object sender, EventArgs e)
        {
        }

        private void VacationDayLeft(int idPilot)
        {

        }
    }
}
