using LaunchpadCodeChallenge.API.Models.Entities;

namespace LaunchpadCodeChallenge.API.Models.ViewModels
{
    public class DepartmentVM
    {
        public DepartmentVM() { }

        public DepartmentVM(Department src)
        {
            Id = src.Id;
            Address = src.Address;
            Name = src.Name;
            Employees = src.Employees;
        }

        public Guid Id { get; set; }
        public string Address { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public ICollection<Employee> Employees = new List<Employee>();
    }
}
