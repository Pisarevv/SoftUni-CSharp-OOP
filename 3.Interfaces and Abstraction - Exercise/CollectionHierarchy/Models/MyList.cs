using CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : IMyList<T>
    {
        private readonly List<T> collection;
        public MyList()
        {
            collection = new List<T>();
        }
        public int Used => collection.Count;

        public int Add(T item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T itemToReturn = default(T);
            if (collection.Count > 0)
            {
                itemToReturn = collection[0];
                collection.RemoveAt(0);
            }

            return itemToReturn;
        }
    }
}
