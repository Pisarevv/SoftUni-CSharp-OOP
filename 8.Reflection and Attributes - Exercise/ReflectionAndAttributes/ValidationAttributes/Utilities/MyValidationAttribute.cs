using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public abstract class MyValidationAttribute : Attribute
    {
        public MyValidationAttribute()
        {
        }
        public abstract bool IsValid(object obj);
    }
}
