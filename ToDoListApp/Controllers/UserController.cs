using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using ToDoListApp.Data;
using ToDoListApp.Data.Context;
using ToDoListApp.Services;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("CreateNewUser")]
        public HttpResponse CreateNewUser()
        {
            //Add new task
            return null;
        }

        [HttpGet("members")]
        public async Task<IActionResult> GetUsers(int userId)
        {
            return Ok(_userService.GetAllMembers(userId));
        }    
    }
}
