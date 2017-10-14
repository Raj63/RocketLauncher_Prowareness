using System;
using ExpectedObjects;
using Nasa.RocketLauncher.Business.Src.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nasa.RocketLauncher.Test
{
    [TestClass]
    public class CargoRocketWarehouseTest : TestBase
    {
        [DataTestMethod]
        [DataRow(true, "Apollo", "Moon")]
        [DataRow(false, "Apollo-1", "Mars")]
        [DataRow(true, "Cassineni", "Jupiter")]
        [DataRow(true, "Sputnik", "Jupiter")]
        public void TestMethod_CreateRocket(bool flag, string rocketName, string destination)
        {
            //configure MOQ
            ConfigureMOQ_StoreRocket(flag);

            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var expected = flag ? CargoRocketEntity(rocketName, destination).ToExpectedObject() : null;

            var actual = cargoRocketWarehouse.CreateRocket(rocketName, destination);

            if (actual != null)
            {
                expected.ShouldEqual(actual);
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
        public void TestMethod_CreateRocket_Exception(bool flag, string rocketName, string destination)
        {
            //configure MOQ
            ConfigureMOQ_StoreRocket(flag);

            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);

            var actual = cargoRocketWarehouse.CreateRocket(rocketName, destination);

        }

        [DataTestMethod]
        [DataRow("Apollo", "Weather")]
        [DataRow("Sputnik", "Surveillance")]
        [DataRow("Chandryan", "Maps")]
        public void TestMethod_CreateSatellite(string name, string catagory)
        {
            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var expected = CargoSatelliteEntity(name, catagory).ToExpectedObject();
            var actual = cargoRocketWarehouse.CreateSatellite(name, catagory);

            expected.ShouldEqual(actual);
        }

        [DataTestMethod]
        [DataRow("", "Weather")]
        [DataRow("Sputnik", "")]
        [DataRow("Sputnik", " ")]
        [DataRow(" ", "")]
        [DataRow(null, "")]
        [DataRow("", null)]
        [DataRow(null, null)]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_CreateSatellite_Exception(string name, string catagory)
        {
            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var actual = cargoRocketWarehouse.CreateSatellite(name, catagory);
        }


        [DataTestMethod]
        [DataRow(true, "Apollo", 3)]
        [DataRow(false, "Apollo-1", 0)]
        [DataRow(true, "Apollo", 0)]
        public void TestMethod_GetSatellites(bool flag, string rocketName, int satelliteCount)
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
        public void TestMethod_GetSatellites_Exception(string rocketName, int satelliteCount)
        {
            var expected = CargoRocketWithSatelliteEntity(rocketName, string.Empty, satelliteCount);
            //configure MOQ
            ConfigureMOQ_GetRocket(expected);
            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var actual = cargoRocketWarehouse.GetSatellites(rocketName);

            expected.satellites.ToExpectedObject().ShouldEqual(actual);
        }

        [DataTestMethod]
        [DataRow(false, "Apollo", "Jupiter", 4, true)]
        [DataRow(true, "Saturn", "Moon", 0, true)]
        [DataRow(true, "Saturn", "Moon", 3, false)]
        public void TestMethod_GetRocket(bool flag, string rocketName, string dest, 
            int satelliteCount, bool withSatellite)
        {
            var expected = flag ? withSatellite ? 
                CargoRocketWithSatelliteEntity(rocketName, dest, satelliteCount)
                : CargoRocketEntity(rocketName, dest)
                                : null;
            //configure MOQ
            ConfigureMOQ_GetRocket(expected);
            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var actual = cargoRocketWarehouse.GetRocket(rocketName);

            if (flag)
            {
                expected.ToExpectedObject().ShouldEqual(actual);
            }
            else
            {
                Assert.AreEqual(null, actual);
            }
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_GetRocket_Exception(string rocketName)
        {
            var expected = CargoRocketEntity(rocketName, string.Empty);
            //configure MOQ
            ConfigureMOQ_GetRocket(expected);
            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var actual = cargoRocketWarehouse.GetRocket(rocketName);
        }

        [DataTestMethod]
        [DataRow(true, "Apollo", 3)]
        [DataRow(true, "Sputnik", 1)]
        [DataRow(false, "Cassineni", 10)]
        public void TestMethod_LoadSatellites(bool flag, string rocketName, int satelliteCount)
        {
            var expected = CargoRocketWithSatelliteEntity(rocketName, string.Empty, satelliteCount);
            ConfigureMOQ_LoadSatellites(flag);
            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var actual = cargoRocketWarehouse.LoadSatellites(expected.satellites, rocketName);

            Assert.AreEqual(flag, actual);
        }

        [DataTestMethod]
        [DataRow(true, "", 3)]
        [DataRow(true, " ", 1)]
        [DataRow(true, "Cassineni", 0)]
        [DataRow(true, " ", 0)]
        [DataRow(false, "Apollo", 10)]
        [DataRow(false, "", 10)]
        [DataRow(false, " ", 10)]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_LoadSatellites_Exception(bool flag, string rocketName, int satelliteCount)
        {
            var expected = flag ? CargoRocketWithSatelliteEntity(rocketName, string.Empty, satelliteCount)
                                : CargoRocketEntity(rocketName, string.Empty);
            ConfigureMOQ_LoadSatellites(true);
            var cargoRocketWarehouse = new CargoRocketWarehouse(_cargoRocketInventory.Object);
            var actual = cargoRocketWarehouse.LoadSatellites(expected.satellites, rocketName);
        }
    }
}
