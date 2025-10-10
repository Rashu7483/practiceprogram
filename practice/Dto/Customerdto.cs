namespace practice.Dto
{
    public class Customerdto
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Orderdto>? Orders { get; set; }

    }
}
