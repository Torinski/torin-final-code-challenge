using LaunchpadCodeChallenge.API.Models.Entities;

namespace LaunchpadCodeChallenge.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        IList<Employee> ListAll();
    }
}
