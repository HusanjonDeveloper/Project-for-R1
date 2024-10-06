using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class CreateUserModel
{

    public  string Firstname { get; set; }
    
    public  string Lastname { get; set; }
    
    public  string Username { get; set; }
    
    public  string Bio { get; set; }
    
    public  Address? Address { get; set; }

    public  byte Age { get; set; }
    
    public List<Contact>? Contacts { get; set; }
}

public class Contact()
{
    public  string Number { get; set; }
    
    public  string Relation { get; set; }
    
    public  string Name{ get; set; }
}

public class  Address
{
        public int ZipCode { get; set; }
        
        public string City { get; set; }
        
        public  string Region  { get; set; }

        public  string Country { get; set; }
        
}