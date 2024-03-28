using Metalama.Patterns.Contracts;

namespace Contracts;

public class InvoiceFactory
{
    public static Invoice CreateInvoice( string number, [StrictlyPositive] decimal amount, [Positive] decimal tax )
        => new Invoice { Number = number, Amount = amount, Tax = tax };
}