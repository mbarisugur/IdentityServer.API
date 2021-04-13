using IdentityServer.API1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IdentityServer.API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [Authorize(Policy = "ReadUser")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var userList = new List<User>()
            {
                new User { Id = 1, Name = "Mustafa Barış", RoleName = "Kullanıcı", Surname = "Uğur" },
                new User { Id = 1, Name = "Onur", RoleName = "Admin", Surname = "Doğan" },
                new User { Id = 1, Name = "Muhammed Ali", RoleName = "Admin", Surname = "Kadıoğlu" }
            };

            return Ok(userList);
        }

        [Authorize(Policy = "UpdateOrCreate")]
        [HttpPost]
        public IActionResult UpdateUser(int id)
        {
            return Ok($"id'si {id} olan kullanıcı güncellendi.");
        }

        [Authorize(Policy = "UpdateOrCreate")]
        [HttpPost]
        public IActionResult CreateUser(User user)
        {

            return Ok($"Adı {user.Name} olan kullanıcı eklendi.");
        }
    }
}
