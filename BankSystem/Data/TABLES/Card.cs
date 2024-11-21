namespace BankSystem.Data.TABLES;

public class Card
{
    public Guid CardId { get; set; } // Unique identifier
    public string CardNumber { get; set; } // 16-digit identifier
    public string Pin { get; set; } // Encrypted PIN
    public Guid AccountId { get; set; } // Foreign key to Account
    public Account Account { get; set; } // Navigation property
}
