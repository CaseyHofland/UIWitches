using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using Object = UnityEngine.Object;

namespace UIWitches
{
    /// <summary>
    /// A UI Witch base class implementing generic UI Witch functionality.
    /// </summary>
    /// <typeparam name="T">The type of Selectable this UI Witch is for.</typeparam>
    /// <typeparam name="U">The type of Spell this UI Witch needs.</typeparam>
    [ExecuteAlways]
    [RequireComponent(typeof(Selectable))]
    public abstract class UIWitch<T, U> : MonoBehaviour
#if UNITY_EDITOR
        , ISerializationCallbackReceiver
#endif
        where T : Selectable
        where U : class, IUISpell<T>
    {
        private T _selectable;
        public T selectable => _selectable ? _selectable : (_selectable = GetComponent<T>());

        [SerializeReference] protected U _spell;

        /// <summary>
        /// The spell the UI Witch is using. The spell is what influences the UI.
        /// </summary>
        public virtual U spell
        {
            get => _spell;
            set => _spell = value;
        }

        /// <summary>
        /// Calls the Reset UI function of the assigned spell and applies changes to the UI.
        /// </summary>
        public void ResetUI()
        {
            spell?.ResetUI(selectable);
        }

#if UNITY_EDITOR
        private string lastType;
        public virtual void OnBeforeSerialize()
        {
            lastType = _spell?.GetType().AssemblyQualifiedName;
        }

        private const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.DeclaredOnly | BindingFlags.Instance;
        public virtual void OnAfterDeserialize()
        {
            if (!string.IsNullOrEmpty(lastType) && Type.GetType(lastType) == null)
            {
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    // Destroy our object immediately. Doing this takes [DisallowMultipleComponent] into account.
                    var go = gameObject;
                    DestroyImmediate(this);

                    // Create a new component of the same type.
                    var componentType = GetType();
                    var component = go.AddComponent(componentType);

                    // Get all the fields (up to MonoBehaviour or we might break ID references).
                    IEnumerable<FieldInfo> finfos = Enumerable.Empty<FieldInfo>();
                    do
                    {
                        finfos = finfos.Concat(componentType.GetFields(bindingFlags));
                        componentType = componentType.BaseType;
                    }
                    while (componentType != typeof(MonoBehaviour));

                    // Filter out any non serialized field.
                    finfos = from field in finfos
                             let attributeTypes = field.CustomAttributes.Select(attribute => attribute.AttributeType)
                             where !attributeTypes.Any(type => type == typeof(NonSerializedAttribute) || type == typeof(ObsoleteAttribute))
                             where attributeTypes.Contains(typeof(SerializeReference))
                                || (
                                    (field.IsPublic || attributeTypes.Contains(typeof(SerializeField)))
                                    && (field.FieldType.IsSerializable || field.FieldType.IsSubclassOf(typeof(Object)))
                                    )
                             select field;

                    // Copy our serialized values.
                    foreach (var finfo in finfos)
                    {
                        finfo.SetValue(component, finfo.GetValue(this));
                    }
                };
            }
        }
#endif
    }

    /// <summary>
    /// A UI Witch base class implementing generic UI Witch functionality.
    /// </summary>
    /// <typeparam name="T">The type of Selectable this UI Witch is for.</typeparam>
    /// <typeparam name="U">The type of value the Selectable is expecting.</typeparam>
    /// <typeparam name="V">The type of Spell this UI Witch needs.</typeparam>
    public abstract class UIWitch<T, U, V> : UIWitch<T, V>
        where T : Selectable
        where V : class, IUISpell<T, U>
    {
        /// <summary>
        /// The UI's on value changed event.
        /// </summary>
        protected abstract UnityEvent<U> onValueChanged { get; }
        /// <summary>
        /// The UI's set without notify method.
        /// </summary>
        protected abstract UnityAction<U> setWithoutNotify { get; }

        public override V spell
        {
            get => base.spell;
            set
            {
                if (base.spell != null)
                {
                    onValueChanged.RemoveListener(base.spell.ValueChanged);
                }

                base.spell = value;

                if (base.spell != null)
                {
                    onValueChanged.AddListener(base.spell.ValueChanged);
                }
            }
        }

        protected virtual void OnEnable()
        {
            if (spell != null)
            {
                onValueChanged.AddListener(spell.ValueChanged);
            }
        }

        protected virtual void OnDisable()
        {
            if (spell != null)
            {
                onValueChanged.RemoveListener(spell.ValueChanged);
            }
        }

        protected virtual void LateUpdate()
        {
            if (spell != null)
            {
                setWithoutNotify.Invoke(spell.GetValue());
            }
        }
    }
}
