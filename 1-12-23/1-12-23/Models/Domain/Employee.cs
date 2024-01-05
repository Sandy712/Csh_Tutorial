namespace _1_12_23.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }
        public long PhoneNo { get; set; }
    }
}