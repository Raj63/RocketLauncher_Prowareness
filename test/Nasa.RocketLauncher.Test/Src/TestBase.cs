using System.Collections.Generic;
using Moq;
using Nasa.RocketLauncher.Inventory.Src.Interfaces;
using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Test
{
    public class TestBase : DataMocker
    {
        public Mock<ICargoRocketInventory> _cargoRocketInventory;

        public TestBase()
        {
            _cargoRocketInventory = new Mock<ICargoRocketInventory>();
        }

        public void ConfigureMOQ_GetRocket(CargoRocket rocket)
        {
            _cargoRocketInventory.Setup(x => x.GetRocket(It.IsAny<string>())).Returns(rocket);
        }

        public void ConfigureMOQ_StoreRocket(bool flag)
        {
            _cargoRocketInventory.Setup(x => x.StoreRocket(It.IsAny<CargoRocket>())).Returns(flag);
        }

        public void ConfigureMOQ_ScrapRocket(bool flag)
        {
            _cargoRocketInventory.Setup(x => x.ScrapRocket(It.IsAny<string>())).Returns(flag);
        }

        public void ConfigureMOQ_LoadSatellites(bool flag)
        {
            _cargoRocketInventory.Setup(x => x.LoadSatellites(It.IsAny<List<Satellite>>(),
                It.IsAny<string>())).Returns(flag);
        }

        public void ConfigureMOQ_UnloadSatellites(bool flag)
        {
            _cargoRocketInventory.Setup(x => x.UnloadSatellites(It.IsAny<List<Satellite>>(),
                It.IsAny<string>())).Returns(flag);
        }

        public void ConfigureMOQ_ChangeDestination(CargoRocket rocket)
        {
            _cargoRocketInventory.Setup(x => x.ChangeDestination(It.IsAny<string>(),
                It.IsAny<string>())).Returns(rocket);
        }

    }
}
