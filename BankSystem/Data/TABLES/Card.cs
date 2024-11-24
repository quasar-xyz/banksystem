using BankSystem.Data.Identity;

namespace BankSystem.Data.TABLES;

public class Card
{
    public Guid CardId { get; set; }  
    public string CardNumber { get; set; } 
    public string Pin { get; set; } 
    
    public string AccountId { get; set; } 
    public ApplicationUser Account { get; set; } 
}
