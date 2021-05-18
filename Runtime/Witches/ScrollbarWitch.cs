using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A UI Witch for the <c>Scrollbar</c> Component, using <c>IScrollbarSpell</c>.
    /// </summary>
    [RequireComponent(typeof(Scrollbar))]
    [AddComponentMenu("UI/Witches/Scrollbar Witch")]
    public class ScrollbarWitch : UIWitch<Scrollbar, float, IScrollbarSpell>
    {
        protected override UnityEvent<float> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<float> setWithoutNotify => selectable.SetValueWithoutNotify;
    }
}
