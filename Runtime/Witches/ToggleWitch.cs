using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A UI Witch for the <c>Toggle</c> Component, using <c>IToggleSpell</c>.
    /// </summary>
    [RequireComponent(typeof(Toggle))]
    [AddComponentMenu("UI/Witches/Toggle Witch")]
    public class ToggleWitch : UIWitch<Toggle, bool, IToggleSpell>
    {
        protected override UnityEvent<bool> onValueChanged => selectable.onValueChanged;
        protected override UnityAction<bool> setWithoutNotify => selectable.SetIsOnWithoutNotify;
    }
}
