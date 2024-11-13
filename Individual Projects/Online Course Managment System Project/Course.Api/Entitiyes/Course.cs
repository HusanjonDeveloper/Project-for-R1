using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entitiyes;

public class Course
{

    public  Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public  decimal Price { get; set; }

    [Required]
    public  string Category { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.UtcNow;

    public  List<Lesson> Lessons { get; set; }

    public  List<User_Course> UserCourses { get; set; }

    public  List<Payment> Payments { get; set; }

    public  List<Course_Reports> CourseReports { get; set; }
}