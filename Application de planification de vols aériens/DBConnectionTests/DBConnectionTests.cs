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
    public class DBConnectionTests
    {
        DBConnection dbConnection = new DBConnection();

        [TestMethod()]
        public void DBConnectionTest()
        {

        }

        [TestMethod()]
        public void AddPilotTest()
        {
            //prep
            Airport airport = new Airport("Aeroport international Saint-Gall-Altenrhein");
            Pilot pilot = new Pilot("Janssen", "Manu", 1000, airport);
            
        }

        [TestMethod()]
        public void AddFlightTest()
        {

        }

        [TestMethod()]
        public void AddLineTest()
        {

        }

        [TestMethod()]
        public void AddVacationTest()
        {

        }

        [TestMethod()]
        public void GetAirportNameTest()
        {

        }

        [TestMethod()]
        public void GetAirportIdTest()
        {
            //prep
            string airportName = "Aeroport international Saint-Gall-Altenrhein";
            Airport airport1 = new Airport(airportName);
            int idAirportAttendu = 1;

            //exec
            int idAirportCalcule = dbConnection.GetAirportId(airport1);

            //check
            Assert.AreEqual(idAirportAttendu, idAirportCalcule);
        }

        [TestMethod()]
        public void GetLineNameTest()
        {

        }

        [TestMethod()]
        public void GetPilotNameTest()
        {

        }

        [TestMethod()]
        public void GetPilotFirstNameTest()
        {

        }

        [TestMethod()]
        public void GetPilotAssignmentAirportTest()
        {

        }

        [TestMethod()]
        public void GetPilotFlightTimeTest()
        {

        }

        [TestMethod()]
        public void GetPilotCurrentLocationTest()
        {

        }

        [TestMethod()]
        public void GetPilotLastFlightDateTest()
        {

        }

        [TestMethod()]
        public void GetPilotFlightsDepartureDatesTest()
        {

        }

        [TestMethod()]
        public void GetPilotFlightsArrivalDatesTest()
        {

        }

        [TestMethod()]
        public void GetPilotIdTest()
        {

        }

        [TestMethod()]
        public void GetFlightNameTest()
        {

        }

        [TestMethod()]
        public void GetFlightLineTest()
        {

        }

        [TestMethod()]
        public void GetDepartureDateTest()
        {

        }

        [TestMethod()]
        public void GetArrivalDateTest()
        {

        }

        [TestMethod()]
        public void GetFlightPilotsTest()
        {

        }

        [TestMethod()]
        public void GetLineDepartureAirportTest()
        {

        }

        [TestMethod()]
        public void GetLineArrivalAirportTest()
        {

        }

        [TestMethod()]
        public void GetPilotVacationStartDateTest()
        {

        }

        [TestMethod()]
        public void GetPilotVacationEndDateTest()
        {

        }

        [TestMethod()]
        public void UpdatePilotCurrentLocationTest()
        {

        }

        [TestMethod()]
        public void UpdatePilotVacationTest()
        {

        }

        [TestMethod()]
        public void DeletePilotVacationTest()
        {

        }
    }
}