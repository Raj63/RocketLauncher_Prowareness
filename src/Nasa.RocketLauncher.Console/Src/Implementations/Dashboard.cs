using System.Collections.Generic;
using Nasa.RocketLauncher.Common.Interfaces;
using Nasa.RocketLauncher.Business.Src.Interfaces;
using Nasa.RocketLauncher.Contract.DataContracts;
using System;

namespace Nasa.RocketLauncher.Application
{
    public static class Dashboard
    {

        static IHelper _helper;
        static IUserInteraction _userInteraction;
        static INextGenCargoRocketWarehouse _cargoRocketWarehouse;

        /// <summary>
        /// Initialize the dependencies
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="userInteraction"></param>
        /// <param name="CargoRocketWarehouse"></param>
        public static void InitializeDashboard(IHelper helper, IUserInteraction userInteraction,
            INextGenCargoRocketWarehouse CargoRocketWarehouse)
        {
            _helper = helper;
            _userInteraction = userInteraction;
            _cargoRocketWarehouse = CargoRocketWarehouse;
        }


        /// <summary>
        /// Executes operation
        /// </summary>
        /// <param name="action"></param>
        /// <param name="rocketName"></param>
        public static void Operation(int action, string rocketName)
        {
            switch (action)
            {
                case (int)Constants.OPTION.ADD_SATELLITE:
                    AddSatellite(rocketName);
                    _userInteraction.PrintMessage("Satellite loaded successfully");
                    break;

                case (int)Constants.OPTION.UPDATE_SATELLITE:
                    UpdateSatellite(rocketName);
                    break;

                case (int)Constants.OPTION.PRINT_ALL_SATELLITES:
                    _userInteraction.PrintMessage(string.Format(Constants.SATELLITE_INFO, rocketName));
                    ListAllSatellites(rocketName);
                    break;

                case (int)Constants.OPTION.PRINT_ROCKET_INFO:
                    var rocket = _cargoRocketWarehouse.GetRocket(rocketName);
                    PrintRocketInfo(rocket);
                    break;

                case (int)Constants.OPTION.CHANGE_DESTINATION:
                    ChangeDestination(rocketName);
                    break;

                case (int)Constants.OPTION.PRINT_SATELLITE_BY_CATAGORY:
                    ListAllSatellitesByCatagory(rocketName);
                    break;

            }
            return;
        }


        /// <summary>
        /// List all satellites based on the input catagory
        /// </summary>
        /// <param name="rocketName"></param>
        private static void ListAllSatellitesByCatagory(string rocketName)
        {
            int? catagory = _helper.ProcessUserAction(Constants.ENTER_CATAGORY, Constants.SATELITTE_CATAGORIES);

            var satellites = _cargoRocketWarehouse.GetAllSatellites(Constants.SATELITTE_CATAGORIES[catagory.Value - 1], rocketName);
            _userInteraction.PrintMessage("Satellite Info");
            PrintAllSatellites(satellites, rocketName);
        }

        /// <summary>
        /// Change destination of a rocket
        /// </summary>
        /// <param name="rocketName"></param>
        private static void ChangeDestination(string rocketName)
        {
            string destinationName = _helper.ReadUserInputs(string.Format(Constants.ENTER_NAME, "new Destination"));

            var result = _cargoRocketWarehouse.ChangeDestination(destinationName, rocketName);

            if(result != null)
            {
                Console.WriteLine("Destination changed succesfully");
            }
            else
            {
                Console.WriteLine("Operation failed");
            }
        }

        /// <summary>
        /// Print rocket info
        /// </summary>
        private static void PrintRocketInfo(CargoRocket rocket)
        {
            if (rocket != null)
            {
                _userInteraction.WriteLine("Rocket Info:");
                _userInteraction.WriteLine(string.Format("Name:{0}", rocket.Name));
                _userInteraction.WriteLine(string.Format("Destination:{0}", rocket.Destination));
                _userInteraction.WriteLine("Satellite Info");

                PrintAllSatellites(rocket.satellites, rocket.Name);
            }
        }

        /// <summary>
        /// Add satellite to a rocket
        /// </summary>
        /// <param name="rocketName"></param>
        private static void AddSatellite(string rocketName)
        {
            string satelliteName = _helper.ReadUserInputs(string.Format(Constants.ENTER_NAME, "Satelllite"));
            int? catagory = _helper.ProcessUserAction(Constants.ENTER_CATAGORY, Constants.SATELITTE_CATAGORIES);

            var satellite = _cargoRocketWarehouse.CreateSatellite(satelliteName, Constants.SATELITTE_CATAGORIES[catagory.Value-1]);
            _cargoRocketWarehouse.LoadSatellites(new List<Satellite> { satellite }, rocketName);
        }

        /// <summary>
        /// Print all satellites 
        /// </summary>
        /// <param name="satellites"></param>
        /// <param name="name"></param>
        private static void PrintAllSatellites(List<Satellite> satellites, string name)
        {
            if (satellites != null && satellites.Count > 0)
            {
                foreach(var satellite in satellites)
                {
                    _userInteraction.WriteLine(string.Format("{0} - {1}",satellite.Name, satellite.Catagory));
                }
            }
            else
            {
                _userInteraction.WriteLine("None");
            }
        }

        /// <summary>
        /// List all satellites
        /// </summary>
        /// <param name="rocketName"></param>
        private static void ListAllSatellites(string rocketName)
        {
            var satellites = _cargoRocketWarehouse.GetSatellites(rocketName);
            PrintAllSatellites(satellites, rocketName);
        }

        /// <summary>
        /// Update satellite
        /// </summary>
        /// <param name="rocketName"></param>
        private static void UpdateSatellite(string rocketName)
        {
            int? option = _helper.ProcessUserAction(Constants.ENTER_COMMAND, Constants.ENTER_SATELLITE_ACTIONS);
            ListAllSatellites(rocketName);
            _userInteraction.WriteLine(Constants.SELECT_SATELLITE);

            string satelliteName = _helper.ReadUserInputs(string.Format(Constants.ENTER_NAME, "Satellite"));
            if (option == 1)
            {
                _userInteraction.PrintMessage("Rocket Upgrade is required");
            }
            else
            {
                var result = _cargoRocketWarehouse.UnloadSatellites(new List<string> { satelliteName }, rocketName);

                if(result != null)
                {
                    _userInteraction.PrintMessage("Operation Status:");
                    foreach (var obj in result)
                    {
                        _userInteraction.WriteLine(string.Format("{0} -{1}", obj.Key, (obj.Value ? "Removed"
                                                        : "Failed to remove")));
                    }
                }
                else
                {
                    _userInteraction.WriteLine("Operation failed!");
                }
            }
        }

    }
}
