using LaunchpadCodeChallenge.API.Models.Entities;

namespace LaunchpadCodeChallenge.API.Models.ViewModels
{
    public class EmployeeVM
    {
        public EmployeeVM() { }

        public EmployeeVM(Employee src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            JobTitle = src.JobTitle;
            Address = src.Address;
            DepartmentName = src.DepartmentName;
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        //Relations
        public string DepartmentName { get; set; } = string.Empty;
    }
}
