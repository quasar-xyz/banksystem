namespace BankSystem.Data.TABLES;

public class Account
{
    public Guid AccountId { get; set; }
    public string UserId { get; set; }
    public decimal Balance { get; set; }
    
    public ApplicationUser User { get; set; }
}