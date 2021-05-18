using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UIWitches.TMPro
{
    /// <summary>
    /// A UI Witch for the <c>TMP_InputField</c> Component, using <c>ITMP_InputFieldSpell</c>.
    /// </summary>
    [RequireComponent(typeof(TMP_InputField))]
    [AddComponentMenu("UI/Witches/Input Field Witch - TextMeshPro")]
    public class TMP_InputFieldWitch : UIWitch<TMP_InputField, string, ITMP_InputFieldSpell>
    {
        protected override UnityEvent<string> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<string> setWithoutNotify => selectable.SetTextWithoutNotify;

        public override ITMP_InputFieldSpell spell
        {
            get => base.spell;
            set
            {
                if (base.spell != null)
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

            if (spell != null)
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
