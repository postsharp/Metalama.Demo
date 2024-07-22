using Metalama.Patterns.Observability;
using System.Text;

namespace ObservableDemo.Model
{
    public class AddressModel : ModelBase
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public DateTime Expiration { get; set; }


        [SuppressObservabilityWarnings]
        public string FullText
        {
            get
            {
                var stringBuilder = new StringBuilder();
                if ( this.Line1 != null )
                {
                    stringBuilder.Append( this.Line1 );
                }

                if ( this.Line2 != null )
                {
                    if ( stringBuilder.Length > 0 )
                    {
                        stringBuilder.Append( "; " );
                    }

                    stringBuilder.Append( this.Line2 );
                }
                if ( this.City != null )
                {
                    if ( stringBuilder.Length > 0 )
                    {
                        stringBuilder.Append( "; " );
                    }

                    stringBuilder.Append( this.City );
                }
                if ( this.Country != null )
                {
                    if ( stringBuilder.Length > 0 )
                    {
                        stringBuilder.Append( "; " );
                    }

                    stringBuilder.Append( this.Country );
                }


                return stringBuilder.ToString();
            }
        }
    }
}