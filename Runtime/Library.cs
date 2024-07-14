using System.Collections.Generic;
using UnityEngine;

namespace Libraries
{
    public interface ILibrary<in TKey, TValue, TObj> 
        where TValue : ILibraryEntry<TKey, TObj>
        where TObj : Object
    {
        public List<TValue> Entries { get; }

        public bool TryGetValue(TKey key, out TValue value);
    }
    
    public interface ILibraryEntry<out TKey, out TObj>
        where TObj : Object
    {
        public TKey Key { get; }
        
        public TObj Value { get; }
    }
}
