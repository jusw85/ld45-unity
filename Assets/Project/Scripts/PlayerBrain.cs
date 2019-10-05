using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Brains/Player Controlled")]
public class PlayerControlledBrain : Brain
{
    public override void Think(Thinker thinker)
    {
        MovementController movementController = thinker.GetComponent<MovementController>();
        movementController.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        if (Input.GetButtonDown("Jump"))
        {
            movementController.Jump();
        }
    }
}