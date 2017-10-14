using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.RocketLauncher.Contract.DataContracts
{
    public class CargoRocket : Rocket
    {
        public List<Satellite> satellites
        {
            get; set;
        }
    }
}
