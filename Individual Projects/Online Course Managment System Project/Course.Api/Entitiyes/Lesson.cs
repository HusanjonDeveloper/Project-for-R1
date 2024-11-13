using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entitiyes;

public class Lesson
{
    public Guid Id { get; set; }

    [Required]
    public  string Title { get; set; }

    public string? Description { get; set; }

    public  Course? Course { get; set; }

    public  Guid CourseId { get; set; }

    public List<Content> Contents { get; set; }
}
