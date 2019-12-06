using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Assignment6._1
{
    class FileReader
    {
        public event Action FileSuccessfullyReadEventHandler;

        public List<Car> ReadFile(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                throw new Exception("Path is not correct");
            }

            if (Path.GetExtension(filePath) != ".csv")
            {
                throw new Exception("file is not a csv file");
            }

            var reader = new StreamReader(filePath);

            List<Car> recordsInFile = new List<Car>() ;

            using (var csv = new CsvReader(reader))
            {
                //The GetRecords<T> method will return an IEnumerable<T> that will yield records

                foreach (var record in csv.GetRecords<Car>())
                {
                    recordsInFile.Add(record);
                }
            }

            FileSuccessfullyReadEventHandler?.Invoke();  //raise this event when file is read

            return recordsInFile;
        }
    }
}