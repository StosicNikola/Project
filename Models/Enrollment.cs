using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentWebApi.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseCode { get; set; }
        
        public Student Student { get; set; }
        
        public Course Course { get; set; }

        public int? Mark { get; set; }
    }
}
