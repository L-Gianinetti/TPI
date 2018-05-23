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
        private int idPilot;
        DBConnection dbConnection = new DBConnection();
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

        public frmVacancesAffichage(int id)
        {
            InitializeComponent();
            this.idPilot = id;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

        }

        private void frmVacancesAffichage_Load(object sender, EventArgs e)
        {
            DisplayVacation();
        }

        private void DisplayVacation()
        {
            List<string> vacationsStartDates = new List<string>();
            List<string> vacationsEndDates = new List<string>();
            vacationsStartDates = dbConnection.GetVacationStartDates(idPilot);
            vacationsEndDates = dbConnection.GetVacationEndDates(idPilot);

            for (int i = 0; i < vacationsStartDates.Count; i++)
            {
                int startYear = int.Parse(vacationsStartDates[i].Substring(6, 4));
                int startMonth = int.Parse(vacationsStartDates[i].Substring(3, 2));
                int startDay = int.Parse(vacationsStartDates[i].Substring(0, 2));
                int endYear = int.Parse(vacationsEndDates[i].Substring(6, 4));
                int endMonth = int.Parse(vacationsEndDates[i].Substring(3, 2));
                int endDay = int.Parse(vacationsEndDates[i].Substring(0, 2));
                DateTime endDate = new DateTime(endYear, endMonth, endDay, 0, 0, 0);
                DateTime startDate = new DateTime(startYear, startMonth, startDay, 0, 0, 0);



                string[] row = new string[] { startDate.ToShortDateString(), endDate.ToShortDateString()};
                dgvVacation.Rows.Add(row);
            };
        }
    }
}
