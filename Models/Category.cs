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
        public bool IsDefault { get; set; } // Czy kategoria jest domyślna
        public string UserId { get; set; } = string.Empty; // ID użytkownika
        public ApplicationUser? User { get; set; } // Powiązanie z użytkownikiem
    }
}
