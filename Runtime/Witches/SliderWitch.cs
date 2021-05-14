using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    [RequireComponent(typeof(Slider))]
    [AddComponentMenu("UI/Witches/Slider Witch")]
    public class SliderWitch : UIWitch<Slider, float, ISliderSpell>
    {
        protected override UnityEvent<float> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<float> setValueWithoutNotify => selectable.SetValueWithoutNotify;
    }
}
