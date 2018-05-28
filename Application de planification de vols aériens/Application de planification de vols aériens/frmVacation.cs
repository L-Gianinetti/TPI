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
    public partial class frmVacation : Form
    {
        DBConnection dbConnection = new DBConnection();
        private int idPilot;
        private double daysLeft;
        public frmVacation()
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

        public double DaysLeft
        {
            get
            {
                return daysLeft;
            }

            set
            {
                daysLeft = value;
            }
        }


        public frmVacation(int id)
        {
            InitializeComponent();
            this.idPilot = id;
        }

        private void cmdValider_Click(object sender, EventArgs e)
        {
            List<string> vacations = new List<string>();
            DateTime begin = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0, 0);
            DateTime end = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 0, 0, 0, 0);

            //Calculate lenght of the selected vacation in days
            double days = (end - begin).TotalDays + 1;


            if (begin < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("La date du début des vacances ne peut précéder aujourd'hui");
            }
            else if (end < begin)
            {
                MessageBox.Show("La date de fin ne peut précéder la date de début !");
            }
            else if (daysLeft - days < 0)
            {
                MessageBox.Show("Vous ne pouvez pas réserver plus de 25 jours de vacances, il reste au pilote " + daysLeft + "jours de vacances disponbile(s)");
            }
            else if (IsPilotInVacationYet(begin, end))
            {
                MessageBox.Show("Le pilote est deja en vacances pendant cette periode");
            }
            else
            {
                //add vacation 
                dbConnection.addVacation(IdPilot, begin, end);
                MessageBox.Show("Les vacances ont bien été ajoutées");
                //close form frmVacances
                this.Close();
            }
        }

        private void frmVacances_Load(object sender, EventArgs e)
        {
            //VacationDaysLeft();
        }

        //Return true if pilot has more than 0 vacationDays left
        public bool VacationDaysLeft()
        {
            bool output = true;

            //List<string> to store vacationsStartDates and VacationsEndDate for a specific pilot
            List<string> vacationsStartDates = new List<string>();
            List<string> vacationsEndDates = new List<string>();
            vacationsStartDates = dbConnection.GetVacationStartDates(idPilot);
            vacationsEndDates = dbConnection.GetVacationEndDates(idPilot);

            //Amount of vacation days available
            daysLeft = 25;

            //for each vacationDate
            for (int i = 0; i < vacationsStartDates.Count; i++)
            {
                double vacationDaysTaken = 0;

                //Build endDate and startDate
                int startYear = int.Parse(vacationsStartDates[i].Substring(6, 4));
                int startMonth = int.Parse(vacationsStartDates[i].Substring(3, 2));
                int startDay = int.Parse(vacationsStartDates[i].Substring(0, 2));
                int endYear = int.Parse(vacationsEndDates[i].Substring(6, 4));
                int endMonth = int.Parse(vacationsEndDates[i].Substring(3, 2));
                int endDay = int.Parse(vacationsEndDates[i].Substring(0, 2));
                DateTime endDate = new DateTime(endYear, endMonth, endDay, 0, 0, 0);
                DateTime startDate = new DateTime(startYear, startMonth, startDay, 0, 0, 0);

                //Calculate numbers of days for current vacation
                vacationDaysTaken += (endDate - startDate).TotalDays + 1;


                daysLeft -= vacationDaysTaken;
            }
            if (daysLeft == 0)
            {
                output = false;
            }
            return output;
        }

        //Return true if pilot is already in vacation in the startDate and endDate selected
        public bool IsPilotInVacationYet(DateTime start, DateTime end)
        {
            bool output = false;

            //List<string> to store vacationsStartDates and VacationsEndDate for a specific pilot
            List<string> vacationsStartDates = new List<string>();
            List<string> vacationsEndDates = new List<string>();
            vacationsStartDates = dbConnection.GetVacationStartDates(idPilot);
            vacationsEndDates = dbConnection.GetVacationEndDates(idPilot);

            for (int i = 0; i < vacationsStartDates.Count; i++)
            {
                //Build endDate and startDate
                int startYear = int.Parse(vacationsStartDates[i].Substring(6, 4));
                int startMonth = int.Parse(vacationsStartDates[i].Substring(3, 2));
                int startDay = int.Parse(vacationsStartDates[i].Substring(0, 2));
                int endYear = int.Parse(vacationsEndDates[i].Substring(6, 4));
                int endMonth = int.Parse(vacationsEndDates[i].Substring(3, 2));
                int endDay = int.Parse(vacationsEndDates[i].Substring(0, 2));
                DateTime endDate = new DateTime(endYear, endMonth, endDay, 0, 0, 0);
                DateTime startDate = new DateTime(startYear, startMonth, startDay, 0, 0, 0);

                //Check if pilot is already in vacation 
                if ((startDate.Ticks >= start.Ticks && startDate.Ticks <= end.Ticks) || (endDate.Ticks >= start.Ticks && endDate.Ticks <= end.Ticks))
                {
                    output = true;
                    return output;
                }
                else
                {
                    output = false;
                }
            }
            return output;
        }
    }
}
