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
            List<int> intList = new List<int>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            string csvFilePath = "/Users/mustafasencan/Desktop/software/farmilyTree/ConsoleUI/exp1-3.csv";
            //string csvFilePath = @"C:\Users\pc\Masaüstü\Software\farmilyTree\ConsoleUI\exp1-2.csv";
            //var streamReader = new StreamReader(csvFilePath);

            //var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture,);
            var reader = new StreamReader(csvFilePath);
            var csv = new CsvReader(reader, config);

            csv.Context.RegisterClassMap<MapPersonToCsvReader>();
            var records = csv.GetRecords<Person>().ToList();
            /*
            for (int i = 0; i < records.Count(); i++)
            {
                if (intList.Contains(Int32.Parse(records[i].id)))
                {
                    continue;
                }
                intList.Add(Int32.Parse(records[i].id));
                personList.Add(records[i]);
            }
            */
            for (int i = 0; i < records.Count(); i++)
            {
                if (intList.Contains(records[i].id))
                {
                    continue;
                }
                intList.Add(records[i].id);
                personList.Add(records[i]);
            }

            //csvReader.Context.RegisterClassMap<PersonMap>();
            //var records = csvReader.GetRecords<Person2>().ToList();

            Console.WriteLine("READED");
            foreach (var item in personList)
            {
                item.bornDate = DateOnly.Parse(item.DogumTarihiOld);
            }
            
            return personList;
        }
    }
}

