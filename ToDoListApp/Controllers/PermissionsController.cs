using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Services;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly ILogger<PermissionsController> _logger;
        private readonly UserService _userService;

        public PermissionsController(ILogger<PermissionsController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("AddPermissions")]
        public HttpResponse AddPermissions(int userId, string memberEmail)
        {
            var result = _userService.AddPermissions(userId, memberEmail);
            return null;
        }

        [HttpPost("RemovePermissions")]
        public HttpResponse RemovePermissions()
        {
            //assign a task
            return null;
        }
    }
}
