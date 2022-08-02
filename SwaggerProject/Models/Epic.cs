using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwaggerProject.Models
{
    public class Epic
    {
        [Key]
        public int EpicId { get; set; }
        public string EpicName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Task>? Tasks { get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
