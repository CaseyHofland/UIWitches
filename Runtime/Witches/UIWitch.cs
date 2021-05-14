using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    [ExecuteAlways]
    public abstract class UIWitch<T, U> : MonoBehaviour
        where T : Selectable
        where U : IUISpell<T>
    {
        private T _selectable;
        public T selectable => _selectable ? _selectable : (_selectable = GetComponent<T>());

        [SerializeReference] private U _spell;
        public virtual U spell
        {
            get => _spell;
            set => _spell = value;
        }

        public virtual void ResetUI()
        {
            spell?.ResetUI(selectable);
        }
    }

    public abstract class UIWitch<T, U, V> : UIWitch<T, V>
        where T : Selectable
        where V : IUISpell<T, U>
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
