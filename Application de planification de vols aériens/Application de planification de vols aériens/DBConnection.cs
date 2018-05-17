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
            try
            {
                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "INSERT INTO pilot(pilotName,pilotFirstName,flightTime,fkAirport,fkAirportCurrentLocation) VALUES(@pilotName,@pilotFirstName,@flightTime,@fkAirport,@fkAirportCurrentLocation)";
                cmd.Parameters.AddWithValue("@pilotName", pilot.Name);
                cmd.Parameters.AddWithValue("@pilotFirstName", pilot.FirstName);
                cmd.Parameters.AddWithValue("@flightTime", pilot.FlightTime);
                cmd.Parameters.AddWithValue("@fkAirport", idAirport);
                cmd.Parameters.AddWithValue("@fkAirportCurrentLocation", idAirport);
                int test = cmd.ExecuteNonQuery();
                if(test < 0)
                {
                    throw new Exception("SQL syntax is correct, 0 row inserted");
                }
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        /// <summary>
        /// Add a flight in db
        /// </summary>
        /// <param name="flight"></param>
        public void AddFlight(Flight flight, int idLine)
        {
            try
            {
                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "INSERT INTO flight(flightName,departureDate,arrivalDate,fkLine) VALUES(@flightName,@departureDate,@arrivalDate,@fkLine)";
                cmd.Parameters.AddWithValue("@flightName", flight.Name);
                cmd.Parameters.AddWithValue("@departureDate",flight.DepartureDate) ;
                cmd.Parameters.AddWithValue("@arrivalDate",flight.ArrivalDate );
                cmd.Parameters.AddWithValue("@fkLine", idLine);

                int test = cmd.ExecuteNonQuery();
                if (test < 0)
                {
                    throw new Exception("SQL syntax is correct, 0 row inserted");
                }
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// add a line in db
        /// </summary>
        /// <param name="line"></param>
        public void AddLine(Line line)
        {        
            try
            {
                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "INSERT INTO line(distance,fkDepartureAirport,fkArrivalAirport) VALUES(@distance,@fkDepartureAirport,@fkArrivalAirport)";
                cmd.Parameters.AddWithValue("@distance", line.Distance);
                cmd.Parameters.AddWithValue("@fkDepartureAirport", line.IdDepartureAirport);
                cmd.Parameters.AddWithValue("@fkArrivalAirport", line.IdArrivalAirport);
                int test = cmd.ExecuteNonQuery();
                if (test < 0)
                {
                    throw new Exception("SQL syntax is correct, 0 row inserted");
                }
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
            List<string> reponse = new List<string>();
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT airportName from airport";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse.Add(string.Format("{0}", cmdReader[0]));
                }


                this.connection.Close();
            }
            catch
            {

            }


            return reponse;
        }

        public string GetAirportAcronym(Airport airport)
        {
            string reponse = string.Empty;
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT airportAcronym from airport where airportName =\"" + airport.Name + "\"";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }


                this.connection.Close();
            }
            catch
            {

            }


            return reponse;
        }

        public int GetAirportId(Airport airport)
        {
            string reponse = string.Empty;
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT idAirport from airport where airportName =\"" + airport.Name + "\"";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                

                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);

                }


                this.connection.Close();
                
            }
            catch
            {

            }
            return Int32.Parse(reponse);
        }

        public List<string> GetLinesNames()
        {
            List<string> reponse = new List<string>();
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT b.airportName as ArrivalAirport, c.airportName as DepartureAirport from  line a inner join airport c on fkDepartureAirport = c.idAirport inner join airport b on fkArrivalAirport = b.idAirport order by idLine";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse.Add(string.Format("{0} / {1}", cmdReader[0], cmdReader[1]));
                }


                this.connection.Close();
            }
            catch
            {

            }
            return reponse;
        }
        #endregion


        #region Pilot
        
        public List<Pilot> GetPilots()
        {
            List<Pilot> pilots = new List<Pilot>();
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT pilotName, pilotFirstName, flightTime, airportName from pilot inner join airport on fkAirport = idAirport";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();


                
                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    pilots.Add(new Pilot(cmdReader[0].ToString(), cmdReader[1].ToString(),int.Parse(cmdReader[2].ToString()),cmdReader[3].ToString()));
                }


                this.connection.Close();
            }
            catch
            {

            }
            return pilots;
        }
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

        public int GetLineDistance(int idDepartureAirport, int idArrivalAirport)
        {
            string reponse = string.Empty;
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT distance from line where fkDepartureAirport =\"" + idDepartureAirport + "\" and fkArrivalAirport =\"" + idArrivalAirport +"\"";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);

                }


                this.connection.Close();

            }
            catch
            {

            }
            return Int32.Parse(reponse);
        }

        public int GetLineId(int idDepartureAirport, int idArrivalAirport)
        {
            string reponse = string.Empty;
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT idLine from line where fkDepartureAirport =\"" + idDepartureAirport + "\" and fkArrivalAirport =\"" + idArrivalAirport + "\"";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);

                }


                this.connection.Close();

            }
            catch
            {

            }
            return Int32.Parse(reponse);
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
