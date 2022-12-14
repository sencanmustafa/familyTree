using System;
using System.Globalization;
using System.Reflection.PortableExecutable;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Entities;

namespace Business
{
    public class ReadCsv
    {
        public List<Person> readExcelReturnPersonList()
        {
            List<Person> personList = new List<Person>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            string csvFilePath = "/Users/mustafasencan/Desktop/software/familyTree/familiyTree/ConsoleUI/exp1-2.csv";
            //var streamReader = new StreamReader(csvFilePath);

            //var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture,);
            var reader = new StreamReader(csvFilePath);
            var csv = new CsvReader(reader, config);

            csv.Context.RegisterClassMap<MapPersonToCsvReader>();
            var records = csv.GetRecords<Person>().ToList();
            for (int i = 0; i < records.Count(); i++)
            {
                personList.Add(records[i]);
            }

            //csvReader.Context.RegisterClassMap<PersonMap>();
            //var records = csvReader.GetRecords<Person2>().ToList();

            Console.WriteLine("READED");
            return personList;
        }
    }
}

