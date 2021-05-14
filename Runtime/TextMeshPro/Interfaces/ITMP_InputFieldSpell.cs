using TMPro;

namespace UIWitches.TMPro
{
    public interface ITMP_InputFieldSpell : IUISpell<TMP_InputField, string>
    {
        new void ResetUI(TMP_InputField tmp_InputField);
        new void ValueChanged(string text);

        char ValidateInput(string text, int charIndex, char addedChar);
        void EndEdit(string value);
    }
}
