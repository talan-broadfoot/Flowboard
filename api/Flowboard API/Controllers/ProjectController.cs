using Microsoft.AspNetCore.Mvc;
using Flowboard_API.Models;

namespace Flowboard_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProjects ()
        {
            return Ok(new List<Project>
            {
                new Project { Id = 1, Name = "Fix leak", Status = "Done"},
                new Project { Id = 2, Name = "Fix shed", Status = "Not Started"}
            });
        }
    }
}