using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;
using Nasa.RocketLauncher.Inventory.Src.Interfaces;
using Microsoft.Extensions.Logging;

namespace Nasa.RocketLauncher.Inventory.Src.Implementations
{
    public class CargoRocketInventory : ICargoRocketInventory
    {

        private readonly ILogger<CargoRocketInventory> _logger;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="logger"></param>
        public CargoRocketInventory(ILogger<CargoRocketInventory> logger)
        {
            _logger = null; //Switching off the logger
        }

        /// <summary>
        /// Store Rockets into the inventory
        /// </summary>
        /// <param name="rocket"></param>
        /// <returns></returns>
        public bool StoreRocket(CargoRocket rocket)
        {
            bool response = false;
            if (rocket != null && !string.IsNullOrWhiteSpace(rocket.Name) && Storage.Storage.CargoRockets != null)
            {
                _logger?.LogInformation("{0} - Inventory operation starts at {1}", "StoreRocket", System.DateTime.Now);
                Storage.Storage.CargoRockets.Add(rocket);
                _logger?.LogInformation("{0} - Inventory operation ends at {1}", "StoreRocket", System.DateTime.Now);
                response = true;
            }

            return response;
        }

        /// <summary>
        /// Gets the rocket from inventory
        /// </summary>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public CargoRocket GetRocket(string rocketName)
        {
            CargoRocket response = null;

            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                //Logging starts
                _logger?.LogInformation("{0} - Inventory operation starts at {1}", "GetRocket", System.DateTime.Now);

                foreach (var rocket in Storage.Storage.CargoRockets)
                {
                    if(rocket != null && rocket.Name.Equals(rocketName))
                    {
                        response = rocket;
                        break;
                    }
                }
                //logging ends
                _logger?.LogInformation("{0} - Inventory operation ends at {1}", "GetRocket", System.DateTime.Now);
            }
            return response;
        }

        /// <summary>
        /// Scrap the rocket from inventory
        /// </summary>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public bool ScrapRocket(string rocketName)
        {
            bool response = false;
            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                //Logging starts
                _logger?.LogInformation("{0} - Inventory operation starts at {1}", "ScrapRocket", System.DateTime.Now);

                CargoRocket rocket = GetRocket(rocketName);
                if(rocket != null)
                {
                    Storage.Storage.CargoRockets.Remove(rocket);
                    response = true;
                }
                //logging ends
                _logger?.LogInformation("{0} - Inventory operation ends at {1}", "ScrapRocket", System.DateTime.Now);
            }

            return response;
        }

        /// <summary>
        /// Load satellites to a rocket
        /// </summary>
        /// <param name="satellites"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public bool LoadSatellites(List<Satellite> satellites, string rocketName)
        {
            bool response = false;
            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                //Logging starts
                _logger?.LogInformation("{0} - Inventory operation starts at {1}", "LoadSatellites", System.DateTime.Now);
                foreach (var rocket in Storage.Storage.CargoRockets)
                {
                    if (rocket != null && rocket.Name.Equals(rocketName))
                    {
                        if(rocket.satellites == null)
                        {
                            rocket.satellites = new List<Satellite>();
                        }

                        rocket.satellites.AddRange(satellites);
                        response = true;
                        break;
                    }
                }
                //logging ends
                _logger?.LogInformation("{0} - Inventory operation ends at {1}", "LoadSatellites", System.DateTime.Now);

            }

            return response;
        }

        /// <summary>
        /// Unload input satellites from the rocket
        /// </summary>
        /// <param name="satellites"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public bool UnloadSatellites(List<Satellite> satellites, string rocketName)
        {
            bool response = false;
            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                //Logging starts
                _logger?.LogInformation("{0} - Inventory operation starts at {1}", "UnloadSatellites", System.DateTime.Now);
                foreach (var rocket in Storage.Storage.CargoRockets)
                {
                    if (rocket != null && rocket.Name.Equals(rocketName))
                    {
                        if (rocket.satellites != null)
                        {
                            rocket.satellites.RemoveAll(satellite => satellites.Contains(satellite));
                            response = true;
                        }                        
                        break;
                    }
                }
                //logging ends
                _logger?.LogInformation("{0} - Inventory operation ends at {1}", "UnloadSatellites", System.DateTime.Now);

            }

            return response;
        }

        /// <summary>
        /// Change destination of a rocket
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public CargoRocket ChangeDestination(string destination, string rocketName)
        {
            CargoRocket response = null;
            if (!string.IsNullOrWhiteSpace(rocketName) && Storage.Storage.CargoRockets != null && Storage.Storage.CargoRockets.Count > 0)
            {
                //Logging starts
                _logger?.LogInformation("{0} - Inventory operation starts at {1}", "ChangeDestination", System.DateTime.Now);
                foreach (var rocket in Storage.Storage.CargoRockets)
                {
                    if (rocket != null && rocket.Name.Equals(rocketName))
                    {
                        if (rocket.satellites != null)
                        {
                            rocket.Destination = destination;
                            response = rocket;
                        }
                        break;
                    }
                }
                //logging ends
                _logger?.LogInformation("{0} - Inventory operation ends at {1}", "ChangeDestination", System.DateTime.Now);


            }

            return response;
        }

    }
}
