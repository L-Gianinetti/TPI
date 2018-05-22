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
    public partial class frmGestion : Form
    {
        List<string> airportList = new List<string>();
        Pilot newPilot;
        Line line;
        Flight flight;
        Airport airport;
        DBConnection dbConnexion = new DBConnection();
        public frmGestion()
        {
            InitializeComponent();
        }

        private void cmdAffichage_Click(object sender, EventArgs e)
        {
            Affichage frmAffichage = new Affichage();
            frmAffichage.Show();
 
        }

        public void cmdAjouterPilote_Click(object sender, EventArgs e)
        {
            try
            {
                //If all conditions are satisfied adds a pilot
                if (ArePilotFieldsFilled() && DoesStringContainsOnlyLetters(txtNom.Text) && DoesStringContainsOnlyLetters(txtPrenom.Text) && DoesStringContainsOnlyNumbers(txtHeuresVol.Text) && ArePilotNameLengthOrPilotFirstNameLengthCorrect(txtNom.Text) && ArePilotNameLengthOrPilotFirstNameLengthCorrect(txtPrenom.Text) && !DoesFlightTimeBeginWith0(txtHeuresVol.Text))
                {
                    airport = new Airport(cboAeroportAffectation.SelectedItem.ToString());
                    int idAirport = dbConnexion.GetAirportId(airport);
                    newPilot = new Pilot(txtNom.Text, txtPrenom.Text, int.Parse(txtHeuresVol.Text), airport);
                    dbConnexion.AddPilot(newPilot, idAirport);
                    MessageBox.Show("Le pilote a bien été ajouté");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //TODO
        private void cmdAjouterVol_Click(object sender, EventArgs e)
        {

            string[] airportsNames = cboLigne.SelectedItem.ToString().Split('/');
            Airport departureAirport = new Airport(airportsNames[0]);
            Airport arrivalAirport = new Airport(airportsNames[1].Substring(1, airportsNames[1].Length - 1));
            int idDepartureAirport = dbConnexion.GetAirportId(departureAirport);
            int idArrivalAirport = dbConnexion.GetAirportId(arrivalAirport);
            int idLine = dbConnexion.GetLineId(idDepartureAirport, idArrivalAirport);
            dbConnexion.AddFlight(flight, idLine);
            MessageBox.Show("Le vol a bien été ajouté");
        }

        private void cmdAjouterLigne_Click(object sender, EventArgs e)
        {

            try
            {
                //If all conditions are satisfied add a line
                if(!DoesDistanceBeginWith0(txtDistance.Text) && DoesDistanceContainsOnlyNumbers(txtDistance.Text) && AreLineFieldsFilled() && !AreDepartureAirportAndArrivalAirportEqual())
                {
                    Airport departureAirport = new Airport(cboLieuDepart.SelectedItem.ToString());
                    Airport arrivalAirport = new Airport(cboLieuArrivee.SelectedItem.ToString());
                    int idDepartureAirport = dbConnexion.GetAirportId(departureAirport);
                    int idArrivalAirport = dbConnexion.GetAirportId(arrivalAirport);
                    line = new Line(idDepartureAirport, idArrivalAirport, int.Parse(txtDistance.Text));
                    Line line1 = new Line(idArrivalAirport, idDepartureAirport, int.Parse(txtDistance.Text));
                    dbConnexion.AddLine(line);
                    dbConnexion.AddLine(line1);
                    MessageBox.Show("La ligne a bien été ajoutée, une ligne retour a aussi été ajoutée");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmGestion_Load(object sender, EventArgs e)
        {
            cmdAjouterVol.Enabled = false;
            //Add airportsNames in comboboxes
            airportList = dbConnexion.GetAirportsNames();
            airportList.ForEach(delegate (String airport)
                {
                    cboAeroportAffectation.Items.Add(airport);
                    cboLieuArrivee.Items.Add(airport);
                    cboLieuDepart.Items.Add(airport);
                });
            List<string> lineList = dbConnexion.GetLinesNames();
            lineList.ForEach(delegate (string line)
            {
                cboLigne.Items.Add(line);
            });
        }

        #region checkPilotFiedls
        /// <summary>
        /// Throw exception if string does not contains only letters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool DoesStringContainsOnlyLetters(string input)
        {
            bool output = Regex.IsMatch(input, @"^[a-zA-Z]+$");
            if (!output)
            {
                Exception exception = new Exception("Le prénom/nom ne contient pas uniquement des lettres");
                throw exception;
            }
            return output;
        }

        /// <summary>
        /// Throw exception if string contains others chars than numbers
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
        /// Throw exception if a requiered field is empty
        /// </summary>
        /// <returns></returns>
        private bool ArePilotFieldsFilled()
        {
            bool output = false;
            if (txtNom.Text != string.Empty && txtPrenom.Text != string.Empty && txtHeuresVol.Text != string.Empty && cboAeroportAffectation.SelectedIndex > -1)
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
        /// Throw exception if pilotNameLength or pilotFirstNameLength are higher than 45 chars;
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
        /// Throw exception if FlightTime begins with 0
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool DoesFlightTimeBeginWith0(string input)
        {
            bool output;
            string firstLetter = input.Substring(0, 1);
            if(firstLetter == "0")
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
        /*PAS UTILE PARCE QUE '-' N'EST PSA UN NOMBRE DONC DEJA GERE PAR UNE AUTRE EXCEPTION
        /// <summary>
        /// Throw exception if FlightTime is a negative number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsFlightTimeAPositiveNumber(string input)
        {
            bool output = false;
            if (DoesDistanceContainsOnlyNumbers(input))
            {
                int distance = int.Parse(input);
                if (distance > 0)
                {
                    output = true;
                }
                else
                {
                    output = false;
                    Exception exception = new Exception("La distance doit etre un nomnre positif");
                    throw exception;
                }
            }
            return output;
        }*/
        #endregion

        #region checkLineFields
        /// <summary>
        /// Throw exception if Distance begins with 0
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
        /// Throw exception if distance contains others chars than numbers
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
        /// Throw exception if a field isnt filled
        /// </summary>
        /// <returns></returns>
        private bool AreLineFieldsFilled()
        {
            bool output = false;
            if(cboLieuArrivee.SelectedIndex >-1 && cboLieuDepart.SelectedIndex > -1 && txtDistance.Text != string.Empty)
            {
                output = true;
            }
            else if(cboLieuArrivee.SelectedIndex == -1 || cboLieuDepart.SelectedIndex == -1)
            {
                output = false;
                Exception exception = new Exception("Veuillez sélectionner un lieu de départ et un lieu d'arrivée");
                throw exception;
            }
            else if(txtDistance.Text == string.Empty)
            {
                output = false;
                Exception exception = new Exception("Veuillez indiquer une distance");
                throw exception;
            }
            return output;
        }
        /// <summary>
        /// Throw exception if DepartureAirport and ArrivalAirport are the same
        /// </summary>
        /// <returns></returns>
        private bool AreDepartureAirportAndArrivalAirportEqual()
        {
            bool output;
            if(cboLieuArrivee.SelectedItem.ToString() == cboLieuDepart.SelectedItem.ToString())
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


        /*PAS UTILE PARCE QUE LE '-' EST PAS UN CHIFFRE DONC DEJA GERE PAR AUTRE EXCEPTION
        /// <summary>
        /// Throw exception if distance is a negative number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsDistanceAPositiveNumber(string input)
        {
            bool output = false;
            if (DoesDistanceContainsOnlyNumbers(input))
            {
                int distance = int.Parse(input);
                if(distance > 0)
                {
                    output = true;
                }
                else
                {
                    output = false;
                    Exception exception = new Exception("La distance doit etre un nomnre positif");
                    throw exception;
                }
            }
            return output;
        }*/
        #endregion

        private void cmdDateArrivee_Click(object sender, EventArgs e)
        {
            try
            {
                if (AreFlightFieldsFilled())
                {
                    if(dtpDateDepart.Value.Year == DateTime.Now.Year && dtpDateDepart.Value.Month == DateTime.Now.Month && dtpDateDepart.Value.Day == DateTime.Now.Day)
                    {
                        if(MessageBox.Show("La date du vol n'a pas été modifiée cela vous convient-il ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    if(nudHDepart.Value == 0 && nudHArrivee.Value == 0)
                    {
                        if (MessageBox.Show("L'heure du vol n'a pas été modifiée cela vous convient-il ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    int departureH = (int)nudHDepart.Value;
                    string sDepartureH = departureH.ToString();
                    int departureM = (int)nudMDepart.Value;
                    string sDepartureM = departureM.ToString();
                    int arrivalH = (int)nudHArrivee.Value;
                    int arrivalM = (int)nudHArrivee.Value;
                    if (departureH < 10)
                    {
                        sDepartureH = "0" + departureH;
                    }
                    if (departureM < 10)
                    {
                        sDepartureM = "0" + departureM;
                    }
                    string[] airportsNames = cboLigne.SelectedItem.ToString().Split('/');
                    Airport departureAirport = new Airport(airportsNames[0]);
                    Airport arrivalAirport = new Airport(airportsNames[1].Substring(1, airportsNames[1].Length - 1));
                    string departureAirportAcronym = dbConnexion.GetAirportAcronym(departureAirport);
                    string arrivalAirportAcronym = dbConnexion.GetAirportAcronym(arrivalAirport);

                    int idDepartureAirport = dbConnexion.GetAirportId(departureAirport);
                    int idArrivalAirport = dbConnexion.GetAirportId(arrivalAirport);

                    int lineDistance = dbConnexion.GetLineDistance(idDepartureAirport, idArrivalAirport);
                    line = new Line(idDepartureAirport, idArrivalAirport, lineDistance);
                    int idLine = dbConnexion.GetLineId(idDepartureAirport, idArrivalAirport);
                    int departureYear = dtpDateDepart.Value.Year;
                    int departureMonth = dtpDateDepart.Value.Month;
                    string sDepartureMonth = departureMonth.ToString();
                    int departureDay = dtpDateDepart.Value.Day;
                    string sDepartureDay = departureDay.ToString();
                    if (departureMonth < 10)
                    {
                        sDepartureMonth = "0" + departureMonth;
                    }
                    if (departureDay < 10)
                    {
                        sDepartureDay = "0" + departureDay;
                    }
                    string flightName = departureAirportAcronym + arrivalAirportAcronym + dtpDateDepart.Value.Year + sDepartureMonth + sDepartureDay + sDepartureH + sDepartureM;

                    DateTime departureDate = new DateTime(dtpDateDepart.Value.Year, dtpDateDepart.Value.Month, dtpDateDepart.Value.Day, departureH, departureM, 0, 0);

                    MessageBox.Show(departureDate.ToString());

                    flight = new Flight(flightName, departureDate, line);

                    nudHArrivee.Value = flight.ArrivalDate.Hour;
                    nudMArrivee.Value = flight.ArrivalDate.Minute;
                    dtpDateArrivee.Value = flight.ArrivalDate;
                    cmdAjouterVol.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboLigne_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAjouterVol.Enabled = false;
        }

        private void nudHDepart_ValueChanged(object sender, EventArgs e)
        {
            cmdAjouterVol.Enabled = false;
        }

        private void nudMDepart_ValueChanged(object sender, EventArgs e)
        {
            cmdAjouterVol.Enabled = false;
        }

        private void dtpDateDepart_ValueChanged(object sender, EventArgs e)
        {
            cmdAjouterVol.Enabled = false;
        }

        private bool AreFlightFieldsFilled()
        {
            bool output;
            if(cboLigne.SelectedIndex > -1 )
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
    }
}
