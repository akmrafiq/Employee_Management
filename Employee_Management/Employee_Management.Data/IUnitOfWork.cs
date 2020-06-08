using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Data
{
    public interface IUnitOfWork<T> :IDisposable where T:DbContext
    {
        void Save();
    }
}
