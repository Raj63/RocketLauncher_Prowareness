using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Business.Src.Interfaces
{
    public interface IRocketWarehouse<T>
    {
        T CreateRocket(string name, string destination);

        T GetRocket(string rocketName);
    }
}
