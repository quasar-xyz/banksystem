using BankSystem.Data.TABLES;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Data.Identity;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Balance { get; set; }
    public string Identificator { get; set; }
    
    public ICollection<Card> Cards { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
