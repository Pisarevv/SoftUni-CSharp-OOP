﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    internal class ErrorsList
    {
        public const string NegativeAge = "Age cannot be zero or a negative integer!";
        public const string InvalidFirstName = "First name cannot contain fewer than 3 symbols!";
        public const string InvalidLastName = "Last name cannot contain fewer than 3 symbols!";
        public const string InvalidSalary = "Salary cannot be less than 650 leva!";
    }
}
