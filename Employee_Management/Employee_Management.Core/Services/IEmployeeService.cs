using Employee_Management.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Core.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees(
           int pageIndex,
           int pageSize,   
           string searchText,
           out int total,
           out int totalFiltered);
        IEnumerable<Employee> Get();
        void AddNewEmployee(Employee employee);
        Employee GetEmployee(int id);
        void EditEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
