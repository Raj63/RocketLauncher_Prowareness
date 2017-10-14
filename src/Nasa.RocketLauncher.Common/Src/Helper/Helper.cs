using System;
using System.Collections.Generic;
using Nasa.RocketLauncher.Common.Interfaces;

namespace Nasa.RocketLauncher.Common.Helper
{
    public class Helper : IHelper
    {
        private readonly IUserInteraction _userInteraction;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="userInteraction"></param>
        public Helper(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        /// <summary>
        /// Read user inputs from std
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string ReadUserInputs(string msg)
        {
            string response = null;
            if (!string.IsNullOrWhiteSpace(msg))
            {
                while (true)
                {
                    //Print message
                    _userInteraction.PrintMessage(msg);
                    //Get command to execute
                    string command = _userInteraction.ReadCommand();

                    if (!string.IsNullOrWhiteSpace(command))
                    {
                        response = command;
                        break;
                    }
                    else
                    {
                        _userInteraction.PrintMessage("Please enter a valid input");
                    }
                }
            }

            return response;
        }
        /// <summary>
        /// Print commands to be executed and process user response
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="commandList"></param>
        /// <returns></returns>
        public int? ProcessUserAction(string msg, List<string> commandList)
        {
            int? result = null;
            if(commandList != null && commandList.Count > 0)
            {
                int count = commandList.Count;
                while (true)
                {
                    //Print message
                    _userInteraction.PrintMessage(msg);
                    //Print commands
                    _userInteraction.PrintCommands(commandList);
                    //Get command to execute
                    string command = _userInteraction.ReadCommand();
                    //Check if its valid command or not
                    int output;
                    if (Int32.TryParse(command, out output) && output > 0 && output <= count)
                    {
                        result = output;
                        break;
                    }
                    else
                    {
                        _userInteraction.PrintMessage("Please enter a valid input");
                    }
                }
            }
            return result;
        }
    }
}
