using LaunchpadCodeChallenge.API.Models.ViewModels;
using LaunchpadCodeChallenge.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaunchpadCodeChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // Dependency injection setups
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Endpoint to get all employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeVM>> Get()
        {
            try
            {
                var result = _employeeService.GetAll();

                var model = result.Select(item => new EmployeeVM(item)).ToList();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint to get all employees within a specific department
        [HttpGet("department/{departmentId}")]
        public ActionResult<IEnumerable<EmployeeVM>> Get([FromRoute] Guid departmentId)
        {
            try
            {
                var result = _employeeService.GetAll().Where(employee => employee.Department.Id == departmentId);

                var model = result.Select(item => new EmployeeVM(item)).ToList();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
