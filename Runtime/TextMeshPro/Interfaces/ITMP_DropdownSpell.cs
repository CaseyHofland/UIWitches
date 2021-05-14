using TMPro;

namespace UIWitches.TMPro
{
    public interface ITMP_DropdownSpell : IUISpell<TMP_Dropdown, int>
    {
        new void ResetUI(TMP_Dropdown tmp_Dropdown);
        new void ValueChanged(int tmp_DropdownIndex);
    }
}
