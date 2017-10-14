using System.Collections.Generic;

namespace Nasa.RocketLauncher.Contract.DataContracts
{
    public class NonCargoRocket : Rocket
    {

        public List<Astronaut> astronauts
        {
            get; set;
        }
    }
}
