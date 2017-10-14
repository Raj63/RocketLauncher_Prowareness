using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Inventory.Src.Interfaces
{
    public interface INonCargoRocketInventory : IHardwareInventory<NonCargoRocket>
    {
        bool BoardAstronauts(List<Astronaut> satellites, string rocketName);

        bool UnBoardAstronauts(List<Astronaut> satellites, string rocketName);

        NonCargoRocket ChangeDestination(string destination, string rocketName);
    }
}
