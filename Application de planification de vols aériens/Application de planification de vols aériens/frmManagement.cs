using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Application_de_planification_de_vols_aériens
{
    public partial class frmManagement : Form
    {
        List<string> airportList = new List<string>();
        Pilot newPilot;
        Line line;
        Flight flight;
        Airport airport;
        DBConnection dbConnection = new DBConnection();
        public frmManagement()
        {
            InitializeComponent();
        }

        private void frmManagement_Load(object sender, EventArgs e)
        {
            //Update piltos current location
            newPilot = new Pilot();
            newPilot.UpdatePilotsCurrentLocation();


            cmdAddFlight.Enabled = false;


            //Add airportsNames in comboboxes
            List<string> airportType = new List<string>();
            airportType = dbConnection.GetAirportsTypes();
            airportList = dbConnection.GetAirportsNames();
            for(int i = 0; i < airportList.Count; i++)
            {
                string airportName = airportType[i] + " / " + airportList[i];
                cboAssignmentAirport.Items.Add(airportName);
                cboArrivalPlace.Items.Add(airportName);
                cboDeparturePlace.Items.Add(airportName);
            }
                

     

            //Add linesNames in combobox
            List<string> lineList = dbConnection.GetLinesNames();
            for(int y =0; y < lineList.Count; y++)
            {
                string[] fullLineName = lineList[y].Split('/');
                string airportType1 = dbConnection.GetAirportType(fullLineName[0]);
                string airportType2 = dbConnection.GetAirportType(fullLineName[1]);
                string lineName = airportType1 + " " + fullLineName[0] + " / " + airportType2 + " " + fullLineName[1];
                cboLine.Items.Add(lineName); 
            }

                
           
        }


        private void cmdDisplay_Click(object sender, EventArgs e)
        {
            //Show form frmAffichage
            frmDisplay frmDisplay = new frmDisplay();
            frmDisplay.Show();
        }

        public void cmdAddPilote_Click(object sender, EventArgs e)
        {
            try
            {
                //If all conditions are satisfied adds a pilot
                if (ArePilotFieldsFilled() && DoesStringContainsOnlyLetters(txtName.Text) && DoesStringContainsOnlyLetters(txtFirstName.Text) && DoesStringContainsOnlyNumbers(txtFlightHours.Text) && ArePilotNameLengthOrPilotFirstNameLengthCorrect(txtName.Text) && ArePilotNameLengthOrPilotFirstNameLengthCorrect(txtFirstName.Text) && !DoesFlightTimeBeginWith0(txtFlightHours.Text))
                {
                    //Get pilot's assignmentAirport Id
                    string[] airportFullName = cboAssignmentAirport.SelectedItem.ToString().Split('/');
                    string airportName = airportFullName[1].Substring(1, airportFullName[1].Length - 1);
                    airport = new Airport(airportName);
                    int idAirport = dbConnection.GetAirportId(airport);
                    
                    //Add pilot
                    newPilot = new Pilot(txtName.Text, txtFirstName.Text, int.Parse(txtFlightHours.Text), airport);
                    dbConnection.AddPilot(newPilot, idAirport);
                    MessageBox.Show("Le pilote a bien été ajouté");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdAddVol_Click(object sender, EventArgs e)
        {
            try
            {
                //Create arrival and departure airports
                string[] airportsNames = cboLine.SelectedItem.ToString().Split('/');
                airportsNames[0] = airportsNames[0].Replace("Aeroport international ", "");
                airportsNames[1] = airportsNames[1].Replace("Aeroport international ", "");
                Airport departureAirport = new Airport(airportsNames[0]);
                Airport arrivalAirport = new Airport(airportsNames[1].Substring(1, airportsNames[1].Length - 1));

                //Get airports id
                int idDepartureAirport = dbConnection.GetAirportId(departureAirport);
                int idArrivalAirport = dbConnection.GetAirportId(arrivalAirport);

                //Get line id
                int idLine = dbConnection.GetLineId(idDepartureAirport, idArrivalAirport);

                //Add flight
                dbConnection.AddFlight(flight, idLine);
                MessageBox.Show("Le vol a bien été ajouté");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdAddLine_Click(object sender, EventArgs e)
        {
            try
            {
                //If all conditions are satisfied add a line
                if (AreLineFieldsFilled() && !DoesDistanceBeginWith0(txtDistance.Text) && DoesDistanceContainsOnlyNumbers(txtDistance.Text) &&   !AreDepartureAirportAndArrivalAirportEqual())
                {
                    //Create airports
                    //Create airports
                    string[] departureAirportFullName = cboDeparturePlace.SelectedItem.ToString().Split('/');
                    string departureAirportName = departureAirportFullName[1].Substring(1, departureAirportFullName[1].Length - 1);
                    string[] arrivalAirportFullName = cboArrivalPlace.SelectedItem.ToString().Split('/');
                    string arrivalAirportName = arrivalAirportFullName[1].Substring(1, arrivalAirportFullName[1].Length - 1);
                    Airport departureAirport = new Airport(departureAirportName);
                    Airport arrivalAirport = new Airport(arrivalAirportName);

                    //Get airports id
                    int idDepartureAirport = dbConnection.GetAirportId(departureAirport);
                    int idArrivalAirport = dbConnection.GetAirportId(arrivalAirport);

                    //Create line
                    line = new Line(idDepartureAirport, idArrivalAirport, int.Parse(txtDistance.Text));
                    Line line1 = new Line(idArrivalAirport, idDepartureAirport, int.Parse(txtDistance.Text));

                    //Add departureAirport to arrivalAirport line and arrivalAirport to departureAirport line
                    dbConnection.AddLine(line);
                    dbConnection.AddLine(line1);
                    MessageBox.Show("La ligne a bien été ajoutée, une ligne retour a aussi été ajoutée");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #region checkPilotFiedls
        /// <summary>
        /// Return true if input string contains only letters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool DoesStringContainsOnlyLetters(string input)
        {
            bool output = Regex.IsMatch(input, @"^[a-zA-Zéèëêàïîç]+$");
            if (!output)
            {
                Exception exception = new Exception("Le prénom/nom ne contient pas uniquement des lettres");
                throw exception;
            }
            return output;
        }

        /// <summary>
        /// Return true if input string contains only numbers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool DoesStringContainsOnlyNumbers(string input)
        {
            bool output = Regex.IsMatch(input, @"^[0-9]+$");
            if (!output)
            {
                Exception exception = new Exception("Les heures de vols contiennent d'autres caractères que des chiffres");
                throw exception;
            }
            return output;
        }

        /// <summary>
        /// Return true if required fields to add a pilot are filled
        /// </summary>
        /// <returns></returns>
        private bool ArePilotFieldsFilled()
        {
            bool output = false;
            if (txtName.Text != string.Empty && txtFirstName.Text != string.Empty && txtFlightHours.Text != string.Empty && cboAssignmentAirport.SelectedIndex > -1)
            {
                output = true;
            }
            else
            {
                Exception exception = new Exception("Un ou plusieurs des champs requis ne sont pas remplis, veuillez les remplir afin de pouvoir ajouter un pilote !");
                throw exception;
            }
            return output;
        }

        /// <summary>
        /// Return true if input string does less than 46 chars
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool ArePilotNameLengthOrPilotFirstNameLengthCorrect(string input)
        {
            bool output;
            if (input.Length < 46)
            {
                output = true;
            }
            else
            {
                output = false;
                Exception exception = new Exception("Le nom ou prénom du pilote ne peut faire plus de 45 caractères");
                throw exception;
            }
            return output;
        }

        /// <summary>
        /// Return true if input string first char equals "0"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool DoesFlightTimeBeginWith0(string input)
        {
            bool output;
            string firstLetter = input.Substring(0, 1);
            if (firstLetter == "0")
            {
                output = true;
                Exception exception = new Exception("Les heures de vols ne peuvent commencer par un zéro !");
                throw exception;
            }
            else
            {
                output = false;
            }
            return output;
        }

        #endregion

        #region checkLineFields
        /// <summary>
        /// Return true if input string first char equals "0"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool DoesDistanceBeginWith0(string input)
        {
            bool output;
            string firstLetter = input.Substring(0, 1);
            if (firstLetter == "0")
            {
                output = true;
                Exception exception = new Exception("La distance ne peut pas commencer par 0 !");
                throw exception;
            }
            else
            {
                output = false;
            }
            return output;
        }

        /// <summary>
        /// Return true if input string contains only numbers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool DoesDistanceContainsOnlyNumbers(string input)
        {
            bool output = Regex.IsMatch(input, @"^[0-9]+$");
            if (!output)
            {
                Exception exception = new Exception("La distance contient d'autres caractères que des chiffres!");
                throw exception;
            }
            return output;
        }

        /// <summary>
        /// Return true if every line fields are filled
        /// </summary>
        /// <returns></returns>
        private bool AreLineFieldsFilled()
        {
            bool output = false;
            if (cboArrivalPlace.SelectedIndex > -1 && cboDeparturePlace.SelectedIndex > -1 && txtDistance.Text != string.Empty && int.Parse(txtDistance.Text) <= 18000)
            {
                output = true;
            }
            else if (cboArrivalPlace.SelectedIndex == -1 || cboDeparturePlace.SelectedIndex == -1)
            {
                output = false;
                Exception exception = new Exception("Veuillez sélectionner un lieu de départ et un lieu d'arrivée");
                throw exception;
            }
            else if (txtDistance.Text == string.Empty)
            {
                output = false;
                Exception exception = new Exception("Veuillez indiquer une distance");
                throw exception;
            }
            else if(int.Parse(txtDistance.Text) > 18000)
            {
                output = false;
                Exception exception = new Exception("La distance ne peut dépasser les 18000km");
                throw exception;
            }
            return output;
        }

        /// <summary>
        /// Return true if departureAirport and arrivalAirport are equal
        /// </summary>
        /// <returns></returns>
        private bool AreDepartureAirportAndArrivalAirportEqual()
        {
            bool output;
            if (cboArrivalPlace.SelectedItem.ToString() == cboDeparturePlace.SelectedItem.ToString())
            {
                output = true;
                Exception exception = new Exception("Le lieu de départ et le lieu d'arrivée ne peuvent être les mêmes");
                throw exception;
            }
            else
            {
                output = false;
            }
            return output;
        }

        #endregion

        /// <summary>
        /// Return true if every flight fields are filled
        /// </summary>
        /// <returns></returns>
        private bool AreFlightFieldsFilled()
        {
            bool output;
            if (cboLine.SelectedIndex > -1)
            {
                output = true;
            }
            else
            {
                output = false;
                Exception exception = new Exception("Veuillez choisir une ligne pour le vol");
                throw exception;
            }
            return output;
        }

        /// <summary>
        /// Calculate and display arrivalDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDateArrivee_Click(object sender, EventArgs e)
        {
            try
            {
                if (AreFlightFieldsFilled())
                {
                    if (dtpDepartureDate.Value.Year < DateTime.Now.Year || dtpDepartureDate.Value.Year == DateTime.Now.Year && dtpDepartureDate.Value.Month < DateTime.Now.Month || dtpDepartureDate.Value.Year == DateTime.Now.Year && dtpDepartureDate.Value.Month == DateTime.Now.Month && dtpDepartureDate.Value.Day < DateTime.Now.Day)
                    {
                        MessageBox.Show("La date du vol ne peut être dans le passé.");
                    }
                    else if (dtpDepartureDate.Value.Year == DateTime.Now.Year && dtpDepartureDate.Value.Month == DateTime.Now.Month && dtpDepartureDate.Value.Day == DateTime.Now.Day && nudHDeparture.Value < DateTime.Now.Hour || dtpDepartureDate.Value.Year == DateTime.Now.Year && dtpDepartureDate.Value.Month == DateTime.Now.Month && dtpDepartureDate.Value.Day == DateTime.Now.Day && nudHDeparture.Value == DateTime.Now.Hour && nudMDeparture.Value < DateTime.Now.Minute)
                    {
                        MessageBox.Show("L'heure de vol ne peut être dans le passé.");
                    }
                    else { 
                        //if departureDate is equal to today's date, ask user if it is intentional
                        if (dtpDepartureDate.Value.Year == DateTime.Now.Year && dtpDepartureDate.Value.Month == DateTime.Now.Month && dtpDepartureDate.Value.Day == DateTime.Now.Day)
                        {
                            if (MessageBox.Show("La date du vol n'a pas été modifiée cela vous convient-il ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        //if departureHour is equal to 00:00, ask user if it is intentional
                        if (nudHDeparture.Value == 0 && nudHArrival.Value == 0)
                        {
                            if (MessageBox.Show("L'heure du vol n'a pas été modifiée cela vous convient-il ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                        }

                        //Store departureHours and departureMinutes in correct format
                        int departureH = (int)nudHDeparture.Value;
                        string sDepartureH = departureH.ToString();
                        int departureM = (int)nudMDeparture.Value;
                        string sDepartureM = departureM.ToString();
                        int arrivalH = (int)nudHArrival.Value;
                        int arrivalM = (int)nudHArrival.Value;
                        if (departureH < 10)
                        {
                            sDepartureH = "0" + departureH;
                        }
                        if (departureM < 10)
                        {
                            sDepartureM = "0" + departureM;
                        }

                        //Create arrival and departure airports
                        string[] airportsNames = cboLine.SelectedItem.ToString().Split('/');
                        airportsNames[0] = airportsNames[0].Replace("Aeroport international ", "");
                        airportsNames[1] = airportsNames[1].Replace("Aeroport international ", "");
                        Airport departureAirport = new Airport(airportsNames[0]);
                        Airport arrivalAirport = new Airport(airportsNames[1].Substring(1, airportsNames[1].Length - 1));

                        //Get departure and arrival airport acronyms to build flightName
                        string departureAirportAcronym = dbConnection.GetAirportAcronym(departureAirport);
                        string arrivalAirportAcronym = dbConnection.GetAirportAcronym(arrivalAirport);

                        //Get departure and arrival airports id
                        int idDepartureAirport = dbConnection.GetAirportId(departureAirport);
                        int idArrivalAirport = dbConnection.GetAirportId(arrivalAirport);

                        //Create line
                        int lineDistance = dbConnection.GetLineDistance(idDepartureAirport, idArrivalAirport);
                        line = new Line(idDepartureAirport, idArrivalAirport, lineDistance);

                        //Get line id
                        int idLine = dbConnection.GetLineId(idDepartureAirport, idArrivalAirport);

                        //Store departureYear, departureMonth and departureDay in correct format
                        int departureYear = dtpDepartureDate.Value.Year;
                        int departureMonth = dtpDepartureDate.Value.Month;
                        string sDepartureMonth = departureMonth.ToString();
                        int departureDay = dtpDepartureDate.Value.Day;
                        string sDepartureDay = departureDay.ToString();
                        if (departureMonth < 10)
                        {
                            sDepartureMonth = "0" + departureMonth;
                        }
                        if (departureDay < 10)
                        {
                            sDepartureDay = "0" + departureDay;
                        }

                        //build flightName
                        string flightName = departureAirportAcronym + arrivalAirportAcronym + dtpDepartureDate.Value.Year + sDepartureMonth + sDepartureDay + sDepartureH + sDepartureM;

                        DateTime departureDate = new DateTime(dtpDepartureDate.Value.Year, dtpDepartureDate.Value.Month, dtpDepartureDate.Value.Day, departureH, departureM, 0, 0);

                        //Create flight
                        flight = new Flight(flightName, departureDate, line);

                        //Calculate arrivalDate
                        nudHArrival.Value = flight.ArrivalDate.Hour;
                        nudMArrival.Value = flight.ArrivalDate.Minute;
                        dtpArrivalDate.Value = flight.ArrivalDate;


                        cmdAddFlight.Enabled = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboLigne_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAddFlight.Enabled = false;
        }

        private void nudHDepart_ValueChanged(object sender, EventArgs e)
        {
            cmdAddFlight.Enabled = false;
        }

        private void nudMDepart_ValueChanged(object sender, EventArgs e)
        {
            cmdAddFlight.Enabled = false;
        }

        private void dtpDateDepart_ValueChanged(object sender, EventArgs e)
        {
            cmdAddFlight.Enabled = false;
        }

    }
}
