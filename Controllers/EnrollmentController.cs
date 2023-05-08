using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;
using StudentWebApi.Views;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("enrollments")]
    public class EnrollmentController : ControllerBase
    {
        public Context dbContext;

        public EnrollmentController(Context context)
        {
            dbContext = context;
        }

        [HttpPost]
        [Route("enroll/{studentId}/{courseCode}")]
        public async Task<ActionResult> EnrollToCourse(int studentId, int courseCode)
        {
            var student = await dbContext.Students.FindAsync(studentId);
            var course = await dbContext.Courses.FindAsync(courseCode);
            if (student != null && course != null)
            {
                Enrollment enrollment = new Enrollment();
                enrollment.StudentId = student.Id;
                enrollment.CourseCode = course.Code;
                enrollment.Course = course;
                enrollment.Student = student;
                await dbContext.Enrollments.AddAsync(enrollment);
                await dbContext.SaveChangesAsync();

                return Ok(enrollment);
            }
            return BadRequest("Student or course not found");
        }

        [HttpDelete]
        [Route("leave/{studentId}/{courseCode}")]
        public async Task<ActionResult> LeaveCourse(int studentId, int courseCode)
        {
            var student = await dbContext.Students.FindAsync(studentId);
            var course = await dbContext.Courses.FindAsync(courseCode);
            if (student != null && course != null)
            {
                var enrollment = dbContext.Enrollments.Where(x => x.StudentId == studentId && x.CourseCode == courseCode).FirstOrDefault();
                if (enrollment != null)
                {

                    dbContext.Enrollments.Remove(enrollment);
                    await dbContext.SaveChangesAsync();
                    return Ok();
                }
            }
            return BadRequest("Student or course not found");
        }

        [HttpPut]
        [Route("evaluate/{studentId}/{courseCode}/{mark}")]
        public async Task<ActionResult> Evaluate(int studentId, int courseCode, int mark)
        {
            var student = await dbContext.Students.FindAsync(studentId);
            var course = await dbContext.Courses.FindAsync(courseCode);
            if (student != null && course != null)
            {
                var enrollment = dbContext.Enrollments.Where(x => x.StudentId == studentId && x.CourseCode == courseCode).FirstOrDefault();
                if (enrollment != null)
                {
                    enrollment.Mark = mark;
                    dbContext.Enrollments.Update(enrollment);
                    await dbContext.SaveChangesAsync();
                    return Ok();
                }
            }
            return BadRequest("Student or course not found");
        }
    }
}
