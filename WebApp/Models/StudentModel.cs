using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public sealed class StudentModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public uint Index { get; set; }
    }
}
