using SimpleInjector;
using Nasa.RocketLauncher.Common.Src;
using Microsoft.Extensions.DependencyInjection;

namespace Nasa.RocketLauncher.Application
{
    static class Program
    {
        static readonly Interfaces.ICommandCentre commandCentre;
        /// <summary>
        /// Default constructor used to configure DI
        /// </summary>
        static Program()
        {
            //Inject dependencies - using Microsoft.Extensions.DependencyInjection
            var iserviceCollection = DependencyInjection.ConfigureServices();
            // add Command centre
            iserviceCollection.AddTransient<CommandCentre>();
            // create service provider
            var serviceProvider = iserviceCollection.BuildServiceProvider();
            commandCentre = serviceProvider.GetService<CommandCentre>();

            /* 
            //Inject dependencies - using SimpleInjector
            container = DependencyInjection.Configure();

            container.Register<CommandCentre>();
            //Verify container
            container.Verify();
            commandCentre = container.GetInstance<CommandCentre>();
            */

        }
        
        /// <summary>
        /// Main method/Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // entry to run app
            commandCentre.Start();
        }

    }
}
