using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Catergory
    {
        [Key] public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Category { get; set; }

        
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Value must be between 1-100" )]
        public int DisplayOrder {  get; set; }
    }
}
