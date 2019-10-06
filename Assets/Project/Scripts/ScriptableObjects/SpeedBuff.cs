using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SpeedBuff")]
public class SpeedBuff : Powerup
{
    [SerializeField] private float value;

    public override void Apply(GameObject receiver)
    {
        var playerMovementController = receiver.transform.root.GetComponentInChildren<MovementController>();
        if (playerMovementController != null)
        {
            playerMovementController.MoveSpeed += value;
        }
    }
}