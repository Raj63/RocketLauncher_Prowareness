using Nasa.RocketLauncher.Contract.DataContracts;

namespace Nasa.RocketLauncher.Business.Src.Interfaces
{
    public interface INonCargoRocketWarehouse : IRocketWarehouse<NonCargoRocket>, IISSModuleWarehouse
    {
    }
}
