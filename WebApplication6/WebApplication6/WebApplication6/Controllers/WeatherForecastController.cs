using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Supabase.Client _supabaseClient;
        private readonly SupaBaseContext _supabaseContext;

        public WeatherForecastController(Supabase.Client supabaseClient, SupaBaseContext supaBaseContext)
        {
            _supabaseClient = supabaseClient;
            _supabaseContext = supaBaseContext;
        }

        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        public async Task<string> GetAllUsers()
        {
            try
            {
                var result = await _supabaseContext.GetUsers(_supabaseClient);
                return JsonConvert.SerializeObject(result, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        [HttpPost("AddNewUser", Name = "AddNewUser")]
        public async Task<IActionResult> AddUser([FromBody] User newUser)
        {
            try
            {
                var result = await _supabaseContext.AddUser(_supabaseClient, newUser);
                if (result != null)
                {
                    return CreatedAtAction(nameof(AddUser), new { id = result.Id }, result);
                }
                else
                {
                    return BadRequest("User creation failed");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("DeleteUser", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] User user)
        {
            try
            {
                var result = await _supabaseContext.DeleteUser(_supabaseClient, user);
                if (result)
                {
                    return Ok("User deleted successfully");
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("UpdateUser", Name = "UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User updatedUser)
        {
            try
            {
                var result = await _supabaseContext.UpdateUser(_supabaseClient, updatedUser);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
