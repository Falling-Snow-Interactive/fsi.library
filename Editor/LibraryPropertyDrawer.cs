using System.Collections.Generic;
using Fsi.Libraries;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fsi.library
{
    public abstract class LibraryPropertyDrawer<T> : PropertyDrawer 
        where T : ScriptableEntry<string, T>
    {
        public abstract string LibraryPath { get; }

        private ILibrary<string, T> library;

        private SerializedProperty property;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;
            
            library ??= GetLibrary();
            
            VisualElement root = new();

            List<string> choices = library.GetKeys();
            
            int defaultIndex = 0;
            if (property.objectReferenceValue is T value)
            {
                string key = value.Key;
                defaultIndex = choices.IndexOf(key);
            }
            
            DropdownField dropdown = new DropdownField(choices, defaultIndex);
            dropdown.RegisterValueChangedCallback(OnValueChanged);

            root.Add(dropdown);

            return root;
        }

        private void OnValueChanged(ChangeEvent<string> evt)
        {
            foreach (var entry in library.Entries)
            {
                if (entry.Key == evt.newValue)
                {
                    property.objectReferenceValue = entry.Value;
                    property.serializedObject.ApplyModifiedProperties();
                }
            }
        }

        private ScriptableLibrary<string, T> GetLibrary()
        {
            return AssetDatabase.LoadAssetAtPath<ScriptableLibrary<string, T>>(LibraryPath);
        }
    }
}
