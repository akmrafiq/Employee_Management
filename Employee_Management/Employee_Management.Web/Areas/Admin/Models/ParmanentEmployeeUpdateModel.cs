using Employee_Management.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Employee_Management.Core.Entities.Enamurations;

namespace Employee_Management.Web.Areas.Admin.Models
{
    public class ParmanentEmployeeUpdateModel:BaseModel
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
