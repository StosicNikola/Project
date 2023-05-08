using StudentWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Views
{
    public class CourseView
    {
        public int Code { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public List<EnrollmentsView> Students { get; set; } 

        public CourseView() { 
            Students = new List<EnrollmentsView>();
        }
        public CourseView(Course course)
        {
            Code = course.Code;
            Title = course.Title;
            Description = course.Description;
            Students = new List<EnrollmentsView>();
        }
    }
}
