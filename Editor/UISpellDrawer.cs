using UnityEditor;
using UnityEngine;

namespace UIWitches.Editor
{
    [CustomPropertyDrawer(typeof(UISpell<>), true)]
    public class UISpellDrawer : PropertyDrawer
    {
        public const float heightMargin = 2f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            property = property.Copy();
            var pathStart = $"{property.propertyPath}.";
            if (property.NextVisible(true) && property.propertyPath.StartsWith(pathStart))
            {
                do
                {
                    position.height = EditorGUI.GetPropertyHeight(property, true);

                    EditorGUI.PropertyField(position, property, true);

                    position.y += position.height + heightMargin;
                }
                while (property.NextVisible(false) && property.propertyPath.StartsWith(pathStart));
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var height = heightMargin;

            property = property.Copy();
            var pathStart = $"{property.propertyPath}.";
            if (property.NextVisible(true) && property.propertyPath.StartsWith(pathStart))
            {
                do
                {
                    height += EditorGUI.GetPropertyHeight(property, true);
                }
                while (property.NextVisible(false) && property.propertyPath.StartsWith(pathStart));
            }

            return height;
        }
    }
}
