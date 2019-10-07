using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class KanyeIsDead : MonoBehaviour
{
    [SerializeField] private GameEvent KanyeDied;

    public void RaiseKanyeDied()
    {
        KanyeDied.Raise();
    }
}
