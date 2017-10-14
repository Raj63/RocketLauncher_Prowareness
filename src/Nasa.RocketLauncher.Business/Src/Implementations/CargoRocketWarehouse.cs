using System.Collections.Generic;
using Nasa.RocketLauncher.Business.Src.Interfaces;
using Nasa.RocketLauncher.Contract.DataContracts;
using Nasa.RocketLauncher.Inventory.Src.Interfaces;

namespace Nasa.RocketLauncher.Business.Src.Implementations
{
    public class CargoRocketWarehouse : ICargoRocketWarehouse
    {
        private ICargoRocketInventory _cargorocketInventory;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="hardwareInventory"></param>
        public CargoRocketWarehouse(ICargoRocketInventory hardwareInventory)
        {
            _cargorocketInventory = hardwareInventory;
        }

        /// <summary>
        /// Crreates a Rocket and store it into the inventory
        /// </summary>
        /// <param name="name"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public CargoRocket CreateRocket(string name, string destination)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "name");
            }
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "destination");
            }

            var rocket = new CargoRocket
            {
                Name = name,
                Destination = destination
            };

            //Store into inventory
            if (!_cargorocketInventory.StoreRocket(rocket))
            {
                rocket = null;
            }

            return rocket;
        }

        /// <summary>
        /// Creates a Satellite
        /// </summary>
        /// <param name="name"></param>
        /// <param name="catagory"></param>
        /// <returns></returns>
        public Satellite CreateSatellite(string name, string catagory)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "name");
            }
            if (string.IsNullOrWhiteSpace(catagory))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "catagory");
            }

            var satellite = new Satellite
            {
                Name = name,
                Catagory = catagory
            };

            return satellite;
        }

        /// <summary>
        /// Get all satellite from a rocket
        /// </summary>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public List<Satellite> GetSatellites(string rocketName)
        {
            if (string.IsNullOrWhiteSpace(rocketName))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "rocketName");
            }

            var rocket = _cargorocketInventory.GetRocket(rocketName);

            return rocket.satellites;
        }

        /// <summary>
        /// gets rocket
        /// </summary>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public CargoRocket GetRocket(string rocketName)
        {
            if (string.IsNullOrWhiteSpace(rocketName))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "rocketName");
            }
            return _cargorocketInventory.GetRocket(rocketName);
        }

        /// <summary>
        /// Load list of satellite to a rocket
        /// </summary>
        /// <param name="satellites"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public bool LoadSatellites(List<Satellite> satellites, string rocketName)
        {
            if (string.IsNullOrWhiteSpace(rocketName))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "rocketName");
            }
            if (satellites == null || satellites.Count == 0)
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "satellites");
            }

            return _cargorocketInventory.LoadSatellites(satellites, rocketName);
        }

        /// <summary>
        /// unload list of satellite from a rocket
        /// </summary>
        /// <param name="satellites"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, bool>> UnloadSatellites(List<string> satellites, string rocketName)
        {
            if (string.IsNullOrWhiteSpace(rocketName))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "rocketName");
            }
            if (satellites == null || satellites.Count == 0)
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "satellites");
            }

            List<KeyValuePair<string, bool>> response = new List<KeyValuePair<string, bool>>();
            var rocket = _cargorocketInventory.GetRocket(rocketName);
            var flag = rocket != null && rocket.satellites != null && rocket.satellites.Count > 0;

            List<Satellite> reqSatellites = new List<Satellite>();

            foreach (var satellite in satellites)
            {
                bool status = false;
                if (satellite != null && !string.IsNullOrWhiteSpace(satellite) && flag &&
                    rocket.satellites.Exists(s => !string.IsNullOrWhiteSpace(s.Name) &&
                    s.Name.Equals(satellite)))
                {

                    reqSatellites.Add(rocket.satellites.Find(s => s.Name.Equals(satellite)));
                    status = true;
                }

                response.Add(new KeyValuePair<string, bool>(satellite, status));
            }

            if (reqSatellites.Count > 0)
            {
                _cargorocketInventory.UnloadSatellites(reqSatellites, rocketName);
            }

            return response;
        }
    }
}
