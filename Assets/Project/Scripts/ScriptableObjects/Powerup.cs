using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public abstract void Apply(GameObject receiver);
}