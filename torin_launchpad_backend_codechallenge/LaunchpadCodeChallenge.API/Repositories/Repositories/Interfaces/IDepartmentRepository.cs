using LaunchpadCodeChallenge.API.Models.Entities;

namespace LaunchpadCodeChallenge.API.Repositories.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> GetById(Guid id);
    }
}
