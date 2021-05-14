using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UIWitches.Editor
{
    [CustomEditor(typeof(UIWitch<, >), true)]
    public class UIWitchEditor : UnityEditor.Editor
    {
        protected SerializedProperty _spell;

        private Type[] spellTypes;
        private string[] displayOptions;

        protected virtual void OnEnable()
        {
            _spell = serializedObject.FindProperty(nameof(_spell));

            // Find all classes of the Interface Type
            var spellType = target.GetType().GetField(nameof(_spell), BindingFlags.NonPublic | BindingFlags.Instance).FieldType;
            spellTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                from type in assembly.GetTypes()
                                where !type.IsAbstract
                                where spellType.IsAssignableFrom(type)
                                select type).ToArray();

            var displayOptions = new List<string>(Array.ConvertAll(spellTypes, spellType => spellType.Name));
            displayOptions.Insert(0, "None");

            this.displayOptions = displayOptions.ToArray();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var index = Array.IndexOf(spellTypes, CurrentSpellType()) + 1;

            EditorGUI.BeginChangeCheck();
            index = EditorGUILayout.Popup("Spells", index, displayOptions);
            if (EditorGUI.EndChangeCheck())
            {
                if (index == 0)
                {
                    _spell.managedReferenceValue = null;
                }
                else
                {
                    var spellType = spellTypes[index - 1];
                    _spell.managedReferenceValue = Activator.CreateInstance(spellType);
                }
            }

            EditorGUILayout.PropertyField(_spell, true);

            if(index != 0 && GUILayout.Button("Reset UI"))
            {
                var resetUI = target.GetType().GetMethod(nameof(UIWitch < Selectable, IUISpell<Selectable>>.ResetUI));
                resetUI.Invoke(target, Array.Empty<object>());

                EditorApplication.QueuePlayerLoopUpdate();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private Type CurrentSpellType()
        {
            if (string.IsNullOrEmpty(_spell.managedReferenceFullTypename))
            {
                return null;
            }

            var fullTypename = _spell.managedReferenceFullTypename.Split(' ');
            var assembly = Assembly.Load(fullTypename[0]);
            var type = assembly.GetType(fullTypename[1]);
            
            return type;
        }
    }
}
