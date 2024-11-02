namespace Moq.DATA;

public class ProductService(IPriceService priceService, IProductRepository productRepository)
{
    private readonly IPriceService _priceService = priceService;
    private readonly IProductRepository _productRepository = productRepository;



    public decimal GetProductTotalSum()
    {
        var product = _productRepository.GetById(50);


        var totalPrice = _priceService.CalculatePrice(product.count, product.price, product.discount);

        


        return totalPrice;
    }
}