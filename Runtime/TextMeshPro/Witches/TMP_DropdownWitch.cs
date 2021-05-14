using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UIWitches.TMPro
{
    [RequireComponent(typeof(TMP_Dropdown))]
    [AddComponentMenu("UI/Witches/Dropdown Witch - TextMeshPro")]
    public class TMP_DropdownWitch : UIWitch<TMP_Dropdown, int, ITMP_DropdownSpell>
    {
        protected override UnityEvent<int> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<int> setValueWithoutNotify => selectable.SetValueWithoutNotify;
    }
}
