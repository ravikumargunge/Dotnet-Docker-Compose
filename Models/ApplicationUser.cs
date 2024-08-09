using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Models;

public class ApplicationUser: IdentityUser
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PinCode { get; set; }
    public required string  PhoneNumber {get;set; }

    [JsonIgnore]
    public DateTime CreatedOn { get; set; }
    [JsonIgnore]
    public DateTime UpdatedOn { get; set; }
}
