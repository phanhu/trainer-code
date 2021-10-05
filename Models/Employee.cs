namespace Models
{
    public class Employee
    {
        public Employee(string password)
        {
            this.Password = password;
        }

        public string Password {get; set;}
        
    }
}