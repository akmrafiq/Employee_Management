using Employee_Management.Core.Entities;
using Employee_Management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Core.Repositories
{
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
