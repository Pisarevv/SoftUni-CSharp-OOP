using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models.Interfaces
{
    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly List<T> collection;
        public AddRemoveCollection()
        {
            collection = new List<T>();
        }
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
                itemToReturn = collection[collection.Count - 1];
                collection.RemoveAt(collection.Count - 1);
            }

            return itemToReturn;
        }
    }
}
