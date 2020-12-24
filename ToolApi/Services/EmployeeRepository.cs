using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolApi.Entities;
using ToolApi.Services;
using ToolApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ToolApi.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RoutineDbContext _context;

        public EmployeeRepository(RoutineDbContext Context)
        {
            _context = Context ?? throw new ArgumentException(nameof(Context));
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            //employee.
            _context.Employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            _context.Employees.Remove(employee);
        }

        public async Task<bool> EmployeeExistAsync(string FSID)
        {
            if (FSID == null)
                throw new ArgumentNullException(nameof(FSID));
            return await _context.Employees.AnyAsync(x => x.FSID == FSID);
            //throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployeeAsync(string FSID)
        {
            if (FSID == null)
                throw new ArgumentNullException(nameof(FSID));
            return await _context.Employees.Where(x=>x.FSID == FSID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
