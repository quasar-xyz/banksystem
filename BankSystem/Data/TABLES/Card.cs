namespace BankSystem.Data.TABLES;

public class Card
{
    public Guid CardId { get; set; } 
    public string CardNumber { get; set; } 
    public string Pin { get; set; } 
    public Guid AccountId { get; set; } 
    public Account Account { get; set; } 
}
