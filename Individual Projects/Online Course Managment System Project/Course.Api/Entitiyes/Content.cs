using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entitiyes;

public class Content
{
    public  int Id { get; set; }
    
    [Required]
    public  string Name { get; set; }

    public  int LessonId { get; set; }

    public  Lesson Lesson { get; set; }
    
    
    // public  Guid Id { get; set; }
    // public  string  GoogleDriveFileId { get; set; }
    // public  string Url { get; set; }
}
