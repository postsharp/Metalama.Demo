using Metalama.Patterns.Contracts;

namespace ContractsDemo;

public class InvoiceFactory
{
    public static Invoice CreateInvoice( string number, [StrictlyPositive] decimal amount, [NonNegative] decimal tax )
        => new Invoice { Number = number, Amount = amount, Tax = tax };
}