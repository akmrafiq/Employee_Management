using Autofac;
using Employee_Management.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Web.Areas.Admin.Models
{
    public class EmployeeViewModel:BaseModel
    {
        private IEmployeeService _employeeService;

        public EmployeeViewModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
        }
    }
}
