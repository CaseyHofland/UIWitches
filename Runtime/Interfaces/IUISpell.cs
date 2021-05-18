using UnityEngine.UI;

namespace UIWitches
{
    /// <summary>
    /// A UI Spell base class implementing generic UI Spell functionality.
    /// </summary>
    /// <typeparam name="T">The type of Selectable this UI Spell is for.</typeparam>
    public interface IUISpell<in T> where T : Selectable
    {
        /// <summary>
        /// Reset the UI to the spells desire.
        /// </summary>
        /// <param name="selectable">The Selectable to reset.</param>
        void ResetUI(T selectable);
    }

    /// <summary>
    /// A UI Spell base class implementing generic UI Spell functionality.
    /// </summary>
    /// <typeparam name="T">The type of Selectable this UI Spell is for.</typeparam>
    /// <typeparam name="U">The type of value the Selectable is expecting.</typeparam>
    public interface IUISpell<in T, U> : IUISpell<T> where T : Selectable
    {
        /// <summary>
        /// Returns the value for the UI to display.
        /// </summary>
        /// <returns>The value for the UI to display.</returns>
        U GetValue();

        /// <summary>
        /// Passes through the new value of the UI when it is changed.
        /// </summary>
        /// <param name="value">The new value of the UI.</param>
        void ValueChanged(U value);
    }
}
