using UnityEngine.UI;

namespace UIWitches
{
    public interface ISliderSpell : IUISpell<Slider, float>
    {
        new void ResetUI(Slider slider);
        new void ValueChanged(float sliderValue);
    }
}
