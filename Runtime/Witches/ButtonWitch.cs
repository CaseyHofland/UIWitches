using UnityEngine;
using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A UI Witch for the <c>Button</c> Component, using <c>IButtonSpell</c>.
    /// </summary>
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("UI/Witches/Button Witch")]
    public class ButtonWitch : UIWitch<Button, IButtonSpell>
    {
        public override IButtonSpell spell 
        { 
            get => base.spell;
            set
            {
                if(base.spell != null)
                {
                    selectable.onClick.RemoveListener(base.spell.OnClick);
                }

                base.spell = value;

                if(base.spell != null)
                {
                    selectable.onClick.AddListener(base.spell.OnClick);
                }
            }
        }

        protected virtual void OnEnable()
        {
            if(spell != null)
            {
                selectable.onClick.AddListener(spell.OnClick);
            }
        }

        protected virtual void OnDisable()
        {
            if(spell != null)
            {
                selectable.onClick.RemoveListener(spell.OnClick);
            }
        }
    }
}
