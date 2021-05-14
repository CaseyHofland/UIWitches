using UnityEngine;
using UnityEngine.UI;

namespace UIWitches
{
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("UI/Witches/Button Witch")]
    public class ButtonWitch : UIWitch<Button, IButtonSpell>
    {
    }
}
