

using SQLTutorial.Context;

var dbContext = new AppDbContext();



var categories = dbContext.Categories.ToList();


if (categories.Count == 0)
{
    Console.WriteLine("Categories are empty.");
}