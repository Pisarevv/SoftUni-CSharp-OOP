using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties()
                .Where(pi => pi.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute))).ToArray();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj);
                foreach(CustomAttributeData customAttributeData in property.CustomAttributes)
                {
                    Type customAttType = customAttributeData.AttributeType;
                    object instance = property.GetCustomAttribute(customAttType);
                    MethodInfo validationMethod = customAttType.GetMethods().First(x => x.Name == "IsValid");
                    bool result = (bool)validationMethod.Invoke(instance, new object[] { propValue });
                    if (!result)
                    {
                        return false;
                    }
                }
            }


            return true;
        }
    }
}
