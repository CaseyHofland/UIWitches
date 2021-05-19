using TMPro;

namespace UIWitches.TMPro
{
    /// <summary>
    /// A <c>TMP_InputField Witch</c> compatible UI Spell.
    /// </summary>
    public interface ITMP_InputFieldSpell : IUISpell<TMP_InputField, string>
    {
        /// <summary>
        /// Reset the UI to the spells desire.
        /// </summary>
        /// <param name="tmp_InputField">The TMP_InputField to reset.</param>
        new void ResetUI(TMP_InputField tmp_InputField);

        /// <summary>
        /// Passes through the new text when it is changed.
        /// </summary>
        /// <param name="text">The new text.</param>
        new void OnValueChanged(string text);

        char ValidateInput(string text, int charIndex, char addedChar);
        void EndEdit(string value);
    }
}
