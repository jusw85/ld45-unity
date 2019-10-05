using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Brains/Player Controlled")]
public class PlayerBrain : Brain
{
    public override void Think(Thinker thinker)
    {
        DrakeController drake = thinker.GetComponent<DrakeController>();
        drake.Walk(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        if (Input.GetButtonDown("Jump"))
        {
            drake.Jump();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            drake.Attack();
        }
    }
}