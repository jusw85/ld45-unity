using System;
using ScriptableObjectArchitecture;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "ScriptableObjects/TestGameEvent")]
public sealed class TestGameEvent : GameEventBase
{
    public void HelloWorld()
    {
        Debug.Log("!!!!!");
    }
}