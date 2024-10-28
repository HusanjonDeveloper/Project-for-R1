namespace Solid_Principle_Training.Single_Responsibility_Principle;

public class Single_Responsibility_Principle
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
  
    // UserRepository faqat ma'lumotlarni saqlash uchun mas'ul
    public class UserRepository
    {
        public void Save(User user)
        {
            // ma'lumotlar bazasiga saqlash jarayoni
            Console.WriteLine($"{user.Name} saqlandi.");
        }
    }
}