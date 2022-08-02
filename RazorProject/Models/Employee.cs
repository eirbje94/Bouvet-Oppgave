namespace RazorProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}
