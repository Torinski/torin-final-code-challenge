using LaunchpadCodeChallenge.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaunchpadCodeChallenge.API.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Employee> Employees => Set<Employee>();
    }
}
