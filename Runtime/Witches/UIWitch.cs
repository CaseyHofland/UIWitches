using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

using Object = UnityEngine.Object;

namespace UIWitches
{
    [ExecuteAlways]
    [RequireComponent(typeof(UIBehaviour))]
    public abstract class UIWitch<T> : MonoBehaviour, ISerializationCallbackReceiver
        where T : UIBehaviour
    {
        private T _ui;
        public T ui => _ui ? _ui : (_ui = GetComponent<T>());

        [field: SerializeReference] private object _spell;

        public UISpell<T> spell
        {
            get => (UISpell<T>)_spell;
            set => _spell = value;
        }

        #region Pass-through methods
        protected virtual void Awake()
        {
            if(spell != null)
            {
                spell.Awake(ui);
            }
        }

        protected virtual void Start()
        {
            if(spell != null)
            {
                spell.Start(ui);
            }
        }

        protected virtual void OnEnable()
        {
            if(spell != null)
            {
                spell.OnEnable(ui);
            }
        }

        protected virtual void LateUpdate()
        {
            if(spell != null)
            {
                spell.LateUpdate(ui);
            }
        }

        protected virtual void OnDisable()
        {
            if(spell != null)
            {
                spell.OnDisable(ui);
            }
        }

        protected virtual void OnDestroy()
        {
            if(spell != null)
            {
                spell.OnDestroy(ui);
            }
        }

        protected virtual void OnValidate()
        {
            if(spell != null)
            {
                spell.OnValidate(ui);
            }
        }

        protected virtual void ResetSpell()
        {
            if (spell != null)
            {
                spell.Reset(ui);
            }
        }
        #endregion

        #region managed type reference catch
#if UNITY_EDITOR
        private string lastType;
        private const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.DeclaredOnly | BindingFlags.Instance;
#endif

        public virtual void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            lastType = _spell?.GetType().AssemblyQualifiedName;
#endif
        }

        public virtual void OnAfterDeserialize()
        {
#if UNITY_EDITOR
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
#endif
        }
        #endregion
    }
}
