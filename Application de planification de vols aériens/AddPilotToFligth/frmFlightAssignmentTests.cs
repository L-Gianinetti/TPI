using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application_de_planification_de_vols_aériens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_de_planification_de_vols_aériens.Tests
{
    [TestClass()]
    public class frmFlightAssignmentTests
    {
        DBConnection dbConnection = new DBConnection();
        [TestMethod()]
        public void addPilotToFlightTest()
        {
            //prep

            int idAirport = 1;
            Airport airport = new Airport("Saint-Gall-Altenrhein");
            //Create a unique Name with numbers for the test
            Pilot pilot = new Pilot("GianinettiTest0", "LucasTest0", 250, airport);
            DateTime departureDate = new DateTime(2018, 05, 29, 0, 0, 0);
            Line line = new Line(1, 2, 900);
            Flight flight = new Flight("ACHAN201805290000", departureDate, line);

            //exec
            dbConnection.AddLine(line);
            int idLine = dbConnection.GetLineId(1, 2);
            dbConnection.AddPilot(pilot, idAirport);
            dbConnection.AddFlight(flight,idLine);
            int idPilot = dbConnection.GetIdPilot(pilot.FirstName, pilot.Name);
            int idFlight = dbConnection.GetFlightId(flight.Name);
            

            dbConnection.AddPilotToFlight(idPilot, idFlight);
            int idPilotCalculated = dbConnection.GetIdPilotFlightHasPilot(idPilot, idFlight);
            int idFlightCalculated = dbConnection.GetIdFlightFlightHasPilot(idPilot, idFlight);

            //check
            Assert.AreEqual(idPilot, idPilotCalculated);
            Assert.AreEqual(idFlight, idFlightCalculated);
        }
    }
}