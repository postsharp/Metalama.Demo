using Metalama.Framework.Aspects;
using Metalama.Framework.Project;

[CompileTime]
public static class ProjectExtensions
{
    /// <summary>
    /// Gets the options of the <see cref="LogAttribute"/> aspect.
    /// </summary>
    /// <param name="project"></param>
    /// <returns></returns>
    public static LogOptions LogOptions( this IProject project ) => project.Extension<LogOptions>();
}
