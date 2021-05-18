using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UIWitches.TMPro
{
    /// <summary>
    /// A UI Witch for the <c>TMP_Dropdown</c> Component, using <c>ITMP_DropdownSpell</c>.
    /// </summary>
    [RequireComponent(typeof(TMP_Dropdown))]
    [AddComponentMenu("UI/Witches/Dropdown Witch - TextMeshPro")]
    public class TMP_DropdownWitch : UIWitch<TMP_Dropdown, int, ITMP_DropdownSpell>
    {
        protected override UnityEvent<int> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<int> setWithoutNotify => selectable.SetValueWithoutNotify;
    }
}
