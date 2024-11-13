using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entitiyes;

public class SMSVarfication
{
    public  Guid Id { get; set; }

    [Required]
    public string Code  { get; set; }

    [Required]
    public  string PhoneNumber { get; set; }
}