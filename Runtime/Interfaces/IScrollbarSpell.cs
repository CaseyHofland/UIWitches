using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A <c>Scrollbar Witch</c> compatible UI Spell.
    /// </summary>
    public interface IScrollbarSpell : IUISpell<Scrollbar, float>
    {
        /// <summary>
        /// Reset the UI to the spells desire.
        /// </summary>
        /// <param name="scrollbar">The Scrollbar to reset.</param>
        new void ResetUI(Scrollbar scrollbar);

        /// <summary>
        /// Passes through the new scrollbar value when it is changed.
        /// </summary>
        /// <param name="scrollbarValue">The new scrollbar value.</param>
        new void ValueChanged(float scrollbarValue);
    }
}
