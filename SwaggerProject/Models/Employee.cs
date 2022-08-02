using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwaggerProject.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}
