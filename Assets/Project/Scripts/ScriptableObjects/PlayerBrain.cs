using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Brains/Player Controlled")]
public class PlayerBrain : Brain
{
    public override void Think(Thinker thinker)
    {
        DrakeController drake = thinker.GetComponent<DrakeController>();
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        drake.Walk(moveInput);
        if (Input.GetButtonDown("Jump") || moveInput.y > 0)
        {
            drake.Jump();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            drake.Attack();
        }
    }
}