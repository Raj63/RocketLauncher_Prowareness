using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.RocketLauncher.Common.Interfaces
{
    public interface IHelper
    {
        string ReadUserInputs(string msg);
        int? ProcessUserAction(string msg, List<string> commandList);
    }
}
