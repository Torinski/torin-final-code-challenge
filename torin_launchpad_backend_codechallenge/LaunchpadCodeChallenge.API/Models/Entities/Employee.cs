namespace LaunchpadCodeChallenge.API.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        //Relations
        public string DepartmentName { get; set; } = string.Empty;
        public Department? Department { get; set; }
    }
}
