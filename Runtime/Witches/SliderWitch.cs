using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A UI Witch for the <c>Slider</c> Component, using <c>ISliderSpell</c>.
    /// </summary>
    [RequireComponent(typeof(Slider))]
    [AddComponentMenu("UI/Witches/Slider Witch")]
    public class SliderWitch : UIWitch<Slider, float, ISliderSpell>
    {
        protected override UnityEvent<float> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<float> setWithoutNotify => selectable.SetValueWithoutNotify;
    }
}
