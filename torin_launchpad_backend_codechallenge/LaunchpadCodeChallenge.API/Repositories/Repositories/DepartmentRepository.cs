using LaunchpadCodeChallenge.API.Models.Entities;
using LaunchpadCodeChallenge.API.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaunchpadCodeChallenge.API.Repositories.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> GetById(Guid id)
        {
            // Get the enitity
            var result = await _context.Departments.FirstAsync(department => department.Id == id);

            // Return the result
            return result;
        }
    }
}
