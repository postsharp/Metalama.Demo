using Metalama.Patterns.Observability;

namespace MauiDemoApp.Model;

[Observable]
public class CustomerViewModel
{
    public CustomerModel? Customer { get; set; }

    public string FullName =>
        this.Customer == null
            ? "nobody"
            : string.Format( "{0} {1} from {2}",
                this.Customer.FirstName,
                this.Customer.LastName,
                this.Customer.Address?.FullText ?? "unknown address" );
}