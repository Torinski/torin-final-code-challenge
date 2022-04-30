using LaunchpadCodeChallenge.API.Repositories.Repositories.Interfaces;

namespace LaunchpadCodeChallenge.API.Repositories
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }
        
        // Save method
        Task SaveAsync();
    }
}
