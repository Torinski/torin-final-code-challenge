using LaunchpadCodeChallenge.API.Models.Entities;
using LaunchpadCodeChallenge.API.Repositories;
using LaunchpadCodeChallenge.API.Services.Interfaces;

namespace LaunchpadCodeChallenge.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        // Dependency injection setup
        private readonly IUnitOfWork _uow;

        public EmployeeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Employee> GetAll()
        {
            // Setup test data
            var departments = new List<Department>();
            departments.Add(new Department() { Id = new Guid("8acf5ae0-320e-418a-aea8-000000000000"), Address = "11 Accounting Ave", Name = "Accounting", Employees = new List<Employee>() });
            departments.Add(new Department() { Id = new Guid("8acf5ae0-320e-418a-aea8-111111111111"), Address = "11 Merchants Ave", Name = "Marketing", Employees = new List<Employee>() });
            var employees = new List<Employee>();
            employees.Add(new Employee() { Id = new Guid("8acf5ae0-320e-418a-aea8-222222222222"), FirstName = "John", LastName = "Doe", Address = "123 Made Up St", JobTitle = "Accountant", DepartmentName = "Accounting", Department = departments[0] });
            employees.Add(new Employee() { Id = new Guid("8acf5ae0-320e-418a-aea8-333333333333"), FirstName = "Jane", LastName = "Doe", Address = "127 Made Up St", JobTitle = "Accountant", DepartmentName = "Accounting", Department = departments[0] });
            employees.Add(new Employee() { Id = new Guid("8acf5ae0-320e-418a-aea8-444444444444"), FirstName = "James", LastName = "Doe", Address = "300 Made Up St", JobTitle = "Marketer", DepartmentName = "Martketing", Department = departments[1] });
            departments[0].Employees.Add(employees[0]);
            departments[0].Employees.Add(employees[1]);
            departments[1].Employees.Add(employees[2]);

            /* To Use If Database Was Implemented:
            
            // Add async to method call and grab employee data from DbSet 
            var employees = await _uow.Employees.GetAll();
             
             */

            // Return employees
            return employees;
        }

        public IList<Employee> ListAll()
        {
            // Grab employee data
            var employees = GetAll().ToList();

            // List all employees in console
            foreach (var employee in employees)
            {
                System.Console.WriteLine(employee.FirstName + " " + employee.LastName);
            }

            // Return employee list
            return employees;
        }
    }
}
