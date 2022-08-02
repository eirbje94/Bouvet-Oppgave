using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwaggerProject.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string Description { get; set; } = null!;

        [ForeignKey("ProjectManager")]
        public int? EmployeeId { get; set; }
        public Employee? ProjectManager { get; set; }
        public ICollection<Epic>? Epics { get; set; }
    }
}
