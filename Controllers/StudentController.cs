using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;
using StudentWebApi.Views;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : ControllerBase
    {
        public Context dbContext;

        public StudentController(Context context)
        {
            dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] StudentsFilterQuery filter)
        {
            try
            {
                List<StudentView> students = await dbContext.Students
                    .Where(student => (string.IsNullOrEmpty(filter.Name) || student.Firstname.StartsWith(filter.Name)) 
                    && (string.IsNullOrEmpty(filter.City) || student.City.StartsWith(filter.City))
                    && (string.IsNullOrEmpty(filter.State) || student.State.StartsWith(filter.State)))
                    .Select(student => new StudentView(student)
                    {
                        Courses = dbContext.Enrollments
                            .Include(x => x.Course)
                            .Where(e => e.Student.Id == student.Id)
                            .Select(x => new StudentEnrollmentView(x)).ToList()
                    })
                    .ToListAsync();

                return new JsonResult(students);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            try
            {
                List<StudentView> students = await dbContext.Students
                    .Where(x => x.Id == id)
                    .Select(student => new StudentView(student)
                    {
                        Courses = dbContext.Enrollments
                            .Include(x => x.Course)
                            .Where(c => c.Student.Id == student.Id)
                            .Select(x => new StudentEnrollmentView(x)).ToList()
                    })
                    .ToListAsync();


                return new JsonResult(students);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Student student)
        {
            var stud = await dbContext.Students.FindAsync(id);
            if (stud != null)
            {
                stud.Firstname = student.Firstname;
                stud.Lastname = student.Lastname;
                stud.Address = student.Address;
                stud.City = student.City;
                stud.State = student.State;
                stud.DateOfBirth = student.DateOfBirth;

                dbContext.Students.Update(stud);
                await dbContext.SaveChangesAsync();
                return Ok(student);
            }
            return BadRequest("Student not found");

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Student not found");
            }
        }
    }
}

