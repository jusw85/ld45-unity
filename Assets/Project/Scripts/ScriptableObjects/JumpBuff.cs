using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/JumpBuff")]
public class JumpBuff : Powerup
{
    [SerializeField] private float value;

    public override void Apply(GameObject receiver)
    {
        var playerMovementController = receiver.transform.root.GetComponentInChildren<MovementController>();
        if (playerMovementController != null)
        {
            playerMovementController.JumpHeight += value;
        }
    }
}