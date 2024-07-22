using Metalama.Patterns.Contracts;

namespace ContractsDemo;

public class Customer
{
    public string Name { get; set; }
    
    [Email]
    public string Email { get; set; }
    
    [CreditCard]
    public string? CreditCardNumber { get; set; }
}