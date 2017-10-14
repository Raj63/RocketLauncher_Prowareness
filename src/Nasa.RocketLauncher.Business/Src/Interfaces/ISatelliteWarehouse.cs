using System.Collections.Generic;
using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Business.Src.Interfaces
{
    public interface ISatelliteWarehouse
    {
        Satellite CreateSatellite(string name, string catagory);

        bool LoadSatellites(List<Satellite> satellites, string rocketName);

        List<KeyValuePair<string, bool>> UnloadSatellites(List<string> satellites, string rocketName);

        List<Satellite> GetSatellites(string rocketName);
    }
}
