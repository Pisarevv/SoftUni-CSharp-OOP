using ValidationAttributes.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using ValidationAttributes.Models;


namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Pesho",
                 33
             );

            bool isValidEntity = Utilities.Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
