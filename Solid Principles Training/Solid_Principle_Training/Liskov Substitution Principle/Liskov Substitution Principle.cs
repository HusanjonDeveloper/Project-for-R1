namespace Solid_Principle_Training.Liskov_Substitution_Principle;

public class Liskov_Substitution_Principle
{
    public abstract class Shape
    {
        public abstract double Area();
    }
   
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
   
        public override double Area()
        {
            return Width * Height;
        }
    }
   
    public class Square : Shape
    {
        public double Side { get; set; }
   
        public override double Area()
        {
            return Side * Side;
        }
    }

}