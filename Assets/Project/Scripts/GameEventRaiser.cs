using ScriptableObjectArchitecture;
using UnityEngine;

public class GameEventRaiser : MonoBehaviour
{
    public void RaiseEvent(GameEvent evt)
    {
        evt.Raise();
    }
    
    public void RaiseEvent2(TestGameEvent evt)
    {
        evt.Raise();
    }
}
