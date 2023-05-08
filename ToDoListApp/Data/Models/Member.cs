using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Data.Models
{
    public partial class Member
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public List<ToDoTask> Tasks { get; set; }
        public bool HasAccess { get; set; }
        public int TotalPoints { get; set; }

    }
}
