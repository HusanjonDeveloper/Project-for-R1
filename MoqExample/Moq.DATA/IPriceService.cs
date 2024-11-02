namespace Moq.DATA;

public interface IPriceService
{
    decimal CalculatePrice(decimal count, decimal price, decimal discount);
}