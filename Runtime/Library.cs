using System.Collections.Generic;

namespace Fsi.Libraries
{
    public interface ILibrary<TKey, TValue> 
        where TValue : ILibraryEntry<TKey, TValue>
    {
        public List<TValue> Entries { get; }

        public List<TKey> GetKeys()
        {
            List<TKey> keys = new List<TKey>();
            foreach (var entry in Entries)
            {
                keys.Add(entry.Key);
            }

            return keys;
        }
    }
    
    public interface ILibraryEntry<out TKey, out TValue>
    {
        public TKey Key { get; }
        
        public TValue Value { get; }
    }
}
