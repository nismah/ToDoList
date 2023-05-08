using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data.Context;
using ToDoListApp.Data.Models;

namespace ToDoListApp.Services
{
    public class TaskService
    {
        private readonly IMapper _mapper;

        public TaskService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool AddNewTask(int userId, ToDoTask toDoTask)
        {
            return true;
        }

        public bool AssignTask(int userId, string memberEmail)
        {
            return true;
        }

        public bool UpdateTask(int userId, int taskId)
        {
            return true;
        }

        public IList<ToDoTask> GetAllTasks(int userId)
        {
            IList<ToDoTask> tasks = new List<ToDoTask>();

            using (var context = new ToDoListDbContext())
            {
                var user = context.Members.Where(x => x.Id == userId).Include(y => y.Tasks).FirstOrDefault();
                tasks = user.Tasks.ToList();
            }

            return tasks;
        }

    }
}
