using System;
using Nasa.RocketLauncher.Common.Interfaces;
using Nasa.RocketLauncher.Business.Src.Interfaces;
using Nasa.RocketLauncher.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Nasa.RocketLauncher.Application
{
    public class CommandCentre : ICommandCentre
    {
        private readonly IHelper _helper;
        private readonly ILogger<CommandCentre> _logger;
        private readonly IUserInteraction _userInteraction;
        private readonly INextGenCargoRocketWarehouse _nextGencargoRocketWarehouse;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="userInteraction"></param>
        /// <param name="CargoRocketWarehouse"></param>
        /// <param name="logger"></param>
        public CommandCentre(IHelper helper, IUserInteraction userInteraction, 
            INextGenCargoRocketWarehouse CargoRocketWarehouse, ILogger<CommandCentre> logger)
        {
            _helper = helper;
            _userInteraction = userInteraction;
            _nextGencargoRocketWarehouse = CargoRocketWarehouse;
            _logger = null; //Switching off the logger

            //Initialize Dashboard
            Dashboard.InitializeDashboard(_helper, _userInteraction, _nextGencargoRocketWarehouse);
        }

        /// <summary>
        /// Dashboard operation starting point
        /// </summary>
        public void Start()
        {
            int? action = null;
            _logger?.LogInformation("This is the start of a console application");

            _userInteraction.WriteLine("**********Welcome to Nasa Command centre**********");
            _userInteraction.WriteLine("Press enter key to continue");
            Console.ReadLine();

            action = _helper.ProcessUserAction(Constants.ENTER_COMMAND, Constants.CREATE_ROCKET);

            if(!action.Abort())
            {
                string rocketName = _helper.ReadUserInputs(string.Format(Constants.ENTER_NAME, "Rocket"));
                string rocketDestination = _helper.ReadUserInputs(string.Format(Constants.ENTER_NAME, "Rocket Destination"));
                var rocket = _nextGencargoRocketWarehouse.CreateRocket(rocketName, rocketDestination);

                while (true)
                {
                    int? option = _helper.ProcessUserAction(Constants.ENTER_COMMAND, Constants.OPTIONS);

                    if (option != null && option > 0 && option < 7)
                    {
                        Dashboard.Operation(option.Value, rocketName);

                        _userInteraction.WriteLine("Press enter key to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        _userInteraction.PrintMessage("Mission Abort!!");
                        break;
                    }
                }
            }
            else
            {
                _userInteraction.PrintMessage("Mission Abort!!");
            }

            _userInteraction.WriteLine("Press enter Key to Kill");

            _logger?.LogInformation("This is the end of a console application");
            Console.ReadLine();
        }

    }
}
