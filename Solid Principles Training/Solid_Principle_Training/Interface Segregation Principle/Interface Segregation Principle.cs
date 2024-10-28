namespace Solid_Principle_Training.Interface_Segregation_Principle;

public class Liskov_Substitution_Principle
{
    public interface IAnimal
    {
        void Eat();
    }
      
    public interface IFlyable
    {
        void Fly();
    }
      
    public class Bird : IAnimal, IFlyable
    {
        public void Eat()
        {
            Console.WriteLine("Qush ovqatlanmoqda.");
        }
      
        public void Fly()
        {
            Console.WriteLine("Qush uchmoqda.");
        }
    }
      
    public class Cat : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("Mushuk ovqatlanmoqda.");
        }
    }
}