using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(classToInvestigate);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            foreach (FieldInfo field in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            object classInstance = Activator.CreateInstance(classType, new object[] { });
            foreach (FieldInfo field in classFields)
            {              
                    sb.AppendLine($"{field.Name} must be private!");
            }
            foreach(MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} must be public!");
            }
            foreach(MethodInfo methodInfo in classPrivateMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{methodInfo.Name} must be private!");
            }
            return sb.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base class: {classType.BaseType}");
            foreach (MethodInfo method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string investigatedClass)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classGettersAndSetters = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);

            foreach (MethodInfo method in classGettersAndSetters)
            {
                if (method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} will return {method.ReturnParameter}");
                }
                else if (method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} will set field of {method.ReturnParameter.ParameterType}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
