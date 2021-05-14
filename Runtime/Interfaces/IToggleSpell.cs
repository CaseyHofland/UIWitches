using UnityEngine.UI;

namespace UIWitches
{
    public interface IToggleSpell : IUISpell<Toggle, bool>
    {
        new void ResetUI(Toggle toggle);
        new void ValueChanged(bool isOn);
    }
}
