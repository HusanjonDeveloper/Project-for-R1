using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLTutorial.Models;

[Table("product")]
public class Product
{
    [Key] 
    [Column("id")]
    public  int Id { get; set; }

    [Column("productName")]
    public  string ProductName { get; set; }

    [Column("price")]
    public  decimal Price { get; set; }

    public  string ProductDescription { get; set; }

    public  int CategoryId { get; set; }
}