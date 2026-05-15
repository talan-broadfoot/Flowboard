using Microsoft.AspNetCore.Mvc;
using Flowboard_API.Models;
using Flowboard_API.Data;

namespace Flowboard_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly FlowboardContext _context;
        public ProjectController(FlowboardContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetProjects ()
        {
            return Ok(_context.Projects.ToList());
        }
        [HttpPost]
        public IActionResult CreateProject([FromBody] Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return Ok($"Project: {project.Name} created.");
        }
    }
}