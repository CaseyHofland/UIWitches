using UnityEngine.UI;

namespace UIWitches
{
    public interface IButtonSpell : IUISpell<Button>
    {
        new void ResetUI(Button button);
    }
}
