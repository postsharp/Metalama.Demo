using Metalama.Patterns.Contracts;

namespace ContractsDemo;

public class Invoice
{
    public string Number { get; set; }
    
    [StrictlyPositive]
    public decimal Amount { get; set; }
    
    [NonNegative]
    public decimal Tax { get; set; }

    [Invariant]
    private void CheckInvariants()
    {
        if ( this.Tax > this.Amount )
        {
            throw new Exception( "Tax cannot be greater than amount." );
        }
    }
}