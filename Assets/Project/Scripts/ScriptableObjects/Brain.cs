using UnityEngine;

public abstract class Brain : ScriptableObject
{
    public virtual void Initialize(Thinker tank)
    {
    }

    public abstract void Think(Thinker thinker);
}