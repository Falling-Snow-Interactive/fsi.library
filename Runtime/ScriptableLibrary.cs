using System.Collections.Generic;
using UnityEngine;

namespace Fsi.Libraries
{
    public abstract class ScriptableLibrary<TKey, TValue>
        : ScriptableObject, ILibrary<TKey, TValue> 
            where TValue : ILibraryEntry<TKey, TValue> 
    {
        public abstract List<TValue> Entries { get; }

        public virtual bool TryGetValue(TKey key, out TValue value)
        {
            foreach (TValue v in Entries)
            {
                if (key.Equals(v.Key))
                {
                    value = v.Value;
                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}
