using LabProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace LabProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsDefault { get; set; } 
        public string UserId { get; set; } 
    }
}
