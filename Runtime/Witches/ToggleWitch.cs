using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    [RequireComponent(typeof(Toggle))]
    [AddComponentMenu("UI/Witches/Toggle Witch")]
    public class ToggleWitch : UIWitch<Toggle, bool, IToggleSpell>
    {
        protected override UnityEvent<bool> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<bool> setValueWithoutNotify => selectable.SetIsOnWithoutNotify;
    }
}
