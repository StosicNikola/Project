using StudentWebApi.Models;
using System.Text.Json.Serialization;

namespace StudentWebApi.Views
{
    public class EnrollmentsView
    {
        [JsonIgnore]
        public StudentView Student { get; set; }
        public string FirstName { get { return Student.Firstname; } set { FirstName = value; } }   
        public string LastName { get { return Student.Firstname; } set { LastName = value; } }
        public int? Mark { get; set; }

        public EnrollmentsView() { }
        public EnrollmentsView(StudentView student, int mark)
        {
            Student = student;
            Mark = mark;
        }

        public EnrollmentsView(Enrollment enrollment)
        {
            Student = new StudentView(enrollment.Student);
            Mark = enrollment.Mark;
        }
    }
}
