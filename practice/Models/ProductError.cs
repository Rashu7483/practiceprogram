namespace practice.Models
{
    public class ProductError
    {
        public int? ProductId { get; set; } // returns null, Requires you to check for null each time
        public string ErrorMessage { get; set; }= string.Empty; //Safer default like "" , avoids null checks everywhere

    }
}
