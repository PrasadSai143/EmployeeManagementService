using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees(int? id);
        Task<Employee> SaveEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(int id);
        Task<bool> IsEmployeeExists(int id);
    }
}
