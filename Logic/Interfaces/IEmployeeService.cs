using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.ViewModel;

namespace AppService.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetEmployees(int? id);
        Task<EmployeeViewModel> SaveEmployee(EmployeeViewModel employee);
        Task<EmployeeViewModel> UpdateEmployee(EmployeeViewModel employee);
        Task<int> DeleteEmployee(int id);
    }
}
