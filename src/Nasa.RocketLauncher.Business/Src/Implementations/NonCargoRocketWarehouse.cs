using System;
using System.Collections.Generic;
using Nasa.RocketLauncher.Business.Src.Interfaces;
using Nasa.RocketLauncher.Contract.DataContracts;
using Nasa.RocketLauncher.Inventory.Src.Interfaces;

namespace Nasa.RocketLauncher.Business.Src.Implementations
{
    public class NonCargoRocketWarehouse : INonCargoRocketWarehouse
    {
        INonCargoRocketInventory _nonCargoRocketInventory;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="nonCargoRocketInventory"></param>
        public NonCargoRocketWarehouse(INonCargoRocketInventory nonCargoRocketInventory)
        {
            _nonCargoRocketInventory = nonCargoRocketInventory;
        }

        public bool BoardAstronauts(List<Astronaut> astrounauts)
        {
            throw new NotImplementedException();
        }

        public NonCargoRocket CreateRocket(string name, string destination, string catagory)
        {
            throw new NotImplementedException();
        }

        public NonCargoRocket CreateRocket(string name, string destination)
        {
            throw new NotImplementedException();
        }

        public List<Astronaut> GetAstronauts()
        {
            throw new NotImplementedException();
        }

        public NonCargoRocket GetRocket(string rocketName)
        {
            throw new NotImplementedException();
        }

        public bool UnBoardAstronauts(List<string> astrounauts)
        {
            throw new NotImplementedException();
        }
    }
}
