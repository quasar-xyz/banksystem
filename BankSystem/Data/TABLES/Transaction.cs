namespace BankSystem.Data.TABLES;

public class Transaction
{
    public Guid TransactionId { get; set; } 
    public Guid AccountId { get; set; } 
    public string RecipientAccountNumber { get; set; } 
    public string RecipientBankCode { get; set; } 
    public decimal Amount { get; set; } 
    public DateTime Timestamp { get; set; } 
    public string VariableSymbol { get; set; } 
    
    public Account Account { get; set; } 
}
