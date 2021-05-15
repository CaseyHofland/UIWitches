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
    [ExecuteAlways]
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
        public virtual U spell
        {
            get => _spell;
            set => _spell = value;
        }

        public virtual void ResetUI()
        {
            spell?.ResetUI(selectable);
        }

#if UNITY_EDITOR
        private string lastType;
        public void OnBeforeSerialize()
        {
            lastType = _spell?.GetType().AssemblyQualifiedName;
        }

        private const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.DeclaredOnly | BindingFlags.Instance;
        public void OnAfterDeserialize()
        {
            if (!string.IsNullOrEmpty(lastType) && Type.GetType(lastType) == null)
            {
                UnityEditor.EditorApplication.delayCall += () =>
                {
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

    public abstract class UIWitch<T, U, V> : UIWitch<T, V>
        where T : Selectable
        where V : class, IUISpell<T, U>
    {
        protected abstract UnityEvent<U> onValueChanged { get; }
        protected abstract UnityAction<U> setValueWithoutNotify { get; }

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
                setValueWithoutNotify.Invoke(spell.GetValue());
            }
        }
    }
}
