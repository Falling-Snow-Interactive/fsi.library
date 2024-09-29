using System.Collections.Generic;
using Fsi.Libraries;
using UnityEngine;

public class Registry<TKey, TValue> where TValue : ILibraryEntry<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> entries;
    
    public Registry(ILibrary<TKey, TValue> library)
    {
        entries = new Dictionary<TKey, TValue>();
        foreach (var entry in library.Entries)
        {
            entries.Add(entry.Key, entry.Value);
        }
    }

    public bool TryGetEntry(TKey key, out TValue value)
    {
        return entries.TryGetValue(key, out value);
    }

    public TValue GetRandom()
    {
        List<TValue> values = new(entries.Values);
        return values[Random.Range(0, values.Count)];
    }

    public List<TValue> ToList()
    {
        return new List<TValue>(entries.Values);
    }
}
