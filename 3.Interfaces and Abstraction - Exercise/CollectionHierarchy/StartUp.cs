using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;
using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main()
        {
            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> listCollection = new MyList<string>(); 

            string[] words = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int removeOperators = int.Parse(Console.ReadLine());
            AddToAnyCollection(words, addCollection);
            AddToAnyCollection(words, addRemoveCollection);
            AddToAnyCollection(words,listCollection);

            RemoveToAnyCollection(removeOperators,addRemoveCollection);
            RemoveToAnyCollection(removeOperators, listCollection);

        }

        private static void AddToAnyCollection(string[] words, IAddCollection<string> collection)
        {
            foreach (string word in words)
            {
                Console.Write(collection.Add(word) + " ");
            }
            Console.WriteLine();

        }
        private static void RemoveToAnyCollection(int count , IAddRemoveCollection<string> collection)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(collection.Remove() + " "); 
            }
            Console.WriteLine();
        }
    }
}
