using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    [RequireComponent(typeof(Dropdown))]
    [AddComponentMenu("UI/Witches/Dropdown Witch")]
    public class DropdownWitch : UIWitch<Dropdown, int, IDropdownSpell>
    {
        protected override UnityEvent<int> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<int> setValueWithoutNotify => selectable.SetValueWithoutNotify;
    }
}
