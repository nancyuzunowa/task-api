using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController(IConfiguration config)
        {
            Console.WriteLine(config.GetConnectionString("DefaultConnection"));
        }

        [HttpGet]
        public string GetUsers()
        {
            return "GetUsers";
        }
    }
}