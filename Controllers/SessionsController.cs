// Controllers/SessionsController.cs
// Key differences from .NET Framework version:
//   ApiController     →  ControllerBase
//   IHttpActionResult →  IActionResult
//   System.Web.Http   →  Microsoft.AspNetCore.Mvc
//   No Global.asax or WebApiConfig — Program.cs handles everything

using Microsoft.AspNetCore.Mvc;
using CampSessionAPI.Models;

namespace CampSessionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        // GET api/sessions
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(SessionRepository.Sessions);
        }

        // GET api/sessions/{name}
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var s = SessionRepository.Sessions.FirstOrDefault(
                x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (s == null)
                return NotFound(new { message = $"Session '{name}' not found." });
            return Ok(s);
        }

        // POST api/register
        [HttpPost("/api/register")]
        public IActionResult Register([FromBody] RegistrationRequest req)
        {
            var s = SessionRepository.Sessions.FirstOrDefault(
                x => x.Name.Equals(req.SessionName, StringComparison.OrdinalIgnoreCase));
            if (s == null)
                return BadRequest(new { message = $"Session '{req.SessionName}' not found." });
            if (s.AvailableSpots <= 0)
                return BadRequest(new { message = $"Session '{req.SessionName}' is fully booked." });
            s.AvailableSpots--;
            string code = "SC-" + req.SessionName.Substring(0, 3).ToUpper()
                        + "-" + DateTime.Now.ToString("MMddHHmm");
            return Ok(new RegistrationResult
            {
                Success = true,
                Message = "Registration successful!",
                StudentName = req.StudentName,
                SessionName = s.Name,
                ConfirmationCode = code
            });
        }
    }
}
