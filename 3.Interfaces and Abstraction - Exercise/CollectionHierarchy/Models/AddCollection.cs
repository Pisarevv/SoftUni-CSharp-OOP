using CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection <T>: IAddCollection<T>
    {
        private readonly ICollection<T> collection;
        public AddCollection()
        {
            collection = new List<T>();
        }
        public int Add(T item)
        {
            collection.Add(item);
            return collection.Count-1;
        }
    }
}
