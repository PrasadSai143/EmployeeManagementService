using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppRepository;
using AppRepository.Interfaces;
using AppService.Interfaces;
using AppService.ViewModel;
using Microsoft.EntityFrameworkCore.Internal;

namespace AppService.BusinessLogic
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeViewModel>> GetEmployees(int? id)
        {
            var employeeViewModels = new List<EmployeeViewModel>();
            var employees = await _employeeRepository.GetEmployees(id);
            if (employees != null && employees.Any())
            {
                foreach (var employee in employees)
                {
                    employeeViewModels.Add(new EmployeeViewModel()
                    {
                        Age = employee.Age,
                        Id = employee.Id,
                        Name = employee.Name,
                        Mobile = employee.Mobile,
                        Salary = employee.Salary
                    });
                }
            }

            return employeeViewModels;
        }

        public async Task<EmployeeViewModel> SaveEmployee(EmployeeViewModel employeeView)
        {
            var employe = new Employee()
            {
                Age = employeeView.Age,
                Name = employeeView.Name,
                Mobile = employeeView.Mobile,
                Salary = employeeView.Salary
            };
            var employeeResponse = await _employeeRepository.SaveEmployee(employe);
            return new EmployeeViewModel()
            {
                Age = employeeResponse.Age,
                Id = employeeResponse.Id,
                Name = employeeResponse.Name,
                Mobile = employeeResponse.Mobile,
                Salary = employeeResponse.Salary
            };
        }

        public async Task<EmployeeViewModel> UpdateEmployee(EmployeeViewModel employeeView)
        {
            if (employeeView == null)
            {
                return null;
            }

            if (await _employeeRepository.IsEmployeeExists(employeeView.Id))
            {
                var employe = new Employee()
                {
                    Id = employeeView.Id,
                    Age = employeeView.Age,
                    Name = employeeView.Name,
                    Mobile = employeeView.Mobile,
                    Salary = employeeView.Salary
                };
                var employeeResponse = await _employeeRepository.UpdateEmployee(employe);
                return new EmployeeViewModel()
                {
                    Age = employeeResponse.Age,
                    Id = employeeResponse.Id,
                    Name = employeeResponse.Name,
                    Mobile = employeeResponse.Mobile,
                    Salary = employeeResponse.Salary
                };
            }
            return null;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            if (await _employeeRepository.IsEmployeeExists(id))
            {
                return await _employeeRepository.DeleteEmployee(id);
            }
            return 0;
        }
    }
}
