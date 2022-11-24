using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EndProject.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Mileage { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 10000000, ErrorMessage = "Price must be between 1 and 10000000 only!!")]
        public double ListPrice { get; set; }
        

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        [Display(Name = "Engine Type")]
        public int EngineTypeId { get; set; }
        [ValidateNever]
        public EngineType EngineType { get; set; }
    }
}
