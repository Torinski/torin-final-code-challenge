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
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

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
