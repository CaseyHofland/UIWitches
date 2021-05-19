using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A <c>Slider Witch</c> compatible UI Spell.
    /// </summary>
    public interface ISliderSpell : IUISpell<Slider, float>
    {
        /// <summary>
        /// Reset the UI to the spells desire.
        /// </summary>
        /// <param name="slider">The Slider to reset.</param>
        new void ResetUI(Slider slider);

        /// <summary>
        /// Passes through the new slider value when it is changed.
        /// </summary>
        /// <param name="sliderValue">The new slider value.</param>
        new void OnValueChanged(float sliderValue);
    }
}
