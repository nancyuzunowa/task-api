using Microsoft.AspNetCore.Mvc;
using TaskAPI.Data;
using TaskAPI.Models;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContextDapper _dapper;

        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("TestConnection")]
        public DateTime GetDateTime()
        {
            return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            string sql = "SELECT * FROM TaskAppSchema.Users";
            return _dapper.LoadData<User>(sql);
        }
    }
}