using Microsoft.AspNetCore.Mvc;
using Flowboard_API.Models;
using Flowboard_API.Data;
using Microsoft.AspNetCore.Authorization;

namespace Flowboard_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
            return Ok(project);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProjects([FromRoute] int id, [FromBody] Project project)
        {
            Project existingProject = _context.Projects.Find(id);
            if (existingProject == null)
            {
                return NotFound();
            }
            existingProject.Name = project.Name;
            existingProject.Status = project.Status;
            _context.SaveChanges();
            return Ok(existingProject);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProjects([FromRoute] int id)
        {
            Project deleteProject = _context.Projects.Find(id);
            if (deleteProject == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(deleteProject);
            _context.SaveChanges();
            return NoContent();
        }
    }
}