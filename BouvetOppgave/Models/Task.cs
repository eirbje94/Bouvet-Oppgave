namespace BouvetOppgave.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int? EpicId { get; set; }
        public Epic? Epic { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Responsible { get; set; }
    }
}
