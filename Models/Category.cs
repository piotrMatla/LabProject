using LabProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsDefault { get; set; } = false;

        [ForeignKey("AspNetUsers")]
        public string? UserId { get; set; } 
        

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Type { get; set; } = "Expense";

    }
}
