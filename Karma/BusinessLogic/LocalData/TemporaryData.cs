using Backend;
using System.Collections.Generic;

namespace BusinessLogic
{
    class TemporaryData
    {
        public static List<Location> RecomendedLocations = new List<Location>()
            {
              new Location("Lietuva", "Vilnius", "A street"),
              new Location("Lietuva", "Vilnius", "B street"),
              new Location("Lietuva", "Vilnius", "C street"),
              new Location("Lietuva", "Kaunas", "C street"),
            };

    }
}
