using StudentWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Views
{
    public class StudentView
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public List<StudentEnrollmentView> Courses { get; set; }

        public StudentView() {
            Courses = new List<StudentEnrollmentView>();
        }
        public StudentView(Student student)
        {
            Id = student.Id;
            Firstname = student.Firstname;
            Lastname= student.Lastname;
            Address = student.Address;
            City = student.City;
            State = student.State;
            DateOfBirth = student.DateOfBirth.ToShortDateString();
            Gender = student.Gender.ToString();
            Courses = new List<StudentEnrollmentView>();
        }
    }
}
