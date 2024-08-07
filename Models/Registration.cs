namespace Models;

public class Registration
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PinCode { get; set; }
    public required string  PhoneNumber {get;set; }
}
