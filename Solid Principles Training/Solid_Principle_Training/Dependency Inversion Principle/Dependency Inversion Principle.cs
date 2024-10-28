namespace Solid_Principle_Training.Dependency_Inversion_Principle;

public class Dependency_Inversion_Principle
{
    public interface IService
    {
        void Serve();
    }
 
    public class EmailService : IService
    {
        public void Serve()
        {
            Console.WriteLine("Email xizmati ishlatildi.");
        }
    }
 
    public class SMSService : IService
    {
        public void Serve()
        {
            Console.WriteLine("SMS xizmati ishlatildi.");
        }
    }
 
    public class Client
    {
        private readonly IService _service;
 
        public Client(IService service)
        {
            _service = service;
        }
 
        public void Start()
        {
            _service.Serve();
        }
    }
 
    // Foydalanish
    Client client = new Client(new EmailService());
    client.Start();

}