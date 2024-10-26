
using Microsoft.EntityFrameworkCore;
using SQLTutorial.Context;

var dbContext = new AppDbContext();

// name uchun                                                               // Take Limit qoyish uchun
// var categories = dbContext.Categories.OrderBy(c => c.Name).Take(3).ToList();

//  id va nme olib kelish uchun
var categories = dbContext.Categories
    .FromSqlRaw("SELECT * FROM categories as c ORDER BY c.name LIMIT 3;")
    .ToList();

var products = dbContext.Products
    .FromSqlRaw("SELECT * FROM categories as c INNER JOIN product as p ON c.id = p.\"CategoryId\" ORDER BY price DESC LIMIT 4;")
    .ToList();

/*
if (categories.Count == 0)
{
    Console.WriteLine("Categories are empty.");
}
else
{
    foreach (var category in categories )
    {
        Console.WriteLine($"ID : {category.Id} - name : {category.Name}");
    }
}
*/


var mixed = dbContext.Products.FromSqlRaw(
        "SELECT p.id,p.price,p.\"productName\",c.name FROM product as pINNER JOIN categories as c ON c.id = p.\"CategoryId\"ORDER BY price DESC LIMIT 3;")
    .ToList();


foreach (var product in products)
{
    Console.WriteLine($"products name : {product.ProductName}");
}