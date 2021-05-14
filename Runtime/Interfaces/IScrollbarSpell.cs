using UnityEngine.UI;

namespace UIWitches
{
    public interface IScrollbarSpell : IUISpell<Scrollbar, float>
    {
        new void ResetUI(Scrollbar scrollbar);
        new void ValueChanged(float scrollbarValue);
    }
}
