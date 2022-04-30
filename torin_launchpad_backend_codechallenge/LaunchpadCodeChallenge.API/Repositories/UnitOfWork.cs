using LaunchpadCodeChallenge.API.Repositories.Repositories;
using LaunchpadCodeChallenge.API.Repositories.Repositories.Interfaces;

namespace LaunchpadCodeChallenge.API.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public IDepartmentRepository Departments {get; private set;}
        public IEmployeeRepository Employees {get; private set;}

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Departments = new DepartmentRepository(context);
            Employees = new EmployeeRepository(context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
