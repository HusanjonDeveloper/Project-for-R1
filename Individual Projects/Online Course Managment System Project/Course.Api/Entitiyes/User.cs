using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entitiyes;

public class User
{
    public  Guid Id { get; set; }

    [Required]
    public  string FristName { get; set; }

    public  string? LastName { get; set; }
    
    [Required]
    [RegularExpression(@"^(\+?998)?[-\s]?\(?\d{2}\)?[-\s]?\d{3}[-\s]?\d{2}[-\s]?\d{2}$",
        ErrorMessage = "Telefon raqami Oʻzbekiston raqamlariga mos emas.")]
    public  string PhoneNumber { get; set; }

    [Required]
    public  string PasswordHash { get; set; }
 
    [Compare("PasswordHash")] 
    public string? ConfirmPassword  { get; set; }
    
    [Required]
   public  string? Role { get; set; }

    public  DateTime CreatedAt { get; set; }

    public  bool IsBlocked { get; set; }

    public  List<User_Course> UserCourses { get; set; }

    public  List<Payment> Payments { get; set; }

    public  List<Course_Reports> CourseReports { get; set; }
    
    
    
}