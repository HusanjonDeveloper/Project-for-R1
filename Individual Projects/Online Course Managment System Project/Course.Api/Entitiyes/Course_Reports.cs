using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entitiyes;

public class Course_Reports
{
    [Key]
    public  Guid Id { get; set; }

    public  Guid UserId { get; set; }

    public  User? User { get; set; }

    public  Guid CourseId { get; set; }

    public  Course? Course { get; set; }

    public string reportMessage { get; set; }

    public DateTime  Time { get; set; }
}