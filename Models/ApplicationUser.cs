using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Models;

public class ApplicationUser : IdentityUser<int>
{
    public string FullName { get; set; }

    public string PinCode { get; set; }

    [JsonIgnore]
    public DateTime CreatedOn { get; set; }
    [JsonIgnore]
    public DateTime UpdatedOn { get; set; }
}
