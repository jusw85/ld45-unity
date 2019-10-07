using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class PlayerGlobalEvents : MonoBehaviour
{
    [SerializeField] private GameEvent playerDealtDamage;
    [SerializeField] private GameEvent enemyDie;
    [SerializeField] private GameEvent cameraShake;

    public void RaisePlayerDealtDamage()
    {
        playerDealtDamage.Raise();
    }
    
    public void RaiseEnemyDie()
    {
        enemyDie.Raise();
    }
    
    public void CameraShake()
    {
        cameraShake.Raise();
    }
}
