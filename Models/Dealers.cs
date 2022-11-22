using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class Dealers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public string password { get; set; }

        [ValidateNever]

        [Required]
        [Display(Name = "Manufacturer")]
        public int VehicleId { get; set; }
        [ValidateNever]
        public Vehicle Vehicle { get; set; }
    }
}
