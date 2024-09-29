using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fsi.Libraries
{
    public class ScriptableSingletonLibrary<TKey, TValue> 
        : ScriptableSingleton<ScriptableSingletonLibrary<TKey, TValue>>, ILibrary<TKey, TValue> 
        where TValue : ILibraryEntry<TKey, TValue> 
    {
        [Header("Library")]
        
        [SerializeField]
        private List<TValue> entries = new();

        public List<TValue> Entries => entries;
    }
}