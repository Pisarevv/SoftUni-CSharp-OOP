using CommandPattern.Common;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdValues = args.Split();
            string cmdName = cmdValues[0];
            string[] cmdArgs = cmdValues.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type cmdType = assembly.GetTypes().FirstOrDefault(x => x.Name == cmdName+"Command" && x.GetInterfaces().Any(a => a == typeof(ICommand)));
            if (cmdType == null)
            {
                throw new InvalidOperationException(string.Format(ErrorMassages.InvalidCommandType, cmdName));
            }
            object cmdInstance = Activator.CreateInstance(cmdType);
            MethodInfo[] classMethods = cmdType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo executeMethod = classMethods.FirstOrDefault(x => x.Name == "Execute");

            string result = (string)executeMethod.Invoke(cmdInstance, new object[] { cmdArgs });



            



            return result;
        }
    }
}
