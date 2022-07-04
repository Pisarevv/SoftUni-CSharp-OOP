using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main()
        {
            StackOfStrings vs = new StackOfStrings();
            vs.Push("asd");
            Console.WriteLine(vs.AddRange());
            Console.WriteLine(vs.IsEmpty()); 
        }
    }
}
