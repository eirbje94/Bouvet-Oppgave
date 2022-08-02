using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwaggerProject.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public string Description { get; set; } = null!;

        [ForeignKey("Epic")]
        public int? EpicId { get; set; }
        public Epic? Epic { get; set; }
        [ForeignKey("Responsible")]
        public int? EmployeeId { get; set; }
        public Employee? Responsible { get; set; }
    }
}
