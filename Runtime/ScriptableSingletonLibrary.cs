using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fsi.Libraries
{
    [FilePath("Settings/Libraries/Library.lib", FilePathAttribute.Location.ProjectFolder)]
    public class ScriptableSingletonLibrary<TKey, TValue> 
        : ScriptableSingleton<ScriptableSingletonLibrary<TKey, TValue>>, ILibrary<TKey, TValue> 
        where TValue : ILibraryEntry<TKey, TValue> 
    {
        [Header("Library")]
        
        [SerializeField]
        private List<TValue> entries = new();

        public List<TValue> Entries => entries;
        
        #if UNITY_EDITOR
        
        public static SerializedObject GetSerializedSettings()
        {
            if (!instance)
            {
                CreateInstance<ScriptableSingletonLibrary<TKey, TValue>>();
                instance.Save(true);
            }
            return new SerializedObject(instance);
        }
        
        #endif
    }
}