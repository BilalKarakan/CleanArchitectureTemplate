﻿using System.Reflection;

namespace CleanArchitectureTemplate.Presentation;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
