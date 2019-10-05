using UnityEngine;

public abstract class Brain : ScriptableObject
{
    public abstract void Think(Thinker thinker);
}