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

        #region insert

        /// <summary>
        /// Add a vacation for a Pilot in db
        /// </summary>
        /// <param name="idPilot"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
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

        /// <summary>
        /// Add a pilot in db
        /// </summary>
        /// Pilot contains pilotName, pilotFirstName, flightTime
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
                if (test < 0)
                {
                    throw new Exception("SQL syntax is correct, 0 row inserted");
                }
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new MySQLException("Erreur lors de l'ajout du pilote");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new MySQLException("Erreur lors de l'ajout du pilote");
            }
            

        }

        /// <summary>
        /// Add a flight in db
        /// </summary>
        /// <param name="flight"></param>
        /// Flight contains flightName, departureDate, arrivalDate
        public void AddFlight(Flight flight, int idLine)
        {
            try
            {
                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "INSERT INTO flight(flightName,departureDate,arrivalDate,fkLine) VALUES(@flightName,@departureDate,@arrivalDate,@fkLine)";
                cmd.Parameters.AddWithValue("@flightName", flight.Name);
                cmd.Parameters.AddWithValue("@departureDate", flight.DepartureDate);
                cmd.Parameters.AddWithValue("@arrivalDate", flight.ArrivalDate);
                cmd.Parameters.AddWithValue("@fkLine", idLine);

                int test = cmd.ExecuteNonQuery();
                if (test < 0)
                {
                    throw new Exception("SQL syntax is correct, 0 row inserted");
                }
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new  MySQLException("Erreur lors de l'ajout d'un vol");
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new MySQLException("Erreur lors de l'ajout d'un vol");              
            }
            this.connection.Close();
        }

        /// <summary>
        /// Add a pilot to a flight
        /// </summary>
        /// <param name="idPilot"></param>
        /// <param name="idFlight"></param>
        public void AddPilotToFlight(int idPilot, int idFlight)
        {
            try
            {
                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "INSERT INTO flight_has_pilot(fkFlight,fkPilot) VALUES(@fkFlight,@fkPilot)";
                cmd.Parameters.AddWithValue("@fkFlight", idFlight);
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
                throw new MySQLException("Erreur lors de l'ajout d'un pilote a un vol");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new MySQLException("Erreur lors de l'ajout d'un pilote a un vol");
            }
        }

        /// <summary>
        /// add a line in db
        /// </summary>
        /// <param name="line"></param>
        /// Line contains distance, fkDepartureAirport, fkArrivalAirport
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
                throw new MySQLException("Erreur lors de l'ajout d'une ligne");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new MySQLException("Erreur lors de l'ajout d'une ligne");
            }
        }

        #endregion

        #region update

        /// <summary>
        /// Update pilot fkAirportCurrentLocation from idPilot and idAirport
        /// </summary>
        /// <param name="idPilot"></param>
        /// <param name="idArrivalAirport"></param>
        public void UpdatePilotCurrentLocation(int idPilot, int idArrivalAirport)
        {
            this.connection.Close();
            //open SQL connection
            this.connection.Open();

            //Create SQL command
            MySqlCommand cmd = this.connection.CreateCommand();

            //SQL Query
            cmd.CommandText = "UPDATE pilot SET fkAirportCurrentLocation =\"" + idArrivalAirport + "\" where idPilot =\"" + idPilot + "\"";

            //Execute SQL Query
            cmd.ExecuteNonQuery();
            //close SQL connection
            this.connection.Close();
        }

        public void UpdatePilotFlightTime(int idPilot, float flightTime)
        {
            this.connection.Close();
            //open SQL connection
            this.connection.Open();

            //Create SQL command
            MySqlCommand cmd = this.connection.CreateCommand();

            //SQL Query
            cmd.CommandText = "UPDATE pilot SET flightTime =\"" + flightTime + "\" where idPilot =\"" + idPilot + "\"";

            //Execute SQL Query
            cmd.ExecuteNonQuery();
            //close SQL connection
            this.connection.Close();
        }
        #endregion


        #region select

        #region pilot

        

        public List<string> GetIdVacationIfPilotIsInVacation(int idPilot, string day)
        {
            List<string> idVacation = new List<string>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idVacation from vacation  where fkPilot =\"" + idPilot + "\" and startDate like \"" + day + "\" or fkPilot =\"" + idPilot + "\" and endDate like \"" + day + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();


                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    idVacation.Add(string.Format("{0}", cmdReader[0]));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return idVacation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPilot"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public List<string> GetFlightNameIfPilotWorks(int idPilot, string day)
        {
            List<string> flightName = new List<string>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT flightName, arrivalDate from flight inner join flight_has_pilot on fkFlight = idFlight where fkPilot =\"" + idPilot + "\" and departureDate like \"" + day +"\" or fkPilot =\"" + idPilot + "\" and arrivalDate like \"" + day +"\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();


                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    string test = cmdReader["flightName"].ToString() + " - " + cmdReader["arrivalDate"].ToString();
                    flightName.Add(string.Format(test));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flightName;
        }

        /// <summary>
        /// Test method :Return idFlight if pilot is assigned to flight
        /// </summary>
        /// <param name="idPilot"> pilot's id</param>
        /// <param name="idFlight">flight's id</param>
        /// <returns>return flight's id</returns>
        public int GetIdFlightFlightHasPilot(int idPilot, int idFlight)
        {
            string reponse = string.Empty;
            int output = 0;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT fkFlight from flight_has_pilot where fkPilot =\"" + idPilot + "\" and fkFlight =\"" + idFlight + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (reponse != "0")
            {
                output = int.Parse(reponse);
            }
            return output;
        }

        /// <summary>
        /// Test method :Return idPilot if pilot is assigned to flight
        /// </summary>
        /// <param name="idPilot"> pilot's id</param>
        /// <param name="idFlight">flight's id</param>
        /// <returns>id of the pilot</returns>
        public int GetIdPilotFlightHasPilot(int idPilot, int idFlight)
        {
            string reponse = string.Empty;
            int output = 0;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT fkPilot from flight_has_pilot where fkPilot =\"" + idPilot + "\" and fkFlight =\"" + idFlight +"\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (reponse != "0")
            {
                output = int.Parse(reponse);
            }
            return output;
        }

        /// <summary>
        /// Test method :Return idPilot from pilot's firstname and pilot's lastname
        /// </summary>
        /// <param name="firstname">pilot's firstname</param>
        /// <param name="name">pilot's lastname</param>
        /// <returns>pilot's id</returns>
        public int GetIdPilot(string firstname, string name)
        {
            string reponse = string.Empty;
            int output = 0;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idPilot from pilot where pilotName =\"" + name + "\" and pilotFirstName =\"" + firstname +"\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (reponse != "0")
            {
                output = int.Parse(reponse);
            }
            return output;
        }

        public float GetPilotFlightTime(int idPilot)
        {
            string reponse = string.Empty;
            float output = 0;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT flightTime from pilot where idPilot =\"" + idPilot + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (reponse != "0")
            {
                output = float.Parse(reponse);
            }
            return output;
        }

        public int GetIdPilotIfPilotIsWorking(DateTime departureDate, DateTime arrivalDate, int idPilot)
        {
            string reponse = string.Empty;
            int output = 0;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idPilot from pilot  inner join flight_has_pilot on idPilot = fkPilot inner join flight on fkFlight = idFlight where departureDate <=\"" + departureDate + "\" and arrivalDate >=\"" + departureDate +"\" and idPilot =\"" + idPilot + "\" or departureDate <=\"" + arrivalDate + "\" and arrivalDate >=\"" + arrivalDate + "\" and idPilot =\"" + idPilot + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(reponse != string.Empty)
            {
                output = int.Parse(reponse);
            }
            return output;
        }


        public List<string> GetPilotEndWorkDates(int idPilot)
        {
            List<string> workDates = new List<string>();
            try
            {
                //TODO A VERIFIER
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT arrivalDate from flight inner join flight_has_pilot on idFlight = fkFlight  where fkPilot =\"" + idPilot + "\" ";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    workDates.Add(string.Format("{0}", cmdReader[0]));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return workDates;
        }

        public List<string> GetPilotStartWorkDates(int idPilot)
        {
            List<string> workDates = new List<string>();
            try
            {
                //TODO A VERIFIER
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT departureDate from flight inner join flight_has_pilot on idFlight = fkFlight  where fkPilot =\"" + idPilot + "\" ";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    workDates.Add(string.Format("{0}", cmdReader[0]));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return workDates;
        }

        public List<DateTime> GetPilotEndWorkDatesThisWeek(string monday, string sunday)
        {
            List<DateTime> endWork = new List<DateTime>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT arrivalDate from flight_has_pilot  inner join flight on fkFlight = idFlight where arrivalDate >=\"" + monday + "\" and arrivalDate <=\"" + sunday + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    endWork.Add(DateTime.Parse(cmdReader[0].ToString()));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return endWork;
        }

        public List<DateTime> GetPilotStartWorkDatesThisWeek(string monday, string sunday)
        {
            List<DateTime> startWork = new List<DateTime>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT departureDate from flight_has_pilot  inner join flight on fkFlight = idFlight where departureDate >=\"" + monday + "\" and departureDate <=\"" +  sunday + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    startWork.Add(DateTime.Parse(cmdReader[0].ToString()));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return startWork;
        }

        /// <summary>
        /// Return pilots assigned to a specific flight in a List string
        /// </summary>
        /// <param name="idFlight"></param>
        /// <returns></returns>
        public List<string> GetIdPilotsFromFlight(int idFlight)
        {
            List<string> pilotsFromFlight = new List<string>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT fkPilot from flight_has_pilot where fkFlight =\"" + idFlight + "\"";

                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();

                while (cmdReader.Read())
                {
                    pilotsFromFlight.Add(string.Format("{0}", cmdReader[0]));
                }
                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pilotsFromFlight;

        }

        /// <summary>
        /// Return all the existing pilots in a List Pilot
        /// </summary>
        /// <returns></returns>
        public List<Pilot> GetPilots()
        {
            List<Pilot> pilots = new List<Pilot>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idPilot,pilotName, pilotFirstName, flightTime, airportName from pilot inner join airport on fkAirport = idAirport";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    pilots.Add(new Pilot(int.Parse(cmdReader[0].ToString()), cmdReader[1].ToString(), cmdReader[2].ToString(), float.Parse(cmdReader[3].ToString()), cmdReader[4].ToString()));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pilots;
        }

        /// <summary>
        /// Return pilotFirstName from idPilot
        /// </summary>
        /// <param name="idPilot"></param>
        /// <returns></returns>
        public string GetPilotFirstName(int idPilot)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT pilotFirstName from pilot where idPilot =\"" + idPilot + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();


                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return reponse;
        }

        /// <summary>
        /// Return pilotName from idPilot
        /// </summary>
        /// <param name="idPilot"></param>
        /// <returns></returns>
        public string GetPilotName(int idPilot)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT pilotName from pilot where idPilot =\"" + idPilot + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();


                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return reponse;
        }


        /// <summary>
        /// Return idAssignmentAirport from idPilot
        /// </summary>
        /// <param name="idPilot"></param>
        /// <returns></returns>
        public int GetPilotAssignmentAirportId(int idPilot)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT fkAirport from pilot where idPilot =\"" + idPilot + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();


                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return int.Parse(reponse);
        }

        /// <summary>
        /// Return idAirport of a pilot's current airport location from idPilot
        /// </summary>
        /// <param name="idPilot"></param>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public int GetPilotCurrentLocation(int idPilot, string currentDate)
        {
            string idAirport = string.Empty;
            int reponse = 0;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT fkArrivalAirport from flight_has_pilot inner join flight on idFlight = fkFlight inner join line on idLine = fkLine where fkPilot =\"" + idPilot + "\"  and arrivalDate <\"" + currentDate + "\" order by arrivalDate desc limit 1";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    idAirport = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(idAirport != string.Empty)
            {
                reponse =  int.Parse(idAirport);
            }
            return reponse;
        }

        

        /// <summary>
        /// Return pilots' id from all existing pilots in a List string
        /// </summary>
        /// <returns></returns>
        public List<string> GetPilotsId()
        {
            List<string> pilots = new List<string>();
            try
            {
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idPilot from pilot order by idPilot";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    pilots.Add(string.Format("{0}", cmdReader[0]));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return pilots;
        }

        /// <summary>
        /// Return pilots' id from a sepcific airportId in List string
        /// </summary>
        /// <param name="airportId"></param>
        /// <returns></returns>
        public List<string> GetPilotsId(int airportId)
        {
            List<string> pilots = new List<string>();
            try
            {
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idPilot from pilot where fkAirportCurrentLocation =\"" + airportId + "\" order by idPilot";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    pilots.Add(string.Format("{0}", cmdReader[0]));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return pilots;
        }




        /// <summary>
        /// Return pilotFirstName from a specific airportId in List string
        /// </summary>
        /// <param name="airportId"></param>
        /// <returns></returns>
        public List<string> GetPilotsFirstName(int airportId)
        {
            List<string> pilots = new List<string>();
            try
            {
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT pilotFirstName from pilot where fkAirportCurrentLocation =\"" + airportId + "\" order by idPilot";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    pilots.Add(string.Format("{0}", cmdReader[0]));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return pilots;
        }

        /// <summary>
        /// Return pilotName from a specific airportId in List string
        /// </summary>
        /// <param name="airportId"></param>
        /// <returns></returns>
        public List<string> GetPilotsName(int airportId)
        {
            List<string> pilots = new List<string>();
            try
            {
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT pilotName from pilot where fkAirportCurrentLocation =\"" + airportId + "\" order by idPilot";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    pilots.Add(string.Format("{0}", cmdReader[0]));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return pilots;
        }

        /// <summary>
        /// Return idPilot if pilot is in vacation between departureDate and arrivalDate
        /// </summary>
        /// <param name="departureDate"></param>
        /// <param name="arrivalDate"></param>
        /// <returns></returns>
        public int GetIdPilotInVacationDuringFlight(string departureDate, string arrivalDate )
        {
            int reponse = 0;
            string idPilot = string.Empty;
            try
            {
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT fkPilot from vacation where startDate <=\"" + departureDate + "\" and endDate >= \"" + departureDate + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    idPilot = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }

            if(idPilot != string.Empty)
            {
                reponse = int.Parse(idPilot);
            }

            return reponse;
        }

        /// <summary>
        /// Return Pilot last arrival time from idPilot
        /// </summary>
        /// <param name="idPilot"></param>
        /// <param name="departureDate"></param>
        /// <returns></returns>
        public DateTime GetPilotLastArrivalTime(int idPilot, DateTime departureDate)
        {
            DateTime lastArrivalTime = new DateTime();
            try
            {
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT arrivalDate from flight_has_pilot inner join flight on idFlight = fkFlight where fkPilot =\"" + idPilot + "\" and arrivalDate < \"" + departureDate + "\" order by arrivalDate desc limit 1";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    lastArrivalTime = DateTime.Parse(cmdReader[0].ToString());
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return lastArrivalTime;
        }

        /// <summary>
        /// Return vacationEndDates for a specific pilot in a List string
        /// </summary>
        /// <param name="idPilot"></param>
        /// <returns></returns>
        public List<string> GetVacationEndDates(int idPilot)
        {
            List<string> vacations = new List<string>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT endDate from vacation where fkPilot =\"" + idPilot + "\" order by idVacation";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    vacations.Add(string.Format("{0}", cmdReader[0]));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return vacations;
        }


        /// <summary>
        /// Return vacationStartDates for a specific pilot in a List string
        /// </summary>
        /// <param name="idPilot"></param>
        /// <returns></returns>
        public List<string> GetVacationStartDates(int idPilot)
        {
            List<string> vacations = new List<string>();
            try
            {
                //TODO A VERIFIER
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT startDate from vacation where fkPilot =\"" + idPilot + "\" order by idVacation";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    vacations.Add(string.Format("{0}", cmdReader[0]));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return vacations;
        }
        #endregion

        #region airport

        public string GetArrivalAirportName(int idLine)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT airportName from airport inner join line on fkArrivalAirport = idAirport where idLine =\"" + idLine + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }

            return reponse;
        }

        public string GetDepartureAirportName(int idLine)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT airportName from airport inner join line on fkDepartureAirport = idAirport where idLine =\"" + idLine + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }

            return reponse;
        }

        /// <summary>
        /// Return airportName from an idAirport
        /// </summary>
        /// <param name="idAirport"></param>
        /// <returns></returns>
        public string GetAirportName(int idAirport)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT airportName from airport where idAirport =\"" + idAirport + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }

            return reponse;
        }

        public string GetAirportType(string airportName)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT type from airportType inner join airport on fkAirportType = idAirportType where airportName =\"" + airportName + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return reponse;
        }

        public List<string> GetAirportsTypes()
        {
            List<string> reponse = new List<string>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT type from airport inner join airportType on fkAirportType = idAirportType order by idAirport";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse.Add(string.Format("{0}", cmdReader[0]));
                }
                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return reponse;
        }

        /// <summary>
        /// Return all the airportNames in a List string
        /// </summary>
        /// <returns></returns>
        public List<string> GetAirportsNames()
        {
            List<string> reponse = new List<string>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT airportName from airport order by idAirport";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse.Add(string.Format("{0}",cmdReader[0]));
                }
                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return reponse;
        }

        /// <summary>
        /// Return airportAcronym from an airportName
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        public string GetAirportAcronym(Airport airport)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT airportAcronym from airport where airportName =\"" + airport.Name + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }
                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return reponse;
        }

        /// <summary>
        /// Return airportId from an airportAcronym
        /// </summary>
        /// <param name="acronym"></param>
        /// <returns></returns>
        public int GetAirportId(string acronym)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idAirport from airport where airportAcronym =\"" + acronym + "\"";

                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Int32.Parse(reponse);
        }

        /// <summary>
        /// Return airportId from an airportName
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        public int GetAirportId(Airport airport)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idAirport from airport where airportName =\"" + airport.Name + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }
                //close SQL connection
                this.connection.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Int32.Parse(reponse);
        }

        #endregion

        #region flight

        public List<string> GetDistanceFromFlight(int idPilot, string lastClosedDate, string currentDate)
        {
            List<string> reponse = new List<string>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "select distance from line inner join flight on fkLine = idLine inner join flight_has_pilot on fkFlight = idFlight where fkPilot =\"" + idPilot +"\" and arrivalDate >\"" + lastClosedDate +"\" and arrivalDate <\"" + currentDate +"\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse.Add(string.Format("{0}", cmdReader[0]));
                }
                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return reponse;
        }

        /// <summary>
        /// Return Flight from flightName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Flight GetFlight(string name)
        {
            Flight flight = new Flight();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idFlight,departureDate, arrivalDate, fkLine from flight where flightName =\"" + name + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    flight = new Flight(int.Parse(cmdReader[0].ToString()), name, cmdReader[1].ToString(), cmdReader[2].ToString(), int.Parse(cmdReader[3].ToString()));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flight;
        }

        /// <summary>
        /// Return all existing flights in a List Flight
        /// </summary>
        /// <returns></returns>
        public List<Flight> GetFlights()
        {
            List<Flight> flights = new List<Flight>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idFlight, flightName,departureDate, arrivalDate, fkLine from flight inner join line on fkLine = idLine";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    flights.Add(new Flight(int.Parse(cmdReader[0].ToString()), cmdReader[1].ToString(), cmdReader[2].ToString(), cmdReader[3].ToString(), int.Parse(cmdReader[4].ToString())));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flights;
        }

        /// <summary>
        /// Return idFlight from flightName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetFlightId(string name)
        {
            int output = 0;
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idFlight from flight where flightName =\"" + name + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();


                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(reponse != string.Empty)
            {
                output = int.Parse(reponse);
            }
            return output;
        }

        #endregion

        #region line

        /// <summary>
        /// Return all "lines names" (departureAirportName / arrivalAirportName) in a List string
        /// </summary>
        /// <returns></returns>
        public List<string> GetLinesNames()
        {
            List<string> reponse = new List<string>();
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT b.airportName as ArrivalAirport, c.airportName as DepartureAirport from  line a inner join airport c on fkDepartureAirport = c.idAirport inner join airport b on fkArrivalAirport = b.idAirport order by idLine";


                //Execute SQL Query
                cmd.ExecuteNonQuery();

                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    reponse.Add(string.Format("{0}/{1}", cmdReader[0], cmdReader[1]));
                }
                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return reponse;
        }

        /// <summary>
        /// Return all existing lines
        /// </summary>
        /// <returns></returns>
        public List<Line> GetLines()
        {
            List<Line> lines = new List<Line>();
            try
            {
                //ouverture de la connexion SQL
                //TODO regarder erreure
                this.connection.Close();
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idLine, distance, fkDepartureAirport, fkArrivalAirport  from line";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    lines.Add(new Line(int.Parse(cmdReader[0].ToString()), int.Parse(cmdReader[1].ToString()), int.Parse(cmdReader[2].ToString()), int.Parse(cmdReader[3].ToString())));
                }

                //close SQL connection
                this.connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lines;
        }

        /// <summary>
        /// Return line's distance from idLine
        /// </summary>
        /// <param name="idLine"></param>
        /// <returns></returns>
        public int GetLineDistance(int idLine)
        {
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT distance from line where idLine =\"" + idLine + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);

                }

                //close SQL connection
                this.connection.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Int32.Parse(reponse);
        }

        /// <summary>
        /// Return line's distance from fkDepartureAirport and fkArrivalAirport
        /// </summary>
        /// <param name="idDepartureAirport"></param>
        /// <param name="idArrivalAirport"></param>
        /// <returns></returns>
        public int GetLineDistance(int idDepartureAirport, int idArrivalAirport)
        {
            int output = 0;
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT distance from line where fkDepartureAirport =\"" + idDepartureAirport + "\" and fkArrivalAirport =\"" + idArrivalAirport + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);

                }

                //close SQL connection
                this.connection.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(reponse != string.Empty)
            {
                output = int.Parse(reponse);
            }
            return output;
        }

        /// <summary>
        /// Return line's id from fkDepartureAirport, fkArrivalAirport
        /// </summary>
        /// <param name="idDepartureAirport"></param>
        /// <param name="idArrivalAirport"></param>
        /// <returns></returns>
        public int GetLineId(int idDepartureAirport, int idArrivalAirport)
        {
            int output = 0;
            string reponse = string.Empty;
            try
            {
                //open SQL connection
                this.connection.Open();

                //Create SQL command
                MySqlCommand cmd = this.connection.CreateCommand();

                //SQL Query
                cmd.CommandText = "SELECT idLine from line where fkDepartureAirport =\"" + idDepartureAirport + "\" and fkArrivalAirport =\"" + idArrivalAirport + "\"";


                //Execute SQL Query
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                if (cmdReader.Read())
                {
                    reponse = String.Format("{0}", cmdReader[0]);

                }

                //close SQL connection
                this.connection.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(reponse != string.Empty)
            {
                output = int.Parse(reponse);
            }
            return output;
        }

        #endregion

        #endregion





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

                //SQL Query
                cmd.CommandText = "SELECT b.airportName as ArrivalAirport, c.airportName as DepartureAirport from  line a inner join airport c on fkDepartureAirport = c.idAirport inner join airport b on fkArrivalAirport = b.idAirport where idLine =\"" + idLine + " order by idLine";


                //Execute SQL Query
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

                //SQL Query
                cmd.CommandText = "SELECT startDate, endDate from vacation where fkPilot =\"" + idFlight + "";


                //Execute SQL Query
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























    }
}
