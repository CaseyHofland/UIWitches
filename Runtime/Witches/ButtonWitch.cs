using UnityEngine;
using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A UI Witch for the <c>Button</c> Component, using <c>IButtonSpell</c>.
    /// </summary>
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("UI/Witches/Button Witch")]
    public class ButtonWitch : UIWitch<Button, IButtonSpell>
    {
    }
}
