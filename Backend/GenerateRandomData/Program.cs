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

            // wywołanie funkcji generujących dane:
            GenerateEmployee(numberOfPositions, true);
            GenerateEmployeesProfiles(numberOfPositions);
        }

        static Faker<Employee> GenerateEmployee(int numberOfPositions, bool saveToFile)
        {
            var employeeData = new Faker<Employee>("pl")
                //.CustomInstantiator(e => new Employee())
                //.RuleFor(e => e.Id, e => e.Random.Int(1, int.MaxValue))
                .RuleFor(e => e.Name, e => e.Name.FirstName())
                .RuleFor(e => e.Surname, e => e.Name.LastName())
                .RuleFor(e => e.Email, e => e.Internet.Email())
                .RuleFor(e => e.IsActive, e => e.Random.Bool())
                .RuleFor(e => e.Password, e => e.Internet.Password(12, false));

            if (saveToFile)
            {
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

            return employeeData;
        }

        static void GenerateEmployeesProfiles(int numberOfPositions)
        {
            List<Employee> myEmployeeList = new List<Employee>();
            List<Profile> myProfileList = new List<Profile>();

            var employeesProfilesData = new Faker<EmployeesProfiles>(locale: "pl")
                .CustomInstantiator(ep => new EmployeesProfiles())

                .RuleFor(ep => ep.EmployeeId, ep => ep.IndexFaker)
                //.RuleFor(ep => ep.Employee, ep => GenerateEmployee(1, false))
                .RuleFor(ep => ep.ProfileId, ep => ep.IndexFaker);
                //.RuleFor(ep => ep.Profile, ep => ep.);

            // generowanie danych:
            List<EmployeesProfiles> myEmployeeProfiles = employeesProfilesData.Generate(numberOfPositions);

            // zapis do pliku:
            string randomFileName = Path.GetRandomFileName();

            using (StreamWriter file = File.CreateText(@"../../generatedJson/employeesProfiles_" + randomFileName + ".json"))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, myEmployeeProfiles);
            }
            Console.WriteLine("file " + randomFileName + " generated");
        }
        /*
        static Faker<Profile> GenerateProfile(int numberOfPositions, bool saveToFile)
        {
            var profileData = new Faker<Profile>("pl")
                .CustomInstantiator(p => new Profile())
                .RuleFor(p => p.Id, p => p.Random.Int(1, int.MaxValue))
                .RuleFor(p => p.Name, p => p.Random.String(2, 15))
                //.RuleFor(p=>p.ProfilesPrivileges,p=>gen)  //todo
                .RuleFor(p => p.EmployeesProfiles, p => GenerateEmployeesProfiles(1));
        }
        */
    }
}
