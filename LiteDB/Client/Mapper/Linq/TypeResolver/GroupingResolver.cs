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
        public string ResolveMethod(MethodInfo method)
        {
            // all methods in Enumerable are Extensions (static methods), so first parameter is IEnumerable
            var name = Reflection.MethodName(method, 1);

            switch (name)
            {
                case "Count()": return "COUNT(*)";
                case "Sum()": return "SUM(@0)";
                case "Average()": return "AVG(@0)";
                case "Max()": return "MAX(@0)";
                case "Min()": return "MIN(@0)";
                case "First()": return "FIRST(@0)";
                case "Last()": return "LAST(@0)";

                case "Array()": return "ARRAY(@0)";
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