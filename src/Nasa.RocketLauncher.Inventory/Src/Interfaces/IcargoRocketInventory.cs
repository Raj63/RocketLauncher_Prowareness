using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Inventory.Src.Interfaces
{
    public interface ICargoRocketInventory : IHardwareInventory<CargoRocket>
    {
        bool LoadSatellites(List<Satellite> satellites, string rocketName);

        bool UnloadSatellites(List<Satellite> satellites, string rocketName);

        CargoRocket ChangeDestination(string destination, string rocketName);
    }
}
