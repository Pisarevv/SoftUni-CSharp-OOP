using System;

namespace AuthorProblem
{
    [Author("Hristo")]
    public class StartUp
    {
        [Author("Hristo")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
