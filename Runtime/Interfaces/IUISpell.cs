using UnityEngine.UI;

namespace UIWitches
{
    public interface IUISpell<in T> where T : Selectable
    {
        void ResetUI(T selectable);
    }

    public interface IUISpell<in T, U> : IUISpell<T> where T : Selectable
    {
        U GetValue();
        void ValueChanged(U value);
    }
}
