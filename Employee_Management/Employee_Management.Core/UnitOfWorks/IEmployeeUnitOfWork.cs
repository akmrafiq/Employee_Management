using Employee_Management.Core.Contexts;
using Employee_Management.Core.Repositories;
using Employee_Management.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Core.UnitOfWorks
{
    interface IEmployeeUnitOfWork:IUnitOfWork<EmployeeContext>
    {
        IEmployeeRepository EmployeeRepository { get; set; }
    }
}
