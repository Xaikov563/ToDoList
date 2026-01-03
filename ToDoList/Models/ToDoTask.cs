namespace ToDoList.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.Now;

        public bool is_Completed { get; set; } = false; 
    }
}
