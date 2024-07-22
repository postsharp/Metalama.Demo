using Metalama.Patterns.Observability;

namespace ObservableDemo.Model
{
    [Observable]
    public class CustomerViewModel
    {
        public CustomerModel Customer { get; set; }

        public string FullName =>
            string.Format( "{0} {1} from {2}",
                this.Customer.FirstName,
                this.Customer.LastName,
                this.Customer.Address?.Observable ?? "unknown address" );
    }
}