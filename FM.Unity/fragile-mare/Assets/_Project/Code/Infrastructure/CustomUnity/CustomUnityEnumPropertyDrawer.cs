using System;
using System.Collections.Generic;
using System.Text;
using _Project.Code.Infrastructure.CustomUnity;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    [CustomPropertyDrawer(typeof(CustomUnityEnum<>))]
    public class CustomUnityEnumPropertyDrawer : PropertyDrawer
    {

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            Dictionary<string, VisualElement> dictionary = new();
            var root = new VisualElement();
            
            var valuesProperty = property.FindPropertyRelative("values");
            var chosenValueIndexProperty = property.FindPropertyRelative("chosenValueIndex");
            var chosenValueProperty = property.FindPropertyRelative("chosenValue");

            var propsEnumerator = valuesProperty.Copy().GetEnumerator();
            
            var foldout = new Foldout { text = property.name };

            var dropdown = new DropdownField("Options");
            foldout.Add(dropdown);

            while (propsEnumerator.MoveNext())
            {
                if (propsEnumerator.Current is not SerializedProperty curr) continue;

                var id = RemoveManagedReference(curr.type);
                
                dropdown.choices.Add(id);
                var field = new PropertyField(curr, id);
                field.BindProperty(curr);
                foldout.Add(field);
                
                dictionary[id] = field;
                
                Debug.Log(id);
            }

            dropdown.RegisterCallback<ChangeEvent<string>>(evt =>
            {
                if (evt.previousValue == evt.newValue) return;
                Debug.Log($"{evt.previousValue} - {evt.newValue}");
                
                try { if (evt.previousValue != null) foldout.Remove(dictionary[evt.previousValue]); }
                catch (Exception _) { /* ignored */ }
                Debug.Log(dropdown.index);
                
                chosenValueIndexProperty.intValue = dropdown.index;
                chosenValueIndexProperty.serializedObject.ApplyModifiedProperties();
                
                if(dictionary.ContainsKey(evt.newValue)) foldout.Add(dictionary[evt.newValue]);
            });
            
            dropdown.BindProperty(chosenValueProperty);
            
            root.Add(foldout);
            
            (propsEnumerator as IDisposable)?.Dispose();

            var first = true;
            dropdown.RegisterCallback<GeometryChangedEvent>(_ =>
            {
                if (!first) return;
                
                foreach (var (name, visualElement) in dictionary)
                {
                    if(name == dropdown.value || name == chosenValueProperty.stringValue) continue;
                    foldout.Remove(visualElement);
                }

                first = false;
            });

            return root;
        }
        
        
        public string RemoveManagedReference(string s)
        {
            var res = string.Copy(s);
            
            const string begin = "managedReference<";
            const string end = ">";
            
            var index = res.IndexOf(begin, StringComparison.Ordinal);
            if (index >= 0)
            {
                res = res.Remove(index, begin.Length);
            }

            index = res.IndexOf(end, StringComparison.Ordinal);
            if (index >= 0)
            {
                res = res.Remove(index, end.Length);
            }

            return res;
        }

        public string CamelCaseSpacing(string s)
        {
            var res = string.Copy(s);
            
            var builder = new StringBuilder();
            var first = true;
            var prev = new char();
            
            foreach (var letter in res)
            {
                if (first)
                {
                    prev = letter;
                    first = false;
                    continue;
                }

                builder.Append(char.IsUpper(letter) && char.IsLower(prev) ? $"{prev} " : $"{prev}");
                prev = letter;
            }
            
            builder.Append(prev);

            return res;
        }
    }
}
