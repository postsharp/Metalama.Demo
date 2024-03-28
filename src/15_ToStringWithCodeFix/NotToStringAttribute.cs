// This is an open-source Metalama example. See https://github.com/postsharp/Metalama.Samples for more.

using System;
using Metalama.Framework.Aspects;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class NotToStringAttribute : Attribute { }
