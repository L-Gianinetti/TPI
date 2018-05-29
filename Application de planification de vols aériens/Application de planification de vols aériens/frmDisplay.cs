﻿using System;
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
            StringBuilder csv = new StringBuilder();
            string filePath = "C:\\Users\\Lucas.GIANINETTI\\Desktop\\VolsAeriens\\VolsAeriens.csv";
            //if a flight is selected
            if (dgvPilots.SelectedRows.Count > 0)
            {
                if(cboMonth.SelectedIndex > -1)
                {
                    //Get the flightName
                    int selectedrowindex = dgvPilots.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvPilots.Rows[selectedrowindex];
                    string idPilot = Convert.ToString(selectedRow.Cells["colIdPilot"].Value);


                    if (int.Parse(idPilot) == 0)
                    {
                        MessageBox.Show("Veuillez sélectionner une seule ligne et non la totalité du tableau !");
                        return;
                    }
                    else
                    {
                        if(cboMonth.SelectedItem.ToString() == "Mois actuel")
                        {
                            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                            string yearMonthHeader = "Année; Mois;";
                            int month = DateTime.Now.Month;
                            string sMonth = month.ToString(); 
                            string yearMonth = DateTime.Now.Year.ToString() + ";" + DateTime.Now.Month.ToString() +";";
                            string monthDays = string.Empty;
                            string activityName = string.Empty;
                            if(month < 10)
                            {
                                sMonth = "0" + sMonth;
                            }

                            for (int i = 0; i < days; i++)
                            {
                                string y = (i +1).ToString();
                                if(i < 9)
                                {
                                    y = "0" + y;                                    
                                }
                                monthDays +=  y + ";";
                                
                                string day = DateTime.Now.Year + "-" + sMonth + "-" + y + "%";
                                List<string> flightNames = dbConnection.GetFlightNameIfPilotWorks(int.Parse(idPilot), day);
                                List<string> vacationDays = dbConnection.GetIdVacationIfPilotIsInVacation(int.Parse(idPilot), day);
                                if(flightNames.Count != 0)
                                {  
                                    for(int z=0; z < flightNames.Count; z++)
                                    {
                                        activityName += flightNames[z] + "  ";
                                    }
                                    activityName = activityName + ";";
                                }
                                else if(vacationDays.Count != 0)
                                {
                                    for(int z = 0; z < vacationDays.Count; z++)
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
                            activityName =  yearMonth + activityName;
                            csv.AppendLine(yearMonthHeader);
                            csv.AppendLine(activityName);
                            File.WriteAllText(filePath, csv.ToString());
                            
                        }
                        else
                        {

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
            pilot.UpdatePilotsCurrentLocation();

            //if a flight is selected
            if (dgvFlights.SelectedRows.Count > 0)
            {
                //Get the flightName
                int selectedrowindex = dgvFlights.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvFlights.Rows[selectedrowindex];
                string flightName = Convert.ToString(selectedRow.Cells["colName"].Value);

                frmFlightAssignment frmFlightAssignment = new frmFlightAssignment(flightName);
                if (flightName == "0")
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
