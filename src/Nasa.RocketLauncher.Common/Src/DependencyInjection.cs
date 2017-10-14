using SimpleInjector;

using Nasa.RocketLauncher.Common.Interfaces;
using Nasa.RocketLauncher.Inventory.Src.Interfaces;
using Nasa.RocketLauncher.Inventory.Src.Implementations;
using Nasa.RocketLauncher.Business.Src.Interfaces;
using Nasa.RocketLauncher.Business.Src.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Nasa.RocketLauncher.Common.Src
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Configure DI using MS extension logging
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            // add logging
            serviceCollection.AddSingleton(new LoggerFactory()
            .AddConsole());
            serviceCollection.AddLogging();

            // add services
            serviceCollection.AddTransient<IHelper, Helper.Helper>();
            serviceCollection.AddTransient<IUserInteraction, UserInteraction.UserInteraction>();
            serviceCollection.AddTransient<ICargoRocketInventory, CargoRocketInventory>();
            serviceCollection.AddTransient<INonCargoRocketInventory, NonCargoRocketInventory>();
            serviceCollection.AddTransient<ICargoRocketWarehouse, CargoRocketWarehouse>();
            serviceCollection.AddTransient<INextGenCargoRocketWarehouse, NextGenCargoRocketWarehouse>();


            return serviceCollection;
        }

        /// <summary>
        /// Configure DI using simple injector container
        /// </summary>
        /// <returns></returns>
        public static Container Configure()
        {
            var container = new Container();

            container.Register<IHelper, Helper.Helper>();
            container.Register<IUserInteraction, UserInteraction.UserInteraction>();
            container.Register<ICargoRocketInventory, CargoRocketInventory>();
            container.Register<INonCargoRocketInventory, NonCargoRocketInventory>();
            container.Register<ICargoRocketWarehouse, CargoRocketWarehouse>();
            //container.Register<INonCargoRocketWarehouse, NonCargoRocketWarehouse>();
            container.Register<INextGenCargoRocketWarehouse, NextGenCargoRocketWarehouse>();

            return container;
        }
        
    }
}
