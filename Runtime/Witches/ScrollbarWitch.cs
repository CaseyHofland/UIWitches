using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    [RequireComponent(typeof(Scrollbar))]
    [AddComponentMenu("UI/Witches/Scrollbar Witch")]
    public class ScrollbarWitch : UIWitch<Scrollbar, float, IScrollbarSpell>
    {
        protected override UnityEvent<float> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<float> setValueWithoutNotify => selectable.SetValueWithoutNotify;
    }
}
