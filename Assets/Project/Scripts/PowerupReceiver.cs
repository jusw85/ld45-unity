using UnityEngine;

public class PowerupReceiver : MonoBehaviour
{
    private MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    public void applyPowerup(PowerupType type, int value)
    {
        switch (type)
        {
            case PowerupType.Speed:
                if (movementController != null)
                {
                    movementController.MoveSpeed += value;
                }

                break;
        }
    }
}