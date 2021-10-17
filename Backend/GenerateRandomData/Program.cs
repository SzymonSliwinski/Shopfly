using System;
using System.Collections.Generic;
using System.IO;
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
            string savePath = @"../../generatedJson/";
            string dateFile = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            Console.Write("Enter number of generated positions: ");
            int numberOfPositions = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of positions in each file = " + numberOfPositions);

            // wywołanie funkcji generujących dane:
            GenerateEmployee(numberOfPositions, true, savePath, dateFile);
            GenerateEmployeesProfiles(numberOfPositions, true, savePath, dateFile);
            GeneratePrivilege(numberOfPositions, true, savePath, dateFile);
            GenerateProfile(numberOfPositions, true, savePath, dateFile);
            GenerateProfilesPrivileges(numberOfPositions, true, savePath, dateFile);
        }

        static Faker<Employee> GenerateEmployee(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var employeeData = new Faker<Employee>("pl")
                //.CustomInstantiator(e => new Employee())
                //.RuleFor(e => e.Id, e => e.Random.Int(1, int.MaxValue))
                .StrictMode(false)
                //.RuleFor(e => e.Id, e => e.IndexFaker)
                //.Ignore(e => e.Id)
                .RuleFor(e => e.Name, e => e.Name.FirstName())
                .RuleFor(e => e.Surname, e => e.Name.LastName())
                .RuleFor(e => e.Email, e => e.Internet.Email())
                .RuleFor(e => e.IsActive, e => e.Random.Bool())
                .RuleFor(e => e.Password, e => e.Internet.Password(12, false));
                //.Ignore(e => e.EmployeesProfiles);

            if (saveToFile)
            {
                // generowanie danych:
                List<Employee> myEmployee = employeeData.Generate(numberOfPositions);
                //var myEmployee = employeeData.Generate();
                //myEmployee.Dump();
                //var faker = AutoFaker.Create();
                //faker.Generate<Profile>();

                // zapis do pliku:
                string fileName = "employee_" + dateFile + ".json";

                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myEmployee);
                }

                Console.WriteLine("file " + fileName + " generated");
            }

            return employeeData;
        }

        static Faker<EmployeesProfiles> GenerateEmployeesProfiles(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            var employeesProfilesData = new Faker<EmployeesProfiles>("pl")
                .RuleFor(ep => ep.EmployeeId, ep => ep.Random.Int(1, numberOfPositions))
                .RuleFor(ep => ep.ProfileId, ep => ep.Random.Int(1, numberOfPositions));
                

            if (saveToFile)
            {
                List<EmployeesProfiles> myEmployeesProfiles = employeesProfilesData.Generate(numberOfPositions);

                string fileName = "employeesProfiles_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myEmployeesProfiles);
                }

                Console.WriteLine("file " + fileName + " generated");
            }

            return employeesProfilesData;

            //List < Employee > myEmployeeList = new List<Employee>();
            //List<Profile> myProfileList = new List<Profile>();

            /*
            //var employeesProfilesData = new Faker<EmployeesProfiles>(locale: "pl")
            //    .CustomInstantiator(ep => new EmployeesProfiles())
            var employeesProfilesData = new Faker(locale: "pl")
                .(ep => new EmployeesProfiles())

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
            */
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

        static Faker<Privilege> GeneratePrivilege(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var privilegeData = new Faker<Privilege>("pl")
                .RuleFor(p => p.Name, p => p.Lorem.Word());

            // zapis do pliku:
            if (saveToFile)
            {
                List<Privilege> myPrivilege = privilegeData.Generate(numberOfPositions);

                string fileName = "privilege_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myPrivilege);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return privilegeData;
        }

        static Faker<Profile> GenerateProfile(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var profileData = new Faker<Profile>("pl")
                .RuleFor(p => p.Name, p => p.Lorem.Word());

            // zapis do pliku:
            if (saveToFile)
            {
                List<Profile> myProfile = profileData.Generate(numberOfPositions);

                string fileName = "profile_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProfile);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return profileData;
        }

        static Faker<ProfilesPrivileges> GenerateProfilesPrivileges(int numberOfPositions, bool saveToFile, string savePath, string dateFile)
        {
            // ustawienie właściwości:
            var profilesPrivilegesData = new Faker<ProfilesPrivileges>("pl")
                .RuleFor(pp => pp.ProfileId, pp => pp.Random.Int(1, numberOfPositions))
                .RuleFor(pp => pp.PrivilegeId, pp => pp.Random.Int(1, numberOfPositions));

            // zapis do pliku:
            if (saveToFile)
            {
                List<ProfilesPrivileges> myProfilesPrivileges = profilesPrivilegesData.Generate(numberOfPositions);

                string fileName = "profilesPrivileges_" + dateFile + ".json";
                using (StreamWriter file = File.CreateText(savePath + fileName))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, myProfilesPrivileges);
                }

                Console.WriteLine("file " + fileName + " generated");
            }
            return profilesPrivilegesData;
        }

    }
}
