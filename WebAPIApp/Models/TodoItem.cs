namespace WebAPIApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }  // Status: "Pending" or "Completed"
    }
}
