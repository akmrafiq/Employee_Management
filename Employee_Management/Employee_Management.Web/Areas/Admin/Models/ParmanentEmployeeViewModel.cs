using Autofac;
using Employee_Management.Core.Services;
using Employee_Management.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Web.Areas.Admin.Models
{
    public class ParmanentEmployeeViewModel : BaseModel
    {
        private IParmanentEmployeeService _parmanentEmployeeService;

        public ParmanentEmployeeViewModel(IParmanentEmployeeService parmanentEmployeeService)
        {
            _parmanentEmployeeService = parmanentEmployeeService;
        }

        public ParmanentEmployeeViewModel()
        {
            _parmanentEmployeeService = Startup.AutofacContainer.Resolve<IParmanentEmployeeService>();
        }

        public object GetEmployees(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _parmanentEmployeeService.GetParmanentEmployees(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.FirstName,
                                record.LastName,
                                record.DateOfBirth.ToShortDateString(),
                                record.Gender.ToString(),
                                record.Designation,
                                record.Department,
                                record.JoinDate.ToShortDateString(),
                                record.CurrentSalary.ToString(),
                                record.PaymentType.ToString(),
                                record.NextReviewDate.ToShortDateString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };

        }

        public void Delete(int id)
        {
            _parmanentEmployeeService.DeleteParmanentEmployee(id);
        }
    }
}
