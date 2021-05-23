using System;
using UnityEngine.EventSystems;

namespace UIWitches
{
    [Serializable]
    public abstract class UISpell<T> where T : UIBehaviour
    {
        internal protected virtual void Awake(T ui) { }
        internal protected virtual void Start(T ui) { }
        internal protected virtual void OnEnable(T ui) { }
        internal protected virtual void LateUpdate(T ui) { }
        internal protected virtual void OnDisable(T ui) { }
        internal protected virtual void OnDestroy(T ui) { }

        internal protected virtual void OnValidate(T ui) { }
        internal protected virtual void Reset(T ui) { }
    }
}
