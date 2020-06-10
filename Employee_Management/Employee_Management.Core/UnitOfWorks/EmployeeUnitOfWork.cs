using Employee_Management.Core.Contexts;
using Employee_Management.Core.Repositories;
using Employee_Management.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Core.UnitOfWorks
{
    public class EmployeeUnitOfWork :UnitOfWork<EmployeeContext>, IEmployeeUnitOfWork
    {
        public IParmanentEmployeeRepository ParmanentEmployeeRepository { get; set; }

        public EmployeeUnitOfWork(string connectionString, string migrationAssemblyName)
             : base(connectionString, migrationAssemblyName)
        {
            ParmanentEmployeeRepository = new ParmanentEmployeeRepository(_dbContext);
        }
    }
}
