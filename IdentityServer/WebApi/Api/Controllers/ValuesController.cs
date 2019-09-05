using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid id)
        {
            return new User
            {
                Id = id,
                UserName = "Jensen Wang",
                AvatarUrl = "https://avatars3.githubusercontent.com/u/29560139?v=4"
            };
        }
    }
}
