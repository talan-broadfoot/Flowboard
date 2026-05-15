namespace Flowboard_API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
    }
}