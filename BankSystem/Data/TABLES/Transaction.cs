namespace BankSystem.Data.TABLES;

public class Transaction
{
    public Guid TransactionId { get; set; }
    public Guid FromAccount { get; set; }
    public string ToAccount { get; set; }
    public string BankCode { get; set; }
    public decimal Amount { get; set; }
    public string VariableSymbol { get; set; } 
    public DateTime Date { get; set; }
}