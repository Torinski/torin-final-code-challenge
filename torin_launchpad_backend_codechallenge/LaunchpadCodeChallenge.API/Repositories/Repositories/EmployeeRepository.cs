using LaunchpadCodeChallenge.API.Models.Entities;
using LaunchpadCodeChallenge.API.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaunchpadCodeChallenge.API.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        // Dependency injection setup
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            // Get list of all listings
            var results = await _context.Employees.ToListAsync();

            // Return the results
            return results;
        }
    }
}
