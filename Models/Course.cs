using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models
{
    public class Course
    {
        [Key]
        public int Code { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public required string Description { get; set; }
    }
}
