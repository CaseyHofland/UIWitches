using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine.EventSystems;

namespace UIWitches.Editor
{
    [CustomEditor(typeof(UIWitch<>), true)]
    public class UIWitchEditor : UnityEditor.Editor
    {
        protected SerializedProperty m_Script;
        protected SerializedProperty _spell;

        protected PropertyInfo spellProperty;
        protected object spellValue => spellProperty.GetValue(target);

        private Type[] spellTypes;
        private string[] displayOptions;

        protected virtual void OnEnable()
        {
            m_Script = serializedObject.FindProperty(nameof(m_Script));
            _spell = serializedObject.FindProperty(nameof(_spell));

            spellProperty = target.GetType().GetProperty(nameof(UIWitch<UIBehaviour>.spell));

            spellTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                          from type in assembly.GetTypes()
                          where type.IsClass
                          where !type.IsAbstract
                          where !type.IsGenericType
                          where type.IsSubclassOf(spellProperty.PropertyType)
                          where !type.IsSubclassOf(typeof(UnityEngine.Object))
                          select type).ToArray();

            var spaceCapitalPattern = new Regex(@"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))");

            displayOptions = new string[spellTypes.Length + 1];
            displayOptions[0] = "None";
            for(int i = 1; i < displayOptions.Length; i++)
            {
                displayOptions[i] = spellTypes[i - 1].Name;
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(m_Script, true);
            EditorGUI.EndDisabledGroup();

            var index = Array.IndexOf(spellTypes, spellValue?.GetType()) + 1;

            EditorGUI.BeginChangeCheck();
            index = EditorGUILayout.Popup("Spells", index, displayOptions);
            if(EditorGUI.EndChangeCheck())
            {
                var value = index == 0 ? null : Activator.CreateInstance(spellTypes[index - 1]);
                _spell.managedReferenceValue = value;
            }

            if(!string.IsNullOrEmpty(_spell.managedReferenceFullTypename))
            {
                EditorGUILayout.PropertyField(_spell, true);
            }

            var iterator = _spell.Copy();
            while (iterator.NextVisible(false))
            {
                EditorGUILayout.PropertyField(iterator, true);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
