using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A UI Witch for the <c>Dropdown</c> Component, using <c>IDropdownSpell</c>.
    /// </summary>
    [RequireComponent(typeof(Dropdown))]
    [AddComponentMenu("UI/Witches/Dropdown Witch")]
    public class DropdownWitch : UIWitch<Dropdown, int, IDropdownSpell>
    {
        protected override UnityEvent<int> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<int> setWithoutNotify => selectable.SetValueWithoutNotify;
    }
}
