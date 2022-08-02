namespace RazorProject.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int? EmployeeId { get; set; }
        public Employee? ProjectManager { get; set; }
        public ICollection<Epic>? Epics { get; set; }
    }
}
