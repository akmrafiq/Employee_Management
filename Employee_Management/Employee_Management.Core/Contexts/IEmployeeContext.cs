using Employee_Management.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Core.Contexts
{
    public interface IEmployeeContext
    {
        DbSet<Employee> Employees { get; set; }
    }
}
