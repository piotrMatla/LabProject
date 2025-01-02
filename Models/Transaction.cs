using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using LabProject.Binders;

namespace LabProject.Models
{

    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public string TransactionName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The decimal part should be separated by a comma")]
        [ModelBinder(BinderType = typeof(DecimalModelBinder))]
        public decimal Amount {  get; set; }

        public string? Note { get; set; }

        public string? UserId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AdditionDate { get; set; } = DateTime.Now;
    }
}
