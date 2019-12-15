using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6._1
{
    class Program
    {
        //Read from Excel.csv
        //References: https://joshclose.github.io/CsvHelper/getting-started

        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();

            fileReader.FileSuccessfullyReadEventHandler += OnFileSuccessfullyRead;

            var resultRecords = fileReader.ReadFile(@"csvfiles\cars.csv").ToList();

            int count = 0;

            foreach (var rec in resultRecords)
            {
                Console.WriteLine
                    ($"{++count} : {rec.ModelYear} , {rec.Division} , {rec.Carline} , {rec.EngDispl} , {rec.Cylinders} , {rec.CityFE} , {rec.HwyFE} , {rec.CombinedFE}");
            }
            Console.WriteLine();

            //The First 20 powerful cars
            var powerfulCars = resultRecords.OrderByDescending(c => c.EngDispl)
                                            .ThenByDescending(c => c.Cylinders)
                                            .Take(20);
            foreach (var car in powerfulCars)
            {
                Console.WriteLine($"{car.Division} , {car.Cylinders} , {car.EngDispl}");
            }
            Console.WriteLine();

            //divide the cars into groupsby devision, and then choose one car with most cityFE
            var mostCityFeCars = resultRecords.GroupBy(c => c.Division)
                                              .Select(c => new
                                              {
                                                  theKey = c.Key,
                                                  Cars = c.OrderBy(car => car.CityFE).First()
                                              });

            var mostCityFeCarsQUERY = from car in resultRecords
                                      group car by car.Division
                                      into groups
                                      select groups.OrderByDescending(c => c.CityFE).First();

            foreach (var group in mostCityFeCars)
            {
                Console.WriteLine(group.theKey);

                Console.WriteLine
                ($"{group.Cars.ModelYear} , {group.Cars.Division} , {group.Cars.Carline} , {group.Cars.EngDispl} , {group.Cars.Cylinders} , {group.Cars.CombinedFE} , {group.Cars.HwyFE} , {group.Cars.CityFE}");
            }

            Console.WriteLine();

            //devide the cars into groups by division and select the maximum and minimum cityFE of each group
            var maxCityFEofEachGroup = resultRecords.GroupBy(c => c.Division)
                                      .Select(c => new
                                      {
                                          theKey = c.Key,
                                          allCityFE = c.Select(car=>car.CityFE).Distinct(),
                                          maxCityFE = c.OrderByDescending(car=>car.CityFE).Select(car=>car.CityFE).First(),
                                          minCityFE = c.OrderBy(car=>car.CityFE).Select(car=>car.CityFE).First()
                                      });

            foreach (var car in maxCityFEofEachGroup)
            {
                Console.Write($"Devision : {car.theKey} , Max CityFE : {car.maxCityFE} , Min CityFE : {car.minCityFE} , All CityFEs : ");
                foreach (var cityFE in car.allCityFE)
                {
                    Console.Write($"{cityFE} ");
                }
                Console.WriteLine();
            }


        }

        static void OnFileSuccessfullyRead()
        {
            Console.WriteLine("File is successfully read..");
        }

    }
}