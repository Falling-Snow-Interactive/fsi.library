using UnityEngine;

namespace Fsi.Libraries
{
    public class ScriptableEntry<TKey, TValue> : ScriptableObject, ILibraryEntry<TKey, TValue> 
        where TValue : ScriptableEntry<TKey, TValue>
    {
        [Header("Library")]
        
        [SerializeField]
        private TKey key;

        public TKey Key => key;

        public TValue Value => (TValue)this;
    }
}