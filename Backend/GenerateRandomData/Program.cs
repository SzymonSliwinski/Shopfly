using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Bogus;
using Common.Models.ShopPanelModels;
using Newtonsoft.Json;

namespace GenerateRandomData
{
    class Program
    {
         static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory(@"../../generatedJson");

            Console.Write("Enter number of generated positions: ");
            int numberOfPositions = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of positions in each file = " + numberOfPositions);

            GenerateEmployee(numberOfPositions);
        }

        static void GenerateEmployee(int numberOfPositions)
        {

            var employeeData = new Faker<Employee>("pl")
                .CustomInstantiator(e => new Employee())
                .RuleFor(e => e.Id, e => e.Random.Int(1, int.MaxValue))
                .RuleFor(e => e.Name, e => e.Name.FirstName())
                .RuleFor(e => e.Surname, e => e.Name.LastName())
                .RuleFor(e => e.Email, e => e.Internet.Email())
                .RuleFor(e => e.IsActive, e => e.Random.Bool())
                .RuleFor(e => e.Password, e => e.Internet.Password(12, false));

            // generowanie danych:
            List<Employee> myEmployee = employeeData.Generate(numberOfPositions);

            // zapis do pliku:
            string randomFileName = Path.GetRandomFileName();

            using (StreamWriter file = File.CreateText(@"../../generatedJson/employee_" + randomFileName + ".json"))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, myEmployee);
            }
            Console.WriteLine("file " + randomFileName + " generated");

        }
    }
}
