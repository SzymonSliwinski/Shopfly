using System.Collections.Generic;

namespace Common.Models.ShopPanelModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }    // todo length of string
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }//todo
        public List<EmployeesProfiles> EmployeesProfiles { get; set; }
    }
}
