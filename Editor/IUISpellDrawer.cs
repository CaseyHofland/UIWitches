using UnityEditor;
using UnityEngine;

namespace UIWitches.Editor
{
    [CustomPropertyDrawer(typeof(IUISpell<>), true)]
    public class IUISpellDrawer : PropertyDrawer
    {
        private const float heightMargin = 2f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            property = property.Copy();
            if (property.NextVisible(true))
            {
                do
                {
                    position.height = EditorGUI.GetPropertyHeight(property);

                    EditorGUI.PropertyField(position, property);

                    position.y += position.height + heightMargin;
                }
                while (property.NextVisible(false));
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var height = heightMargin;

            property = property.Copy();
            if (property.NextVisible(true))
            {
                do
                {
                    height += EditorGUI.GetPropertyHeight(property);
                }
                while (property.NextVisible(false));
            }

            return height;
        }
    }
}
