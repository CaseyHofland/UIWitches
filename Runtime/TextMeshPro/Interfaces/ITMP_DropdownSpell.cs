using TMPro;

namespace UIWitches.TMPro
{
    /// <summary>
    /// A <c>TMP_Dropdown Witch</c> compatible UI Spell.
    /// </summary>
    public interface ITMP_DropdownSpell : IUISpell<TMP_Dropdown, int>
    {
        /// <summary>
        /// Reset the UI to the spells desire.
        /// </summary>
        /// <param name="tmp_Dropdown">The TMP_Dropdown to reset.</param>
        new void ResetUI(TMP_Dropdown tmp_Dropdown);

        /// <summary>
        /// Passes through the new tmp_Dropdown index when it is changed.
        /// </summary>
        /// <param name="tmp_DropdownIndex">The new tmp_Dropdown index.</param>
        new void OnValueChanged(int tmp_DropdownIndex);
    }
}
