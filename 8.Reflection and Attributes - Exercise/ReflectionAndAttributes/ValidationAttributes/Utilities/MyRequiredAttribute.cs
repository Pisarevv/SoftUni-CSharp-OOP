using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj != null && !string.IsNullOrEmpty((string)obj))
            {
                return true;
            }
            return false;
        }
    }
}
