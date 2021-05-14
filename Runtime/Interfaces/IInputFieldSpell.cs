using UnityEngine.UI;

namespace UIWitches
{
    public interface IInputFieldSpell : IUISpell<InputField, string>
    {
        new void ResetUI(InputField inputField);
        new void ValueChanged(string text);

        char ValidateInput(string text, int charIndex, char addedChar);
        void EndEdit(string value);
    }
}
