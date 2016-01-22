using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace CsvStringToObject
{
    public class Customer
    {
        public string Name { set; get; }
        public string City { set; get; }
    }

    public sealed class CustomerCsvMap : CsvClassMap<Customer>
    {
        public CustomerCsvMap()
        {
            Map(c => c.Name).Index(0);
            Map(c => c.City).Index(1);
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            using (var stringReader = new StringReader("Justin,Lincoln\nGeorge,Omaha"))
            {
                using (var csvReader = new CsvReader(stringReader))
                {
                    csvReader.Configuration.HasHeaderRecord = false;
                    csvReader.Configuration.RegisterClassMap<CustomerCsvMap>();

                    var customers = csvReader.GetRecords<Customer>();

                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"{customer.Name} {customer.City}");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
