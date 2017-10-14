using System;
using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;
using Nasa.RocketLauncher.Inventory.Src.Interfaces;

namespace Nasa.RocketLauncher.Inventory.Src.Implementations
{
    public class NonCargoRocketInventory : INonCargoRocketInventory
    {
        public bool BoardAstronauts(List<Astronaut> satellites, string rocketName)
        {
            throw new NotImplementedException();
        }

        public NonCargoRocket ChangeDestination(string destination, string rocketName)
        {
            throw new NotImplementedException();
        }

        public NonCargoRocket GetRocket(string rocketName)
        {
            throw new NotImplementedException();
        }

        public bool ScrapRocket(string rocketName)
        {
            throw new NotImplementedException();
        }

        public bool StoreRocket(NonCargoRocket rocket)
        {
            throw new NotImplementedException();
        }

        public bool UnBoardAstronauts(List<Astronaut> satellites, string rocketName)
        {
            throw new NotImplementedException();
        }
    }

}
