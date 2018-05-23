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

        public string GetAirportName(int idAirport)
        {
            string reponse = string.Empty;
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT airportName from airport where idAirport =\"" + idAirport + "\"";


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

        /// <summary>
        /// Retourne les noms des aéroports
        /// </summary>
        /// <returns></returns>
        public List<string> GetAirportsNames()
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
        /*
        public string GetLineName(int idLine)
        {
            string lineName = string.Empty;
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT b.airportName as ArrivalAirport, c.airportName as DepartureAirport from  line a inner join airport c on fkDepartureAirport = c.idAirport inner join airport b on fkArrivalAirport = b.idAirport where idLine =\"" + idLine + " order by idLine";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    lineName = String.Format("{0} / {1}", cmdReader[0], cmdReader[1]);

                }


                this.connection.Close();
            }
            catch
            {

            }
            return lineName;
        }*/

        #endregion


        #region Pilot
        /*
        public List<DateTime> GetVacation(int idPilot)
        {
            List<DateTime> vacation = new List<DateTime>();

            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT startDate, endDate from vacation where fkPilot =\"" + idFlight + "";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();


                var cmdReader = cmd.ExecuteReader();

                while (cmdReader.Read())
                {
                    pilotsFromFlight.Add(string.Format("{0}", cmdReader[0]));
                }

                this.connection.Close();
            }
            catch
            {

            }
            return pilotsFromFlight;
        }*/
        
        public void addVacation(int idPilot, DateTime startDate, DateTime endDate)
        {
            try
            {
                this.connection.Close();
                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();


                cmd.CommandText = "INSERT INTO vacation(startDate,endDate,fkPilot) VALUES(@startDate,@endDate,@fkPilot)";
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@fkPilot", idPilot);

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

        public List<string> GetPilotsFromFlight(int idFlight)
        {
            List<string> pilotsFromFlight = new List<string>();
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT fkPilot from flight_has_pilot where fkFlight =\"" + idFlight + "\"";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();


                var cmdReader = cmd.ExecuteReader();

                while (cmdReader.Read())
                {
                    pilotsFromFlight.Add(string.Format("{0}", cmdReader[0]));
                }
               
                this.connection.Close();
            }
            catch
            {

            }
            return pilotsFromFlight;

        }

        public List<string> GetVacationEndDates(int idPilot)
        {
            List<string> vacations = new List<string>();
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT endDate from vacation where fkPilot =\"" + idPilot + "\" order by idVacation";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    vacations.Add(string.Format("{0}", cmdReader[0]));
                }


                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return vacations;
        }

        public List<string> GetVacationStartDates(int idPilot)
        {
            List<string> vacations = new List<string>();
            try
            {
                this.connection.Close();
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT startDate from vacation where fkPilot =\"" + idPilot + "\" order by idVacation";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    vacations.Add(string.Format("{0}", cmdReader[0]));
                }


                this.connection.Close();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return vacations;
        }

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
                cmd.CommandText = "SELECT idPilot,pilotName, pilotFirstName, flightTime, airportName from pilot inner join airport on fkAirport = idAirport";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();


                
                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    pilots.Add(new Pilot(int.Parse(cmdReader[0].ToString()),cmdReader[1].ToString(), cmdReader[2].ToString(),int.Parse(cmdReader[3].ToString()),cmdReader[4].ToString()));
                }


                this.connection.Close();
            }
            catch
            {

            }
            return pilots;
        }

        public List<Flight> GetFlights()
        {
            List<Flight> flights = new List<Flight>();
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT idFlight, flightName,departureDate, arrivalDate, fkLine from flight inner join line on fkLine = idLine";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    flights.Add(new Flight(int.Parse(cmdReader[0].ToString()), cmdReader[1].ToString(),cmdReader[2].ToString(),cmdReader[3].ToString(),int.Parse(cmdReader[4].ToString())));
                }


                this.connection.Close();
            }
            catch
            {

            }
            return flights;
        }

        public string GetPilotFullName(int idPilot)
        {
            string reponse = string.Empty;
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT pilotName, pilotFirstName from pilot where idPilot =\"" + idPilot + "\"";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();


                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0-1}", cmdReader[0], cmdReader[1]);
                }


                this.connection.Close();
            }
            catch
            {

            }
            return reponse;
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
        
        public List<Line> GetLines()
        {
            List<Line> lines = new List<Line>();
            try
            {
                //ouverture de la connexion SQL
                //TODO regarder erreure
                this.connection.Close();
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT idLine, distance, fkDepartureAirport, fkArrivalAirport  from line";


                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    lines.Add(new Line(int.Parse(cmdReader[0].ToString()), int.Parse(cmdReader[1].ToString()), int.Parse(cmdReader[2].ToString()), int.Parse(cmdReader[3].ToString())));
                }


                this.connection.Close();
            }
            catch
            {

            }
            return lines;
        }

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
