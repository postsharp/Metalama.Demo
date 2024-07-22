
using Metalama.Patterns.Observability;

namespace ObservableDemo.Model;

// We're adding two aspects to the base class of all Model classes and the aspects
// will be automatically added by all children classes.

[Observable]
public abstract partial class ModelBase
{
}