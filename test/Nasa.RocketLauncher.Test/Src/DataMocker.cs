using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Test
{
    public class DataMocker
    {
        public CargoRocket CargoRocketEntity(string name, string dest)
        {
            return new CargoRocket { Name = name, Destination = dest };
        }

        public Satellite CargoSatelliteEntity(string name, string catagory)
        {
            return new Satellite { Name = name, Catagory = catagory };
        }

        public CargoRocket CargoRocketWithSatelliteEntity(string name, string dest, int satelliteCount)
        {
            var rocket = new CargoRocket { Name = name, Destination = dest, satellites = new List<Satellite>() };

            for (var i = 0; i < satelliteCount; i++)
            {
                rocket.satellites.Add(new Satellite { Name = string.Format("Satellite-{0}", i) });
            }

            return rocket;
        }
    }
}
