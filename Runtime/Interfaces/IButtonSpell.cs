using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A <c>Button Witch</c> compatible UI Spell.
    /// </summary>
    public interface IButtonSpell : IUISpell<Button>
    {
        /// <summary>
        /// Reset the UI to the spells desire.
        /// </summary>
        /// <param name="button">The Button to reset.</param>
        new void ResetUI(Button button);

        /// <summary>
        /// Called when the button is clicked.
        /// </summary>
        void OnClick();
    }
}
