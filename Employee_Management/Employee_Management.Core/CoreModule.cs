using Autofac;
using Employee_Management.Core.Contexts;
using Employee_Management.Core.Repositories;
using Employee_Management.Core.Services;
using Employee_Management.Core.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management.Core
{
    public class CoreModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public CoreModule(string connectionStringName, string migrationAssemblyName)
        {
            _connectionString = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeContext>().As<IEmployeeContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeUnitOfWork>().As<IEmployeeUnitOfWork>()
                  .WithParameter("connectionString", _connectionString)
                  .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                  .InstancePerLifetimeScope();


            builder.RegisterType<ParmanentEmployeeRepository>().As<IParmanentEmployeeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ParmanentEmployeeService>().As<IParmanentEmployeeService>()
                .InstancePerLifetimeScope();
                       
            base.Load(builder);
        }
    }
}
