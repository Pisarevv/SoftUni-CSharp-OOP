namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInteger);
            object instanceOfClass = Activator.CreateInstance(classType, true);
            MethodInfo[] classMethods = classType
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            string input = string.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split("_");
                string methodName = cmdArgs[0];
                int value = int.Parse(cmdArgs[1]);

                MethodInfo methodWanted = classMethods.FirstOrDefault(x => x.Name == methodName);
                object invokeingMethod = methodWanted.Invoke(instanceOfClass, new object[] { value });
                FieldInfo field = classType.GetField("innerValue",BindingFlags.NonPublic | BindingFlags.Instance);
                object result = field.GetValue(instanceOfClass);
                Console.WriteLine(result);
            }
        }
    }
}
