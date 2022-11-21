using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EndProject.Models
{
    public class EngineType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Engine Type")]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

    }
}
