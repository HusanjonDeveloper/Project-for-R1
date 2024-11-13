using System.ComponentModel.DataAnnotations;

namespace Course.Data.Entitiyes;

public class CardInfo
{
    public  Guid Id { get; set; }

    [Required]
    public   Guid UserId { get; set; }

    [Required] 
    public  string CardNumber { get; set; }

    [Required]
    public string CardHolderName { get; set; }

    public  string? CVVHash { get; set; }

    public  User? User { get; set; }
}