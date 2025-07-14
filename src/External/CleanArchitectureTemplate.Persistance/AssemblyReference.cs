using System.Reflection;

namespace CleanArchitectureTemplate.Persistance;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
