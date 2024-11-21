using Microsoft.AspNetCore.Identity;

namespace BankSystem.Data;

public class ApplicationUser : IdentityUser
{
    public string Role { get; set; }
}