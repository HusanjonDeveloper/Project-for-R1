namespace Moq.DATA;

public  record Product(int id, decimal count, decimal price)
{
    public decimal discount;
}


//custom record
/*
public class Product1()
{
    public int id { get; init; }
    public decimal price { get; init; }
    public decimal count {get; init; }
}

public class Category()
{
    public Guid Id { get; init; }
    public string Name { get; set; }

}
*/