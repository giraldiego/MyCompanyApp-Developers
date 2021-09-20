namespace Domain
{
    public class Employee : Person
    {
        public int GrossSalary { get; set; }
        public Manager Boss { get; set; }
    }
}
