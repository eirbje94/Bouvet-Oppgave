using Microsoft.AspNetCore.Mvc;

namespace BouvetOppgave.Models
{
    public class Epic
    {
        public int EpicId { get; set; }
        public string EpicName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Task>? Tasks { get; set; }

        [BindProperty]
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
