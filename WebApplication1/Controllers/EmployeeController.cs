using System.Threading.Tasks;
using AppService.Interfaces;
using AppService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }
        [HttpGet]
        [Route("getdata")]
        public async Task<IActionResult> GetEmployees(int? id)
        {
            var employees = await _employeeService.GetEmployees(id);
            if (employees == null || !employees.Any())
            {
                return NotFound();
            }

            return Ok(employees);
        }
        [HttpPost]
        [Route("saveemployee")]
        public async Task<IActionResult> SaveEmployee(EmployeeViewModel employeeView)
        {
            var employee = await _employeeService.SaveEmployee(employeeView);
            if (employee == null)
            {
                return BadRequest();
            }

            return Ok(employee);
        }
        [HttpPut]
        [Route("updateemployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeViewModel employeeView)
        {
            var employee = await _employeeService.UpdateEmployee(employeeView);
            if (employee == null)
            {
                return BadRequest();
            }

            return Ok(employee);
        }
        [HttpDelete]
        [Route("deleteemployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id == 0)
            {
                return BadRequest("Please send id value");
            }
            var employee = await _employeeService.DeleteEmployee(id);
            if (employee == 0)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}
