using Microsoft.AspNetCore.Identity;

namespace BankSystem.Data.TABLES;

public class Account : IdentityUser
{
    public Guid AccountId { get; set; } 
    public string UserId { get; set; } 

    public string AccountNumber { get; set; } 
    public string BankCode { get; set; } 
    
    public string Name { get; set; } 
    public decimal Balance { get; set; } 

   
    public ICollection<Card> Cards { get; set; } 
    public ICollection<Transaction> Transactions { get; set; }
}