using Moq;
using Moq.DATA;
using Xunit;
using Range = System.Range;

namespace MOQ.EXAMPLE;

public class ProductServiceTests
{
    [Fact]
    public void CheckTotalPrice()
    {
        var priceMock = new Mock<IPriceService>();

        priceMock.Setup(p => p.CalculatePrice(5,1000,10)).Returns(4500);
        priceMock.Setup(p => p.CalculatePrice(100, 3000, 15)).Returns(255000);

        IPriceService priceService = priceMock.Object ;



        var productRepoMock = new Mock<IProductRepository>();

        /*productRepoMock.Setup(p => p.GetById(2))
            .Returns(new Product(4,100,3000,15));

        productRepoMock.Setup(p => p.GetById(5))
            .Returns(new Product(6,100,3000,15));


        productRepoMock.Setup(p => p.GetById(5))
            .Returns(new Product(7,100,3000,15));


        productRepoMock.Setup(p => p.GetById(5))
            .Returns(new Product(8,100,3000,15));


        productRepoMock.Setup(p => p.GetById(5))
            .Returns(new Product(9,100,3000,15));


        productRepoMock.Setup(p => p.GetById(5))
            .Returns(new Product(10,100,3000,15));*/


        productRepoMock.Setup(p => p.GetById(It.IsInRange(1,50,Range.Inclusive)))
            .Returns(new Product(10,100,3000,15));

        



        IProductRepository productRepoService = productRepoMock.Object ;


        var productService = new ProductService(priceService,productRepoService);

        var totalSum = productService.GetProductTotalSum();

        

        Assert.Equal(255000,totalSum);



    }


    [Fact]
    public void TestString()
    {
        string text = new Mock<string>().Object;
        Assert.True(true);

    }

}


/*public class Example : IPriceService
{
    public decimal CalculatePrice(decimal count, decimal price, decimal discount)
    {
        return 5;
    }
}*/
}