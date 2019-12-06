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

            fileReader.FileSuccessfullyRead += OnFileSuccessfullyRead;

            var resultRecords = fileReader.ReadFile(@"C:\Users\artavazd.trtrian\source\repos\Assignment1\Assignment6.1\csvfiles\cars.csv").ToList();

            int count = 0;

            foreach (var rec in resultRecords)
            {
                Console.WriteLine
                    ($"{++count} : {rec.ModelYear} , {rec.Division} , {rec.Carline} , {rec.EngDispl} , {rec.Cylinders} , {rec.CityFE} , {rec.HwyFE} , {rec.CombinedFE}");
            }
        }

        static void OnFileSuccessfullyRead()
        {
            Console.WriteLine("File is successfully read..");
        }

    }
}