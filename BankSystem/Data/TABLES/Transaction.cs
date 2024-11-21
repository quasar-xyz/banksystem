namespace BankSystem.Data.TABLES;

public class Transaction
{
    public Guid TransactionId { get; set; } // Unique transaction identifier
    public Guid AccountId { get; set; } // Foreign key to Account
    public string RecipientAccountNumber { get; set; } // Target account number
    public string RecipientBankCode { get; set; } // Target bank code
    public decimal Amount { get; set; } // Transaction amount
    public DateTime Timestamp { get; set; } // Time of transaction
    public string VariableSymbol { get; set; } // Optional variable symbol (10 characters)
    
    public Account Account { get; set; } // Navigation property
}
