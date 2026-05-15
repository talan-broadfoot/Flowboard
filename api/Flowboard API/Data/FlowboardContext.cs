using Microsoft.EntityFrameworkCore;
using Flowboard_API.Models;

namespace Flowboard_API.Data
{
    public class FlowboardContext : DbContext
    {
        public FlowboardContext(DbContextOptions<FlowboardContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
    }
}