using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entitiyes;

public class User_Course
{
    [Key]
    public  Guid Id { get; set; }

    public  Guid UserId { get; set; }

    public User? User  { get; set; }

    public  Guid CourseId { get; set; }

    public  Course? Course { get; set; }

    public bool IsOwner { get; set; }

    public  bool IsPayed { get; set; }

    public  string IsFree { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}