namespace TaskAPI.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateUpdated { get; set; }
        public int Assignee { get; set; }
        public Status Status { get; set; }
        public string Estimate { get; set; } = "";
    }
}