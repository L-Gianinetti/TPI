using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Application_de_planification_de_vols_aériens
{
    public class DBConnection
    {
        private MySqlConnection connection;

        public DBConnection()
        {
            this.InitConnection();
        }
        private void InitConnection()
        {
            string connectionString = "SERVER=127.0.0.1;DATABASE=planificationvolsaeriens;UID=root;PASSWORD=";
            this.connection = new MySqlConnection(connectionString);
        }


        private void InitConnexion()
        {

        }

        #region Gestion

        /// <summary>
        /// Add a pilot in db
        /// </summary>
        /// <param name="pilot"></param>
        public void AddPilot(Pilot pilot, int idAirport)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO pilot(pilotName,pilotFirstName,flightTime,fkAirport,fkAirportCurrentLocation) VALUES(@pilotName,@pilotFirstName,@flightTime,@fkAirport,@fkAirportCurrentLocation)";
            cmd.Parameters.AddWithValue("@pilotName", pilot.Name);
            cmd.Parameters.AddWithValue("@pilotFirstName", pilot.FirstName);
            cmd.Parameters.AddWithValue("@flightTime", pilot.FlightTime);
            cmd.Parameters.AddWithValue("@fkAirport", idAirport);
            cmd.Parameters.AddWithValue("@fkAirportCurrentLocation", idAirport);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        /// <summary>
        /// Add a flight in db
        /// </summary>
        /// <param name="flight"></param>
        public void AddFlight(Flight flight)
        {

        }

        /// <summary>
        /// add a line in db
        /// </summary>
        /// <param name="line"></param>
        public void AddLine(Line line)
        {

        }

        /// <summary>
        /// add a vacation in db
        /// </summary>
        /// <param name="vacation"></param>
        public void AddVacation(Vacation vacation)
        {

        }

        /// <summary>
        /// Retourne les noms des aéroports
        /// </summary>
        /// <returns></returns>
        public List<string> GetAirportName()
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT airportName from airport";


            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            List<string> reponse = new List<string>();

            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                reponse.Add(string.Format("{0}", cmdReader[0]));
            }


            this.connection.Close();


            return reponse;
        }

        public int GetAirportId(Airport airport)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT idAirport from airport where airportName =\"" + airport.Name + "\"";


            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string reponse = string.Empty;

            var cmdReader = cmd.ExecuteReader();
            if (cmdReader.Read())
            {
                reponse = String.Format("{0}", cmdReader[0]);
            }


            this.connection.Close();

            int id = int.Parse(reponse);
            return id;
        }

        /// <summary>
        /// Retourne le nom d'une ligne
        /// </summary>
        /// <returns></returns>
        public string GetLineName()
        {
            return string.Empty;
        }

        #endregion


        #region Pilot
        /*
        public List<Pilot> GetPilots()
        {
            
        }*/
        public string GetPilotName()
        {
            return string.Empty;
        }

        public string GetPilotFirstName()
        {
            return string.Empty;
        }

        public string GetPilotAssignmentAirport()
        {
            return string.Empty;
        }

        public int GetPilotFlightTime()
        {
            return 0;
        }

        public string GetPilotCurrentLocation()
        {
            return string.Empty;
        }

        public DateTime GetPilotLastFlightDate()
        {
            return DateTime.Now;
        }

        public DateTime GetPilotFlightsDepartureDates()
        {
            return DateTime.Now;
        }

        public DateTime GetPilotFlightsArrivalDates()
        {
            return DateTime.Now;
        }


        public int GetPilotId(string pilotName)
        {
            return 0;
        }

        #endregion
        #region Flight

        /*
        public List<Flight> GetFlights()
        {
            
        }*/
        public string GetFlightName()
        {
            return string.Empty;
        }

        public string GetFlightLine()
        {
            return string.Empty;
        }

        public DateTime GetDepartureDate()
        {
            return DateTime.Now;
        }

        public DateTime GetArrivalDate()
        {
            return DateTime.Now;
        }

        public string GetFlightPilots()
        {
            return string.Empty;
        }


        #region Line
        /*
        public List<Line> GetLines()
        {
            return List<Line>;
        }*/

        public string GetLineDepartureAirport()
        {
            return string.Empty;
        }

        public string GetLineArrivalAirport()
        {
            return string.Empty;
        }

        #endregion

        #endregion


        #region Vacation

        public DateTime GetPilotVacationStartDate()
        {
            return DateTime.Now;
        }
        public DateTime GetPilotVacationEndDate()
        {
            return DateTime.Now;
        }
        #endregion


        public void UpdatePilotCurrentLocation(int idPilot)
        {

        }

        public void UpdatePilotVacation(int idPilot)
        {

        }

        public void DeletePilotVacation(int idPilot)
        {

        }







    }
}
