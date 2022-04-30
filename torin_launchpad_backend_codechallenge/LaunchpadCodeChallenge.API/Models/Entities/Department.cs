namespace LaunchpadCodeChallenge.API.Models.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Address { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        
        public ICollection<Employee> Employees = new List<Employee>();
    }
}
