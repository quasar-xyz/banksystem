namespace BankSystem.Data.TABLES;

public class Card
{
    public string CardId { get; set; }
    public Guid AccountId { get; set; }
    public string PIN { get; set; }
    
    public Account Account { get; set; }
}