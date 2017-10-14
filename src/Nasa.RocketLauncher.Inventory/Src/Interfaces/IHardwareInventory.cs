using System.Collections.Generic;

namespace Nasa.RocketLauncher.Inventory.Src.Interfaces
{
    public interface IHardwareInventory<T>
    {
        bool StoreRocket(T rocket);

        bool ScrapRocket(string rocketName);

        T GetRocket(string rocketName);
    }
}
