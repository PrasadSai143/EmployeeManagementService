using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppRepository.Implementation
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext=employeeDbContext;
        }
        public async Task<List<Employee>> GetEmployees(int? id)
        {
            if (id != null)
            {
                return await _employeeDbContext.Employees.AsNoTracking().Where(i => i.Id == id).ToListAsync();
            }

            return await _employeeDbContext.Employees.AsNoTracking().ToListAsync();
        }

        public async Task<Employee> SaveEmployee(Employee employee)
        {
            await _employeeDbContext.Employees.AddAsync(employee);
            await _employeeDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _employeeDbContext.Employees.Update(employee);
            await _employeeDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var employee = await _employeeDbContext.Employees.FindAsync(id);
            _employeeDbContext.Employees.Remove(employee);
            var val = await _employeeDbContext.SaveChangesAsync();
            return val;
        }

       public async Task<bool> IsEmployeeExists(int id)
       {
          var data = await _employeeDbContext.Employees.AsNoTracking().FirstOrDefaultAsync(i => i.Id==id);
          return data != null;
       }
    }
}
