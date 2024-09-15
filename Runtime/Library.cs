using System.Collections.Generic;
using UnityEngine;

namespace Fsi.Libraries
{
    public interface ILibrary<in TKey, TValue> 
        where TValue : ILibraryEntry<TKey, TValue>
    {
        public List<TValue> Entries { get; }

        public bool TryGetValue(TKey key, out TValue value);
    }
    
    public interface ILibraryEntry<out TKey, out TValue>
    {
        public TKey Key { get; }
        
        public TValue Value { get; }
    }
}
