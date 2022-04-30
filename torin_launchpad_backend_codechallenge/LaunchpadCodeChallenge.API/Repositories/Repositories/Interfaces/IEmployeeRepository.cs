using LaunchpadCodeChallenge.API.Models.Entities;

namespace LaunchpadCodeChallenge.API.Repositories.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
    }
}
