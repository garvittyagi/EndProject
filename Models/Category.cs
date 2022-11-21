using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EndProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 10, ErrorMessage = "Display Order must be between 1 and 10 only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        
    }
}
