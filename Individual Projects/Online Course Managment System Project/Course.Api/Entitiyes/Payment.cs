using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entitiyes;

public class Payment
{
    [Key]
    public  Guid Id { get; set; }

    public  Guid UserId { get; set; }

    public  User? User { get; set; }

    public  Guid CourseId { get; set; }

    public  Course? Course { get; set; }

    public  decimal Amount { get; set; }

    public  string Status { get; set; }

    public  DateTime CreatedDate { get; set; }
}
