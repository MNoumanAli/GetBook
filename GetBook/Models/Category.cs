using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GetBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(100, ErrorMessage = "Name should be of 100 characters")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "Display order should be between 1 and 100")]
        public string DisplayOrder {  get; set; }
    }
}
