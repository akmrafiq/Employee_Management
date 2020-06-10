using System;
using System.Collections.Generic;
using System.Text;
using static Employee_Management.Core.Entities.Enamurations;

namespace Employee_Management.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal CurrentSalary { get; set; }
        public DateTime NextReviewDate { get; set; }
    }
}
