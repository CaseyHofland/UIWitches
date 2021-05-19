using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A <c>InputField Witch</c> compatible UI Spell.
    /// </summary>
    public interface IInputFieldSpell : IUISpell<InputField, string>
    {
        /// <summary>
        /// Reset the UI to the spells desire.
        /// </summary>
        /// <param name="inputField">The InputField to reset.</param>
        new void ResetUI(InputField inputField);

        /// <summary>
        /// Passes through the new text when it is changed.
        /// </summary>
        /// <param name="text">The new text.</param>
        new void OnValueChanged(string text);

        char ValidateInput(string text, int charIndex, char addedChar);
        void EndEdit(string value);
    }
}
