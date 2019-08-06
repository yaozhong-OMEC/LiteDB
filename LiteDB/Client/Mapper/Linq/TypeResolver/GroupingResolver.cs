using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using static LiteDB.Constants;

namespace LiteDB
{
    internal class GroupingResolver : ITypeResolver
    {
        public string ResolveMethod(MethodInfo method, Stack<string> root)
        {
            // all methods in Enumerable are Extensions (static methods), so first parameter is IEnumerable
            var name = Reflection.MethodName(method, 1);

            switch (name)
            {
                case "Count()": return "COUNT(*)";
                case "Sum()":
                    root.Push("*");
                    return "SUM(@0)";
                case "Average()":
                    root.Push("*");
                    return "AVG(@0)";
                case "Max()":
                    root.Push("*");
                    return "MAX(@0)";
                case "Min()":
                    root.Push("*");
                    return "MIN(@0)";
                case "First()":
                    root.Push("*");
                    return "FIRST(@0)";
                case "Last()":
                    root.Push("*");
                    return "LAST(@0)";
            }

            return null;
        }

        public string ResolveMember(MemberInfo member)
        {
            switch (member.Name)
            {
                case "Key": return "@key";
            }

            return null;
        }

        public string ResolveCtor(ConstructorInfo ctor) => null;
    }
}