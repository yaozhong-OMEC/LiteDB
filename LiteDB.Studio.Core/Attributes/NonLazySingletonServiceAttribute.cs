using System;

namespace LiteDB.Studio.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class NonLazySingletonServiceAttribute : Attribute
    {
    }
}