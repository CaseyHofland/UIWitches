using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A <c>Toggle Witch</c> compatible UI Spell.
    /// </summary>
    public interface IToggleSpell : IUISpell<Toggle, bool>
    {
        /// <summary>
        /// Reset the UI to the spells desire.
        /// </summary>
        /// <param name="toggle">The Toggle to reset.</param>
        new void ResetUI(Toggle toggle);

        /// <summary>
        /// Passes through the new toggle value when it is changed.
        /// </summary>
        /// <param name="isOn">The new toggle value.</param>
        new void ValueChanged(bool isOn);
    }
}
