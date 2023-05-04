using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Data.Models
{
    public partial class ToDoTask
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Points { get; set; }
    }
}
