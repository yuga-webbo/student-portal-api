using College_Student.Models;
using Microsoft.EntityFrameworkCore;

namespace College_Student.DataBase
{
  public class CourseDbContext : DbContext
  {
    public CourseDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
  }
}
