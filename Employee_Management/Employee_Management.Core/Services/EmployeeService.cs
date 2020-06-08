using Employee_Management.Core.Entities;
using Employee_Management.Core.UnitOfWorks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee_Management.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private IEmployeeUnitOfWork _employeeUnitOfWork;
        public EmployeeService( ILogger<EmployeeService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Employee> Get()
        {
            return _employeeUnitOfWork.EmployeeRepository.Get();
        }

        public void AddNewEmployee(Employee employee)
        {
            try
            {
                if (employee == null || string.IsNullOrWhiteSpace(employee.LastName))
                    throw new InvalidOperationException("Employee last name is missing");
                _employeeUnitOfWork.EmployeeRepository.Add(employee);
                _employeeUnitOfWork.Save();

            }
            catch (InvalidOperationException e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                var employee = _employeeUnitOfWork.EmployeeRepository.GetById(id);
                _employeeUnitOfWork.EmployeeRepository.Remove(employee);
                _employeeUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public void EditEmployee(Employee employee)
        {
            try
            {
                var oldEmployee = _employeeUnitOfWork.EmployeeRepository.GetById(employee.Id);
                oldEmployee.FirstName = employee.FirstName;
                oldEmployee.LastName = employee.LastName;
                oldEmployee.DateOfBirth = employee.DateOfBirth;
                oldEmployee.Gender = employee.Gender;
                oldEmployee.Designation = employee.Designation;
                oldEmployee.Department = employee.Department;
                oldEmployee.JoinDate = employee.JoinDate;
                oldEmployee.CurrentSalary = employee.CurrentSalary;
                oldEmployee.NextReviewDate = employee.NextReviewDate;
                _employeeUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        

        public IEnumerable<Employee> GetEmployees( 
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _employeeUnitOfWork.EmployeeRepository.Get(
                out total,
                out totalFiltered,
                x => x.FirstName.Contains(searchText)||
                    x.LastName.Contains(searchText)||
                    x.CurrentSalary.ToString().Contains(searchText)||
                    x.Designation.Contains(searchText)||
                    x.Department.Contains(searchText),
                x => x.OrderByDescending(e=>e.Id),
                "",
                pageIndex,
                pageSize,
                true);
        }

        public Employee GetEmployee(int id)
        {
            return _employeeUnitOfWork.EmployeeRepository.GetById(id);
        }
    }
}
