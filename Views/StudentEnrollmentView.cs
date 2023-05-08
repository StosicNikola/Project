using StudentWebApi.Models;
using System.Text.Json.Serialization;

namespace StudentWebApi.Views
{
    public class StudentEnrollmentView
    {
        [JsonIgnore]
        public CourseView Course { get; set; }
        public string Title { get { return Course.Title; } set { Title = value; } }
        public int? Mark { get; set; }

        public StudentEnrollmentView() { }
        public StudentEnrollmentView(CourseView course, int mark)
        {
            Course = course;
            Mark = mark;
        }

        public StudentEnrollmentView(Enrollment enrollment)
        {
            Course = new CourseView(enrollment.Course);
            Mark = enrollment.Mark;
        }

    }
}
