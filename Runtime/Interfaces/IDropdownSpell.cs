using UnityEngine.UI;

namespace UIWitches
{
    public interface IDropdownSpell : IUISpell<Dropdown, int>
    {
        new void ResetUI(Dropdown dropdown);
        new void ValueChanged(int dropdownIndex);
    }
}
