using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public required string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public required string Lastname { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public required string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public required string State { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public required DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1,
        Unspecified = 2
    }
}
