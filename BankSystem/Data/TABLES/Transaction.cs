namespace BankSystem.Data.TABLES;

public class Transaction
{
    public Guid TransactionId { get; set; }
    public string AccountId { get; set; } 
    public string AccountNumber { get; set; } 
    public string BankCode { get; set; }
    public int Amount { get; set; } 
    public string VariableSymbol { get; set; } 
    public DateTime Date { get; set; } 
    
    
}
