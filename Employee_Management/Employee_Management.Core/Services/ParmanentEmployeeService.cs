using Employee_Management.Core.Entities;
using Employee_Management.Core.UnitOfWorks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee_Management.Core.Services
{
    public class ParmanentEmployeeService : IParmanentEmployeeService
    {
        private readonly ILogger<ParmanentEmployeeService> _logger;
        private IEmployeeUnitOfWork _employeeUnitOfWork;
        public ParmanentEmployeeService(IEmployeeUnitOfWork employeeUnitOfWork, ILogger<ParmanentEmployeeService> logger)
        {
            _logger = logger;
            _employeeUnitOfWork = employeeUnitOfWork;
        }

        public void AddNewParmanentEmployee(ParmanenetEmployee parmanenetEmployee)
        {
            try
            {
                if (parmanenetEmployee == null || string.IsNullOrWhiteSpace(parmanenetEmployee.LastName))
                    throw new InvalidOperationException("Employee last name is missing");
                _employeeUnitOfWork.ParmanentEmployeeRepository.Add(parmanenetEmployee);
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

        public void DeleteParmanentEmployee(int id)
        {
            try
            {
                var parmanentEmployee = _employeeUnitOfWork.ParmanentEmployeeRepository.GetById(id);
                _employeeUnitOfWork.ParmanentEmployeeRepository.Remove(parmanentEmployee);
                _employeeUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public void EditParmanentEmployee(ParmanenetEmployee parmanenetEmployee)
        {
            try
            {
                var oldEmployee = _employeeUnitOfWork.ParmanentEmployeeRepository.GetById(parmanenetEmployee.Id);
                oldEmployee.FirstName = parmanenetEmployee.FirstName;
                oldEmployee.LastName = parmanenetEmployee.LastName;
                oldEmployee.DateOfBirth = parmanenetEmployee.DateOfBirth;
                oldEmployee.Gender = parmanenetEmployee.Gender;
                oldEmployee.Designation = parmanenetEmployee.Designation;
                oldEmployee.Department = parmanenetEmployee.Department;
                oldEmployee.JoinDate = parmanenetEmployee.JoinDate;
                oldEmployee.CurrentSalary = parmanenetEmployee.CurrentSalary;
                oldEmployee.NextReviewDate = parmanenetEmployee.NextReviewDate;
                _employeeUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IEnumerable<ParmanenetEmployee> Get()
        {
            return _employeeUnitOfWork.ParmanentEmployeeRepository.Get();
        }

        public ParmanenetEmployee GetParmanentEmployee(int id)
        {
            return _employeeUnitOfWork.ParmanentEmployeeRepository.GetById(id);
        }

        public IEnumerable<ParmanenetEmployee> GetParmanentEmployees(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _employeeUnitOfWork.ParmanentEmployeeRepository.Get(
                out total,
                out totalFiltered,
                x => x.FirstName.Contains(searchText) ||
                    x.LastName.Contains(searchText) ||
                    x.CurrentSalary.ToString().Contains(searchText) ||
                    x.Designation.Contains(searchText) ||
                    x.Department.Contains(searchText),
                x => x.OrderByDescending(e => e.Id),
                "",
                pageIndex,
                pageSize,
                true);
        }
    }
}
