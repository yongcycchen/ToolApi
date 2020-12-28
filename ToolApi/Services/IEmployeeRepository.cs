using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolApi.Entities;
namespace ToolApi.Services
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        Task<bool> EmployeeExistAsync(string FSID);
        Task<Employee> GetEmployeeAsync(string FSID);

        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task<bool> SaveAsync();
    }
}
