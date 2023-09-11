using College_Student.DataBase;
using College_Student.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace College_Student.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CourseController : ControllerBase
  {
    private readonly CourseDbContext CourseDbContext;
   public CourseController(CourseDbContext courseDbcontext)
    {
      this.CourseDbContext = courseDbcontext;
    }
    [HttpGet]
    public async Task<IActionResult> GetCourse()
    {
      var Courses = await CourseDbContext.Courses.ToListAsync();
      return Ok(Courses);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] Course Cour)
    {
      Cour.Id = new Guid();
      await CourseDbContext.Courses.AddAsync(Cour);
      await CourseDbContext.SaveChangesAsync();
      return Ok(Cour);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateCourse([FromRoute] Guid id, [FromBody] Course Cour)
    {
     
      var course = await CourseDbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
      if (course != null)
      {
        course.CourseName = Cour.CourseName;
        course.CourseCode = Cour.CourseCode;
        course.CourseDescription = Cour.CourseDescription;
        await CourseDbContext.SaveChangesAsync();

        return Ok(Cour);
      }
      else
      {
        return NotFound("Emplyee not found");
      }
    }
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteCourse([FromRoute] Guid id)
    {

      var course = await CourseDbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
      if (course != null)
      {
        CourseDbContext.Courses.Remove(course);
        await CourseDbContext.SaveChangesAsync();

        return Ok(course);
      }
      else
      {
        return NotFound("Emplyee not found");
      }
    }
  }
}
