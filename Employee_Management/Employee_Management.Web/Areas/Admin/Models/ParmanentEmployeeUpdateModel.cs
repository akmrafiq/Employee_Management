using Autofac;
using Employee_Management.Core.Entities;
using Employee_Management.Core.Services;
using Microsoft.Extensions.Logging;
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
        public PaymentType PaymentType { get; set; } = PaymentType.BankTransfer;


        private IParmanentEmployeeService _parmanentEmployeeService;
        private readonly ILogger<ParmanentEmployeeUpdateModel> _logger;

        public ParmanentEmployeeUpdateModel()
        {
            _parmanentEmployeeService = Startup.AutofacContainer.Resolve<IParmanentEmployeeService>();
            _logger = Startup.AutofacContainer.Resolve<ILogger<ParmanentEmployeeUpdateModel>>();
        }

        public ParmanentEmployeeUpdateModel(IParmanentEmployeeService parmanentEmployeeService, ILogger<ParmanentEmployeeUpdateModel> logger)
        {
            _parmanentEmployeeService = parmanentEmployeeService;
            _logger = logger;
        }

        public void AddNewParmanentEmployee()
        {
            try
            {
                _parmanentEmployeeService.AddNewParmanentEmployee(new ParmanenetEmployee
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    DateOfBirth = this.DateOfBirth,
                    Gender = this.Gender,
                    Designation = this.Designation,
                    Department=this.Department,
                    JoinDate= this.JoinDate,
                    CurrentSalary=this.CurrentSalary,
                    PaymentType=this.PaymentType,
                     NextReviewDate=this.NextReviewDate
                });

                Notification = new NotificationModels("Success!", "Supplier successfuly created", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModels(
                    "Failed!",
                    "Failed to create parmanent employee, please provide valid info",
                    NotificationType.Fail);
                _logger.LogError(iex.Message);

            }
            catch (Exception ex)
            {
                Notification = new NotificationModels(
                    "Failed!",
                    "Failed to create employee, please try again",
                    NotificationType.Fail);

                _logger.LogError(ex.Message);

            }
        }

        public void EditParmanentEmployee()
        {
            try
            {
                _parmanentEmployeeService.EditParmanentEmployee(new ParmanenetEmployee
                {
                    Id = this.Id,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    DateOfBirth = this.DateOfBirth,
                    Gender = this.Gender,
                    Designation = this.Designation,
                    Department = this.Department,
                    JoinDate=this.JoinDate,
                    CurrentSalary=this.CurrentSalary,
                    PaymentType=this.PaymentType,
                    NextReviewDate=this.NextReviewDate
                });

                Notification = new NotificationModels("Success!", "Parmanent Employee successfuly updated", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModels(
                    "Failed!",
                    "Failed to update Parmanent Employee, please provide valid info",
                    NotificationType.Fail);
                _logger.LogError(iex.Message);

            }
            catch (Exception ex)
            {
                Notification = new NotificationModels(
                    "Failed!",
                    "Failed to update supplier, please try again",
                    NotificationType.Fail);

                _logger.LogError(ex.Message);
            }
        }

        public void Load(int id)
        {
            var parmanenetEmployee = _parmanentEmployeeService.GetParmanentEmployee(id);
            if (parmanenetEmployee != null)
            {
                Id = parmanenetEmployee.Id;
                FirstName = parmanenetEmployee.FirstName;
                LastName = parmanenetEmployee.LastName;
                DateOfBirth = parmanenetEmployee.DateOfBirth;
                Gender = parmanenetEmployee.Gender;
                Designation = parmanenetEmployee.Designation;
                Department = parmanenetEmployee.Department;
                JoinDate = parmanenetEmployee.JoinDate;
                CurrentSalary = parmanenetEmployee.CurrentSalary;
                PaymentType = parmanenetEmployee.PaymentType;
                NextReviewDate = parmanenetEmployee.NextReviewDate;
            }
        }
    }
}
