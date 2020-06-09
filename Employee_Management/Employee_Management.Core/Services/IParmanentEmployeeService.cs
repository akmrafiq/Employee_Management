using Employee_Management.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Core.Services
{
    public interface IParmanentEmployeeService
    {
        IEnumerable<ParmanenetEmployee> GetParmanentEmployees(
           int pageIndex,
           int pageSize,   
           string searchText,
           out int total,
           out int totalFiltered);
        IEnumerable<ParmanenetEmployee> Get();
        void AddNewParmanentEmployee(ParmanenetEmployee  parmanenetEmployee);
        ParmanenetEmployee GetParmanentEmployee(int id);
        void EditParmanentEmployee(ParmanenetEmployee parmanenetEmployee);
        void DeleteParmanentEmployee(int id);
    }
}
