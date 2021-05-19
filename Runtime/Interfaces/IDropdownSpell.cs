using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A <c>Dropdown Witch</c> compatible UI Spell.
    /// </summary>
    public interface IDropdownSpell : IUISpell<Dropdown, int>
    {
        /// <summary>
        /// Reset the UI to the spells desire.
        /// </summary>
        /// <param name="dropdown">The Dropdown to reset.</param>
        new void ResetUI(Dropdown dropdown);

        /// <summary>
        /// Passes through the new dropdown index when it is changed.
        /// </summary>
        /// <param name="dropdownIndex">The new dropdown index.</param>
        new void OnValueChanged(int dropdownIndex);
    }
}
