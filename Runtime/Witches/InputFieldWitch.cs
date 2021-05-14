using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    [RequireComponent(typeof(InputField))]
    [AddComponentMenu("UI/Witches/Input Field Witch")]
    public class InputFieldWitch : UIWitch<InputField, string, IInputFieldSpell>
    {
        protected override UnityEvent<string> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<string> setValueWithoutNotify => selectable.SetTextWithoutNotify;

        public override IInputFieldSpell spell 
        { 
            get => base.spell;
            set
            {
                if(base.spell != null)
                {
                    selectable.onEndEdit.RemoveListener(spell.EndEdit);
                    selectable.onValidateInput -= spell.ValidateInput;
                }

                base.spell = value;

                if (base.spell != null)
                {
                    selectable.onValidateInput += spell.ValidateInput;
                    selectable.onEndEdit.AddListener(spell.EndEdit);
                }
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if(spell != null)
            {
                selectable.onValidateInput += spell.ValidateInput;
                selectable.onEndEdit.AddListener(spell.EndEdit);
            }
        }

        protected override void OnDisable()
        {
            if (spell != null)
            {
                selectable.onEndEdit.RemoveListener(spell.EndEdit);
                selectable.onValidateInput -= spell.ValidateInput;
            }

            base.OnDisable();
        }
    }
}
