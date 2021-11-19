using Backend.Utils;
using DataBase.Models;
using DataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaWebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static UserService userService = UserService.Instance;

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                return await userService.GetUserById(id);
            }
            catch (Exception ex)
            {
                Logger.Error("Error during User API GET " + ex.Message);
                return NotFound();
            }
        }

        [HttpGet("username={username}")]
        public async Task<ActionResult<User>> Get(string username)
        {
            try
            {
                List<User> users = await userService.GetUsers();
                return users.FirstOrDefault(c => c.UserName.Equals(username));


                //return await userService.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                Logger.Error("Error during User API GET " + ex.Message);
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User value)
        {
            try
            {
                int res = userService.InsertUser(value);
                return Ok();
                
            }
            catch
            {
                return Forbid();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User value)
        {
            try
            {
                value.UserId = id;
                _ = await userService.UpdateUser(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            {
                User user = await userService.GetUserById(id);
                userService.DeleteUser(user);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
