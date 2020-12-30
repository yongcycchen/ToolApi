using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolApi.Entities;
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
                throw new ArgumentException(nameof(employee));
            }
            _context.Employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentException(nameof(employee));
            _context.Employees.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {

        }
        public async Task<bool> EmployeeExistAsync(string FSID)
        {
            if (FSID == null)
                throw new ArgumentException(nameof(FSID));
            return await _context.Employees.AnyAsync(x => x.FSID == FSID);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(string FSID)
        {
            if (FSID == null)
                throw new ArgumentNullException(nameof(FSID));
            return await _context.Employees.Where(x=>x.FSID == FSID).FirstOrDefaultAsync();
        }


        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

    }
}
