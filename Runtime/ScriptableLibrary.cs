using System.Collections.Generic;
using UnityEngine;

namespace Fsi.Libraries
{
    public abstract class ScriptableLibrary<TKey, TEntry, TObj>
        : ScriptableObject, ILibrary<TKey, TEntry, TObj> 
            where TEntry : ILibraryEntry<TKey, TObj> 
            where TObj : Object
    {
        public abstract List<TEntry> Entries { get; }

        public abstract bool TryGetValue(TKey key, out TEntry value);
    }
}
