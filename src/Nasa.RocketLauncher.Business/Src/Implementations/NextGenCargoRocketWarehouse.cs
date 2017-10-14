using System.Collections.Generic;
using Nasa.RocketLauncher.Business.Src.Interfaces;
using Nasa.RocketLauncher.Contract.DataContracts;
using Nasa.RocketLauncher.Inventory.Src.Interfaces;

namespace Nasa.RocketLauncher.Business.Src.Implementations
{
    public class NextGenCargoRocketWarehouse : CargoRocketWarehouse, INextGenCargoRocketWarehouse
    {
        private ICargoRocketInventory _cargorocketInventory;

        /// <summary>
        /// Parameterized constructor for DI
        /// </summary>
        /// <param name="cargorocketInventory"></param>
        public NextGenCargoRocketWarehouse(ICargoRocketInventory cargorocketInventory) : base(cargorocketInventory)
        {
            _cargorocketInventory = cargorocketInventory;
        }

        /// <summary>
        /// Change destination of a rocket
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public CargoRocket ChangeDestination(string destination, string rocketName)
        {
            if (string.IsNullOrWhiteSpace(rocketName))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "rocketName");
            }
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "destination");
            }

            return _cargorocketInventory.ChangeDestination(destination, rocketName);
        }

        /// <summary>
        /// Gets all satellite in a rocket of input catagory type
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="rocketName"></param>
        /// <returns></returns>
        public List<Satellite> GetAllSatellites(string criteria, string rocketName)
        {
            if (string.IsNullOrWhiteSpace(rocketName))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "rocketName");
            }
            if (string.IsNullOrWhiteSpace(criteria))
            {
                throw new System.ArgumentException(Constants.CONST_ARG_EXECPTION, "criteria");
            }

            List<Satellite> response = null;
            var rocket = _cargorocketInventory.GetRocket(rocketName);
            if (rocket != null && rocket.satellites != null)
            {
                foreach (var satellite in rocket.satellites)
                {
                    if (satellite != null && !string.IsNullOrWhiteSpace(satellite.Catagory)
                        && satellite.Catagory.Equals(criteria))
                    {
                        if (response == null)
                            response = new List<Satellite>();

                        response.Add(satellite);
                    }
                }
            }

            return response;
        }
    }
}
