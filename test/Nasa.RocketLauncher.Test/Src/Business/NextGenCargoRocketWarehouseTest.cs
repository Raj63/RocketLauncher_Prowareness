using System;
using ExpectedObjects;
using Nasa.RocketLauncher.Business.Src.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nasa.RocketLauncher.Test
{
    [TestClass]
    public class NextGenCargoRocketWarehouseTest : TestBase
    {
        [DataTestMethod]
        [DataRow(true, "Apollo", "Moon")]
        [DataRow(false, "Apollo-1", "Mars")]
        [DataRow(true, "Cassineni", "Jupiter")]
        [DataRow(true, "Sputnik", "Jupiter")]
        public void TestMethod_ChangeDestination(bool flag, string rocketName, string destination)
        {
            var expected = flag ? CargoRocketEntity(rocketName, destination) : null;

            //configure MOQ
            ConfigureMOQ_ChangeDestination(expected);

            var cargoRocketWarehouse = new NextGenCargoRocketWarehouse(_cargoRocketInventory.Object);
            
            var actual = cargoRocketWarehouse.ChangeDestination(rocketName, destination);

            if (flag)
            {
                expected.ToExpectedObject().ShouldEqual(actual);
            }
            else
            {
                Assert.AreEqual(expected, actual);
            }

        }

        [DataTestMethod]
        [DataRow(false, "Apollo", "")]
        [DataRow(false, "", "Mars")]
        [DataRow(true, " ", "Jupiter")]
        [DataRow(true, " ", " ")]
        [DataRow(true, "", "")]
        [DataRow(true, "", null)]
        [DataRow(true, null, "")]
        [DataRow(true, null, null)]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_ChangeDestination_Exception(bool flag, string rocketName, string destination)
        {
            //configure MOQ
            ConfigureMOQ_ChangeDestination(null);
            var cargoRocketWarehouse = new NextGenCargoRocketWarehouse(_cargoRocketInventory.Object);

            var actual = cargoRocketWarehouse.ChangeDestination(rocketName, destination);

        }

        [DataTestMethod]
        [DataRow(true, "Apollo", 3)]
        [DataRow(true, "Apollo-1", 0)]
        [DataRow(false, "Apollo", 0)]
        public void TestMethod_GetAllSatellites(bool flag, string rocketName, int satelliteCount)
        {
            var expected = flag ? CargoRocketWithSatelliteEntity(rocketName, string.Empty, satelliteCount)
                                : CargoRocketEntity(rocketName, string.Empty);
            //configure MOQ
            ConfigureMOQ_GetRocket(expected);
            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var actual = cargoRocketWarehouse.GetSatellites(rocketName);

            if (flag)
            {
                expected.satellites.ToExpectedObject().ShouldEqual(actual);
            }
            else
            {
                Assert.AreEqual(null, actual);
            }
        }


        [DataTestMethod]
        [DataRow("", 3)]
        [DataRow("", 0)]
        [DataRow(" ", 0)]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_GetAllSatellites_Exception(string rocketName, int satelliteCount)
        {
            var expected = CargoRocketWithSatelliteEntity(rocketName, string.Empty, satelliteCount);
            //configure MOQ
            ConfigureMOQ_GetRocket(expected);
            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var actual = cargoRocketWarehouse.GetSatellites(rocketName);
        }

    }
}
