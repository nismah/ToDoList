using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Services;

namespace ToDoListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly TaskService _taskService;

        public TasksController(ILogger<TasksController> logger, TaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpPost("AddNewTask")]
        public HttpResponse AddNewTask()
        {
            //Add new task
            return null;
        }

        [HttpPost("AssignTask")]
        public HttpResponse AssignTask()
        {
            //assign a task
            return null;
        }

        [HttpPost("UpdateTaskStatus")]
        public HttpResponse UpdateTaskStatus()
        {
            //update a task
            return null;
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks(int userId)
        {
            var result = _taskService.GetAllTasks(userId);
            return Ok(result);
        }
    }
}