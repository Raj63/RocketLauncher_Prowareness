using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.RocketLauncher.Application
{
    public class Constants
    {
        public static readonly List<string> SATELITTE_CATAGORIES = new List<string>
        {
            "Weather",
            "Maps",
            "Surveillance"
        };
        public static readonly List<string> OPTIONS = new List<string>
        {
            "Add Satellite",
            "update Satellite",
            "Print All Satellite",
            "Print Rocket Info",
            "Change Rocket Destination",
            "Print Satellites based on the catagory",
            "Abort Mission"
        };

        public enum OPTION
        {
            ADD_SATELLITE = 1,
            UPDATE_SATELLITE = 2,
            PRINT_ALL_SATELLITES = 3,
            PRINT_ROCKET_INFO = 4,
            CHANGE_DESTINATION = 5,
            PRINT_SATELLITE_BY_CATAGORY = 6
        };
        public static readonly List<string> ENTER_SATELLITE_ACTIONS = new List<string>
        {
            "Update a Satellite Name",
            "Remove a Satellite from Rocket"
        };

        public const string SELECT_SATELLITE = "Please enter a satellite from the List";
        public const string ENTER_COMMAND = "Please select any of the below mentioned commands to proceed";
        public const string ENTER_NAME = "Please enter {0} name";
        public const string ENTER_CATAGORY = "Please enter Satellite catagory";
        public const string SATELLITE_INFO = "Rocket - {0} has the following satellite(s)";
        public static readonly List<string> CREATE_ROCKET = new List<string> { "Create Rocket", "Abort Mission" };
    }


}
