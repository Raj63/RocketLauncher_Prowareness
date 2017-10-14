using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.RocketLauncher.Common.Interfaces
{
    public interface IUserInteraction
    {
        void PrintMessage(string msg);
        void PrintCommands(List<string> commandList);
        string ReadCommand();
        void WriteLine(string msg);
    }
}
