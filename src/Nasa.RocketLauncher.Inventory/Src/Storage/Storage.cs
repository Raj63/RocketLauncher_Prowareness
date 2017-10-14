using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Inventory.Src.Storage
{
    public static class Storage
    {
        public static List<CargoRocket> CargoRockets = new List<CargoRocket>();

        public static List<NonCargoRocket> NonCargoRockets = new List<NonCargoRocket>();
    }
}
