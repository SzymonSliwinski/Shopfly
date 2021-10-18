﻿using System.Collections.Generic;
using System.Security.Cryptography;

namespace GenerateRandomData.Models.ShopPanelModels
{
    public class Employee
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }    // todo length of string
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<EmployeesProfiles> EmployeesProfiles { get; set; }
    }
}
