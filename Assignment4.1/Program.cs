using System;
using System.Collections.Generic;

namespace Assignment4._1
{
    class Program
    {
        //The sizes of airports are categorized into these 5 groups: Small, Medium, Large, Mega, Super Mega.
        //Given a list of airports order them according to their size.
        static void Main(string[] args)
        {
            List<Airport> airports = new List<Airport>()
            {
                new Airport("Zvartnots","2181",Sizes.Small),
                new Airport("Tokyo Haneda Airport", "6517", Sizes.SuperMega),
                new Airport("Madrid Barajas Airport", "7425", Sizes.Large),
                new Airport("John F. Kennedy International Airport", "9637", Sizes.SuperMega),
                new Airport("Dubai International Airport", "7523", Sizes.Small),
                new Airport("Guangzhou Baiyun International Airport", "9373", Sizes.Mega),
                new Airport("Denver International Airport", "7389", Sizes.Large),
                new Airport("London Heathrow Airport", "7773", Sizes.Medium),
                new Airport("Hong Kong International Airport", "0086", Sizes.Small),
                new Airport("Paris-Charles de Gaulle Airport", "6451", Sizes.Mega)
            };

            //List<Airport> sortedAirports = Airport.SortBySize(airports);

            airports.Sort();
            foreach (var airport in airports)
            {
                Console.WriteLine($"{airport.Name}, Size: {airport.Size}");
            }
        }
    }
}
