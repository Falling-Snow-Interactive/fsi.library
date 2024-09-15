using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fsi.Libraries
{
    public abstract class ScriptableLibraryAttributeDrawer<TKey, TEntry> : PropertyDrawer
        where TEntry : Object, ILibraryEntry<TKey, TEntry>
    {
        protected abstract string LibraryPath { get; }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var library = AssetDatabase.LoadAssetAtPath<ScriptableLibrary<TKey, TEntry>>(LibraryPath);
        
            List<string> keyStrings = new();
            var currentObj = property.objectReferenceValue;
            string selected = "No object selected";
        
            foreach (var entry in library.Entries)
            {
                keyStrings.Add(entry.Key.ToString());
        
                if (currentObj == entry.Value)
                {
                    selected = entry.Key.ToString();
                }
            }
            
            VisualElement root = new();
        
            DropdownField dropdown = new()
                                     {
                                         choices = keyStrings,
                                         label = property.displayName,
                                         value = selected,
                                         style =
                                         {
                                             flexGrow = 1,
                                             flexShrink = 1,
                                         },
                                     };
            
            dropdown.RegisterValueChangedCallback(value =>
                                                  {
                                                      int index = keyStrings.IndexOf(value.newValue);
                                                      property.objectReferenceValue = library.Entries[index].Value;
                                                      dropdown.value = value.newValue;
                                                      property.serializedObject.ApplyModifiedProperties();
                                                  });
        
            root.Add(dropdown);
            
            return root;
        }
    }
}