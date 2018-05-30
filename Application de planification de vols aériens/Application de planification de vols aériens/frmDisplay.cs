using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_de_planification_de_vols_aériens
{
    public partial class frmDisplay : Form
    { 
        Pilot pilot = new Pilot();
        DBConnection dbConnection = new DBConnection();
        public frmDisplay()
        {
            InitializeComponent();
        }

        private void frmDisplay_Load(object sender, EventArgs e)
        {
            displayPilots();
            displayFlights();
            displayLines();

            //add actual month and next month to cboMonth
            cboMonth.Items.Add("Mois actuel");
            cboMonth.Items.Add("Mois prochain");
        }

        private void cmdManagement_Click(object sender, EventArgs e)
        {

        }

        private void cmdDisplayVacation_Click(object sender, EventArgs e)
        {
            //if a pilot is selected in the data grid view
            if (dgvPilots.SelectedRows.Count > 0)
            {
                //Get the id of the selected pilot
                int selectedrowindex = dgvPilots.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvPilots.Rows[selectedrowindex];
                int idPilot = Convert.ToInt32(selectedRow.Cells["colIdPilot"].Value);

                if (idPilot == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une seule ligne et non la totalité du tableau !");
                    return;
                }
                else
                {
                    //show form frmVacancesAffichage
                    frmVacationDisplay frmVacancesAffichage = new frmVacationDisplay(idPilot);
                    frmVacancesAffichage.Show();
                    DialogResult res = frmVacancesAffichage.DialogResult;
                    if (res == DialogResult.OK)
                    {
                        frmVacancesAffichage.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau. Vous pouvez sélectionner la ligne grâce à la colonne située tout à gauche du tableau.");
            }

        }

        private void cmdPlanVacation_Click(object sender, EventArgs e)
        {
            //if a pilot is selected
            if (dgvPilots.SelectedRows.Count > 0)
            {
                //Get the id of the selected pilot
                int selectedrowindex = dgvPilots.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvPilots.Rows[selectedrowindex];
                int idPilot = Convert.ToInt32(selectedRow.Cells["colIdPilot"].Value);

                frmVacation frmVacances = new frmVacation(idPilot);
                if (idPilot == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une seule ligne et non la totalité du tableau !");
                    return;
                }
                else if (!frmVacances.VacationDaysLeft())
                {
                    MessageBox.Show("Le pilote a déjà pris ses 25 jours/5semaines de vacances !");
                }
                else
                {
                    //show form frmVacances
                    frmVacances.Show();
                    DialogResult res = frmVacances.DialogResult;
                    if (res == DialogResult.OK)
                    {
                        frmVacances.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau. Vous pouvez sélectionner la ligne grâce à la colonne située tout à gauche du tableau.");
            }
        }

        private void cmdGeneratePlaning_Click(object sender, EventArgs e)
        {
            //Path of the main Folder
            string mainDirectoryPath = "C:\\Program Files (x86)\\PlanificationVolsAeriens";
            //Create folder if not exist
            System.IO.Directory.CreateDirectory(mainDirectoryPath);
            //Path of the folder inside the main folder
            string secondDirectoryPath = "C:\\Program Files (x86)\\PlanificationVolsAeriens\\Plannings\\";
            //Create folder if not exist
            System.IO.Directory.CreateDirectory(secondDirectoryPath);

            //StringBuilder for the readMe.txt and the Pilot's data
            StringBuilder csv = new StringBuilder();
            StringBuilder infosTxt = new StringBuilder();
            //Create ReadMe.txt, it explains how data are stored in pilot's planning
            string infosPath = "C:\\Program Files (x86)\\PlanificationVolsAeriens\\Plannings\\ReadMe.txt";
            infosTxt.AppendLine("Les jours ou le pilote ne travaille pas contiennent FreeDay");
            infosTxt.AppendLine("Les jours ou le pilote est en vacance contiennent Vacation");
            infosTxt.AppendLine("Les jours ou le pilote travaille contiennent le nom du vol - l'heure d'arrivée du vol");
            File.WriteAllText(infosPath, infosTxt.ToString());

            //if a pilot is selected
            if (dgvPilots.SelectedRows.Count > 0)
            {
                //if a month is selected
                if(cboMonth.SelectedIndex > -1)
                {
                    //Get the pilot'id, pilot's name and pilot's firstName from dgvPilots
                    int selectedrowindex = dgvPilots.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvPilots.Rows[selectedrowindex];
                    string idPilot = Convert.ToString(selectedRow.Cells["colIdPilot"].Value);
                    string pilotName = Convert.ToString(selectedRow.Cells["colPilotName"].Value);
                    string pilotFirstName = Convert.ToString(selectedRow.Cells["colPilotFirstName"].Value);

                    //if all the datagridview is selected
                    if (int.Parse(idPilot) == 0)
                    {
                        MessageBox.Show("Veuillez sélectionner une seule ligne et non la totalité du tableau !");
                        return;
                    }
                    else
                    {   //if selected month = current month
                        if(cboMonth.SelectedItem.ToString() == "Mois actuel")
                        {


                            //numvers of days in current month
                            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

                            //Header of the 2 first Data
                            string yearMonthHeader = "Année; Mois;";
                            //First two datas
                            string yearMonth = DateTime.Now.Year.ToString() + ";" + DateTime.Now.Month.ToString() + ";";



         
                            string monthDays = string.Empty;

                            //String to store CSVdata for each day of the month
                            string activityName = string.Empty;

                            //Build a string that contains number of the month
                            int month = DateTime.Now.Month;
                            string sMonth = month.ToString();
                            if (month < 10)
                            {
                                sMonth = "0" + sMonth;
                            }

                            //Create a folder for the current year to store planing in it
                            string pilotFolderPath = idPilot + pilotName + pilotFirstName + "\\" + DateTime.Now.Year.ToString() + "\\";
                            System.IO.Directory.CreateDirectory(secondDirectoryPath + pilotFolderPath);

                            //path of the csv file
                            string pilotPath = DateTime.Now.Year.ToString() + sMonth + ".csv";
                            string filePathCompleted = secondDirectoryPath + pilotFolderPath + pilotPath;

                            //For each day of the month
                            for (int i = 0; i < days; i++)
                            {
                                //build a string that contains the day of the month
                                string y = (i +1).ToString();
                                if(i < 9)
                                {
                                    y = "0" + y;                                    
                                }
                                monthDays +=  y + ";";
                                
                                //Build a string that contains Date in MySQL format
                                string day = DateTime.Now.Year + "-" + sMonth + "-" + y + "%";
                                //List that contains the flightname - arrivalDate for each flight of current day if there is a flight this day
                                List<string> flightNames = dbConnection.GetFlightNameIfPilotWorks(int.Parse(idPilot), day);
                                //List that contains IdVacation if the pilot is in vacation this day
                                List<string> vacationDays = dbConnection.GetIdVacationIfPilotIsInVacation(int.Parse(idPilot), day);
                                //If there is at least 1 flight this day
                                if (flightNames.Count != 0)
                                {  
                                    //Add differentsFlight to the CSVData string
                                    for(int z=0; z < flightNames.Count; z++)
                                    {
                                        activityName += flightNames[z] + " / ";
                                    }
                                    activityName = activityName + ";";
                                }
                                //If the pilot is in vacation this day
                                else if(vacationDays.Count != 0)
                                {
                                    //Add vacation to the CSVData string
                                    for(int z = 0; z < vacationDays.Count; z++)
                                    {
                                        activityName += "Vacation" + ";";
                                    }
                                }
                                //If pilot is on a "free day"
                                else
                                {
                                    //Add Free day to the CSVData string
                                    activityName += "Free day" + ";";
                                }
                            }
                            //string that contains Année;Mois;01;02;03;04;...;30;...
                            yearMonthHeader = yearMonthHeader + monthDays;
                            //string that contains the currentYear;currentMonth;activityForDay1;...;activityForDay30;...
                            activityName =  yearMonth + activityName;
                            
                            csv.AppendLine(yearMonthHeader);
                            csv.AppendLine(activityName);
                            //Write the csvText in the file
                            File.WriteAllText(filePathCompleted, csv.ToString());
                            
                        }
                        //if selected month = nextMonth
                        else
                        {
                            DateTime currentDate = DateTime.Now;
                            currentDate = currentDate.AddMonths(1);

                            int days = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                            string yearMonthHeader = "Année; Mois;";
                            int month = currentDate.Month;
                            string sMonth = month.ToString();
                            string yearMonth = currentDate.Year.ToString() + ";" + currentDate.Month.ToString() + ";";
                            string monthDays = string.Empty;
                            string activityName = string.Empty;
                            if (month < 10)
                            {
                                sMonth = "0" + sMonth;
                            }

                            string pilotFolderPath = idPilot + pilotName + pilotFirstName + "\\" + currentDate.Year.ToString()+"\\";
                            System.IO.Directory.CreateDirectory(secondDirectoryPath + pilotFolderPath);
                            
                            string pilotPath = currentDate.Year.ToString() + sMonth + ".csv";
                            string filePathCompleted = secondDirectoryPath + pilotFolderPath + pilotPath;


                            for (int i = 0; i < days; i++)
                            {
                                string y = (i + 1).ToString();
                                if (i < 9)
                                {
                                    y = "0" + y;
                                }
                                monthDays += y + ";";

                                string day = currentDate.Year.ToString() + "-" + sMonth + "-" + y + "%";
                                List<string> flightNames = dbConnection.GetFlightNameIfPilotWorks(int.Parse(idPilot), day);
                                List<string> vacationDays = dbConnection.GetIdVacationIfPilotIsInVacation(int.Parse(idPilot), day);
                                if (flightNames.Count != 0)
                                {
                                    for (int z = 0; z < flightNames.Count; z++)
                                    {
                                        activityName += flightNames[z] + "  ";
                                    }
                                    activityName = activityName + ";";
                                }
                                else if (vacationDays.Count != 0)
                                {
                                    for (int z = 0; z < vacationDays.Count; z++)
                                    {
                                        activityName += "Vacation" + ";";
                                    }
                                }
                                else
                                {
                                    activityName += "Free day" + ";";
                                }
                            }
                            yearMonthHeader = yearMonthHeader + monthDays;
                            activityName = yearMonth + activityName;
                            csv.AppendLine(yearMonthHeader);
                            csv.AppendLine(activityName);
                            File.WriteAllText(filePathCompleted, csv.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez indiquer le mois pour lequel générer le planing");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau. Vous pouvez sélectionner la ligne grâce à la colonne située tout à gauche du tableau.");
            }

        }

        private void cmdPlan_Click(object sender, EventArgs e)
        {
            //update Pilots current location
            //pilot.UpdatePilotsCurrentLocation();

            //if a flight is selected
            if (dgvFlights.SelectedRows.Count > 0)
            {
                //Get the flightName
                int selectedrowindex = dgvFlights.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvFlights.Rows[selectedrowindex];
                string flightName = Convert.ToString(selectedRow.Cells["colName"].Value);

                frmFlightAssignment frmFlightAssignment = new frmFlightAssignment(flightName);
                if (flightName == "")
                {
                    MessageBox.Show("Veuillez sélectionner une seule ligne et non la totalité du tableau !");
                    return;
                }
                else
                {
                    //Show form frmFlightAssignment
                    frmFlightAssignment.Show();
                    DialogResult res = frmFlightAssignment.DialogResult;
                    if (res == DialogResult.OK)
                    {
                        frmFlightAssignment.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau. Vous pouvez sélectionner la ligne grâce à la colonne située tout à gauche du tableau.");
            }
        }







        private void displayPilots()
        {
            //List<Pilot> to store existing pilots
            List<Pilot> pilots = new List<Pilot>();
            pilots = dbConnection.GetPilots();

            //ForEach pilot display his id,name,firstname,assignmentAirportName and flightTime in the DataGridView
            pilots.ForEach(delegate (Pilot pilot)
            {
                string[] row = new string[] { pilot.Id.ToString(), pilot.Name, pilot.FirstName, pilot.AssignmentAirportName, pilot.FlightTime.ToString() };
                dgvPilots.Rows.Add(row);
            });
        }

        private void displayFlights()
        {
            //List<Flight> to store existing flights
            List<Flight> flights = new List<Flight>();
            flights = dbConnection.GetFlights();


            flights.ForEach(delegate (Flight flight)
            {
                //T store Pilot n°1 and Pilot n°2 names
                string[] pilotFullName = new string[2];

                if (flight.IdFlight > 0)
                {
                    //List<string> to store Pilots' id from a specific flgiht
                    List<string> idPilots = dbConnection.GetIdPilotsFromFlight(flight.IdFlight);
                    //If the flight is assigned to a pilot
                    if (idPilots.Any())
                    {
                        for (int i = 0; i < idPilots.Count; i++)
                        {
                            //Build pilotFullName
                            string pilotFirstName = dbConnection.GetPilotFirstName(int.Parse(idPilots[i]));
                            string pilotName = dbConnection.GetPilotName(int.Parse(idPilots[i]));
                            pilotFullName[i] = idPilots[i] + ": " + pilotName + " " + pilotFirstName;
                        }
                    }
                }


                //Display flightName, idLine, departureDate, arrivalDate, pilot n°1 full name, pilot n°2 full name in DataGridView
                string[] row = new string[] { flight.Name, flight.IdLine.ToString(), flight.SDepartureDate, flight.SArrivalDate, pilotFullName[0], pilotFullName[1] };
                dgvFlights.Rows.Add(row);
            });
        }

        private void displayLines()
        {
            //List<Line> to store existing lines
            List<Line> lines = new List<Line>();
            lines = dbConnection.GetLines();
            lines.ForEach(delegate (Line line)
            {
                string departureAirportName = dbConnection.GetAirportName(line.IdDepartureAirport);
                string arrivalAirportName = dbConnection.GetAirportName(line.IdArrivalAirport);
                //For each line display its id, departureAirportName, arrivalAirportName, distance in the DataGridView
                string[] row = new string[] { line.IdLine.ToString(), departureAirportName, arrivalAirportName, line.Distance.ToString() };
                dgvLines.Rows.Add(row);
            });
        }
    }
}
