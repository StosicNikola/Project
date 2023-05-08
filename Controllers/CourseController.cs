using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;
using StudentWebApi.Views;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("courses")]
    public class CourseController : ControllerBase
    {
        public Context dbContext;

        public CourseController(Context context)
        {
            dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] string? courseTitle)
        {
            try
            {
                List<CourseView> courses = await dbContext.Courses
                    .Where(course => (string.IsNullOrEmpty(courseTitle) || course.Title.StartsWith(courseTitle)))
                    .Select(course => new CourseView(course)
                    {
                        Students = dbContext.Enrollments
                        .Include(x => x.Student)
                        .Where(s => s.Course.Code == course.Code)
                        .Select(x => new EnrollmentsView(x)).ToList()
                    })
                    .ToListAsync();

                return new JsonResult(courses);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        [Route("{courseCode}")]
        public async Task<ActionResult> FindByCode(int courseCode)
        {
            try
            {
                List<CourseView> courses = await dbContext.Courses
                    .Where(c => c.Code == courseCode)
                    .Select(course => new CourseView(course)
                    {
                        Students = dbContext.Enrollments
                        .Include(x => x.Student)
                        .Where(s => s.Course.Code == course.Code)
                        .Select(x => new EnrollmentsView(x)).ToList()
                    })
                    .ToListAsync();

                return new JsonResult(courses);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Course course)
        {
            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
            return Ok(course);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Course c)
        {
            var course = await dbContext.Courses.FindAsync(id);
            if (course != null)
            {
                course.Title = c.Title;
                course.Description = c.Description;
                dbContext.Courses.Update(course);
                await dbContext.SaveChangesAsync();
                return Ok(course);
            }
            return BadRequest("Course not found");

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            var course = await dbContext.Courses.FindAsync(id);
            if (course != null)
            {
                dbContext.Courses.Remove(course);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Course not found");
            }
        }

    }
}
