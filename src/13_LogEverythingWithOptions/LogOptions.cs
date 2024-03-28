using Metalama.Framework.Code;
using Metalama.Framework.Options;

/// <summary>
/// Options of the <see cref="LogAttribute"/> aspect.
/// </summary>
public class LogOptions :  IHierarchicalOptions<IMethod>, IHierarchicalOptions<INamedType>,
    IHierarchicalOptions<INamespace>, IHierarchicalOptions<ICompilation>
{
    /// <summary>
    /// Gets or sets the logging color.
    /// </summary>
    public ConsoleColor? Color { get; set; }

    public object ApplyChanges( object changes, in ApplyChangesContext context )
    {
        var optionChanges = (LogOptions) changes;
        return new LogOptions { Color = optionChanges.Color ?? this.Color };
    }
}
