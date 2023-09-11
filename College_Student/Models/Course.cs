using System.ComponentModel.DataAnnotations;

namespace College_Student.Models
{
  public class Course
  {
    [Key]
    public Guid Id { get; set; }
    public string CourseName { get; set; } = default!;

    public string CourseCode { get; set; } = default!;
    public string? CourseDescription { get; set; }
  }
}
