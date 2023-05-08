using ToDoListApp.Data.Models;

namespace ToDoListApp.Data
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public List<ToDoTask> Tasks { get; set; }
        public bool HasAccess { get; set; }
        public int TotalPoints { get; set; }
        public FavouriteQuote FavouriteQuote { get; set; }
    }
}
