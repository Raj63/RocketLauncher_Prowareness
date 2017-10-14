using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Business.Src.Interfaces
{
    public interface IISSModuleWarehouse
    {
        bool BoardAstronauts(List<Astronaut> astrounauts);

        bool UnBoardAstronauts(List<string> astrounauts);

        List<Astronaut> GetAstronauts();
    }
}
