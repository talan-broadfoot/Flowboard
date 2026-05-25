using System.ComponentModel.DataAnnotations.Schema;

namespace Flowboard_API.Models
{
    public class ProjectTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public required string Description { get; set; }
        public int ProjectId { get; set; }
    }
}