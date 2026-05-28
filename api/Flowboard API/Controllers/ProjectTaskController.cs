using Microsoft.AspNetCore.Mvc;
using Flowboard_API.Models;
using Flowboard_API.Data;

namespace Flowboard_API.Controllers
{
    [ApiController]
    [Route("api/project/{projectId}/tasks")]
    public class ProjectTaskController : ControllerBase
    {
        private readonly FlowboardContext _context;
        public ProjectTaskController(FlowboardContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetTasks ([FromRoute] int projectId)
        {
            return Ok(_context.Tasks.Where(t => t.ProjectId == projectId).ToList());
        }
        [HttpPost]
        public IActionResult CreateTask([FromRoute] int projectId, [FromBody] ProjectTask task)
        {
            task.ProjectId = projectId;
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTasks([FromRoute] int id, [FromBody] ProjectTask task)
        {
            ProjectTask existingTask = _context.Tasks.Find(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            existingTask.Name = task.Name;
            existingTask.Status = task.Status;
            existingTask.Description = task.Description;
            _context.SaveChanges();
            return Ok(existingTask);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTasks([FromRoute] int id)
        {
            ProjectTask deleteTask = _context.Tasks.Find(id);
            if (deleteTask == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(deleteTask);
            _context.SaveChanges();
            return NoContent();
        }
    }
}