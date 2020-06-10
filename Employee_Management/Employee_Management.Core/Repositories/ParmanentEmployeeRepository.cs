using Employee_Management.Core.Entities;
using Employee_Management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Core.Repositories
{
    public class ParmanentEmployeeRepository:Repository<ParmanenetEmployee>,IParmanentEmployeeRepository
    {
        public ParmanentEmployeeRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
