using Metalama.Framework.Project;

/// <summary>
/// Options of the <see cref="LogAttribute"/> aspect.
/// </summary>
public class LogOptions : ProjectExtension
{
    /// <summary>
    /// Gets or sets the logging color.
    /// </summary>
    public ConsoleColor Color { get; set; }
}
