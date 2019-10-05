using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/JumpBuff")]
public class JumpBuff : Powerup
{
    [SerializeField] private float value;

    public override void Apply(GameObject receiver)
    {
        var playerMovementController = receiver.GetComponent<MovementController>();
        if (playerMovementController != null)
        {
            playerMovementController.JumpHeight += value;
        }
    }
}