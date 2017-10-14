using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Business.Src.Interfaces
{
    public interface INextGenCargoRocketWarehouse : ICargoRocketWarehouse
    {
        CargoRocket ChangeDestination(string destination, string rocketName);

        List<Satellite> GetAllSatellites(string criteria, string rocketName);
    }
}
