using System.Reflection;

namespace CleanArchitectureTemplate.Application;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
