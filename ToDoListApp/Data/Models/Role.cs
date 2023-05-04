using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Data.Models
{
    public partial class Role
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeRole { get; set; }
    }
}